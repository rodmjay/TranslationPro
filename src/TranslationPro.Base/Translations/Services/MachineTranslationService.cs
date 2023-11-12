#region Header Info

// Copyright 2023 Rod Johnson.  All rights reserved

#endregion

using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;
using Google.Cloud.Translation.V2;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using TranslationPro.Base.Applications.Entities;
using TranslationPro.Base.Common.Data.Enums;
using TranslationPro.Base.Common.Data.Interfaces;
using TranslationPro.Base.Common.Services.Bases;
using TranslationPro.Base.Phrases;
using TranslationPro.Base.Phrases.Entities;
using TranslationPro.Base.Phrases.Services;
using TranslationPro.Base.Translations.Entities;
using TranslationPro.Base.Translations.Interfaces;
using TranslationPro.Shared.Common;
using TranslationPro.Shared.Enums;
using TranslationPro.Shared.Models;

namespace TranslationPro.Base.Translations.Services;

public class MachineTranslationService : BaseService<MachineTranslation>, IMachineTranslationService
{
    private static string GetLogMessage(string message, [CallerMemberName] string callerName = null)
    {
        return $"[{nameof(MachineTranslationService)}.{callerName}] - {message}";
    }

    private readonly IRepositoryAsync<Application> _applicationRepository;
    private readonly PhraseErrorDescriber _phraseErrors;
    private readonly ILogger<MachineTranslationService> _logger;
    private readonly IRepositoryAsync<Phrase> _phraseRepository;
    private readonly IRepositoryAsync<ApplicationPhrase> _applicationPhraseRepository;
    private readonly IRepositoryAsync<HumanTranslation> _humanTranslationRepository;
    private readonly TranslationErrorDescriber _translationErrors;
    private readonly MicrosoftTranslationService _microsoftService;
    private readonly GoogleTranslationService _googleService;

    public MachineTranslationService(IServiceProvider serviceProvider,
        TranslationErrorDescriber translationErrors,
        MicrosoftTranslationService microsoftService,
        GoogleTranslationService googleService,
        PhraseErrorDescriber phraseErrors, ILogger<MachineTranslationService> logger) : base(serviceProvider)
    {
        _translationErrors = translationErrors;
        _microsoftService = microsoftService;
        _googleService = googleService;
        _phraseErrors = phraseErrors;
        _logger = logger;
        _applicationRepository = UnitOfWork.RepositoryAsync<Application>();
        _phraseRepository = UnitOfWork.RepositoryAsync<Phrase>();
        _applicationPhraseRepository = UnitOfWork.RepositoryAsync<ApplicationPhrase>();
        _humanTranslationRepository = UnitOfWork.RepositoryAsync<HumanTranslation>();
    }
    
    private IQueryable<Phrase> Phrases =>
        _phraseRepository.Queryable();

    private IQueryable<Application> Applications => _applicationRepository.Queryable().Include(x => x.Languages);

    private IQueryable<ApplicationPhrase> ApplicationPhrases => _applicationPhraseRepository.Queryable()
        .Include(x => x.Phrase)
        .ThenInclude(x => x.MachineTranslations)
        .Include(x => x.HumanTranslations);

    public async Task<Result> SaveTranslationAsync(Guid applicationId, int phraseId, TranslationOptions input)
    {
        _logger.LogInformation(GetLogMessage("Saving translation: {0} for phrase: {1} in application: {2}"),
            input.Text,
            phraseId,
            applicationId);

        var phrase = await ApplicationPhrases.Where(x => x.Id == phraseId && x.ApplicationId == applicationId)
            .FirstOrDefaultAsync();

        if (phrase == null)
            return Result.Failed(_phraseErrors.PhraseDoesntExist(phraseId));

        var translation = phrase.HumanTranslations.FirstOrDefault(x => x.LanguageId == input.LanguageId);
        if (translation == null)
        {
            var application = await Applications.Where(x => x.Id == applicationId).FirstAsync();

            var langExists = application.Languages.Any(x => x.LanguageId == input.LanguageId);

            if (!langExists)
                return Result.Failed(
                    _translationErrors.LanguageDoesntExistInApplication(input.LanguageId, phrase.Application.Name));

            translation = new HumanTranslation()
            {
                ObjectState = ObjectState.Added
            };
        }
        else
        {
            translation.ObjectState = ObjectState.Modified;
        }

        translation.LanguageId = input.LanguageId;
        translation.PhraseId = phraseId;
        translation.ApplicationId = applicationId;
        translation.Text = input.Text;

        var records = _humanTranslationRepository.InsertOrUpdateGraph(translation, true);
        if (records > 0)
            return Result.Success();

        return Result.Failed(_translationErrors.UnableToUpdateTranslation(input.Text));
    }

    private async Task SaveTranslationsAsync(Dictionary<string, List<GenericTranslationResult>> input, TranslationEngine engine)
    {
        _logger.LogInformation(GetLogMessage("Saving Translations..."));

        foreach (var (originalText, translations) in input)
        {
            var phrase = await Phrases.Where(x => x.Text == originalText).FirstOrDefaultAsync();
            if (phrase != null)
            {
                foreach (var translation in translations)
                {
                    var language = translation.To;
                    var machineTranslation = phrase.MachineTranslations
                        .First(x => x.EngineId == engine && x.LanguageId == language);
                    machineTranslation.Text = translation.Text;
                    machineTranslation.TranslationDate = DateTime.UtcNow;
                    machineTranslation.ObjectState = ObjectState.Modified;
                }

                var records = _phraseRepository.InsertOrUpdateGraph(phrase, true);
            }

        }
    }

    public async Task<List<Result>> ProcessTranslationsAsync(Guid applicationId)
    {
        _logger.LogInformation(GetLogMessage("Processing Translations for application: {0}"), applicationId);

        var engines = new Dictionary<TranslationEngine, ITranslationProcessor>()
        {
            { TranslationEngine.Google, _googleService },
            { TranslationEngine.Azure, _microsoftService }
        };

        foreach (var (engine, processor) in engines)
        {
            var pending = await GetPendingTranslationsAsync(applicationId, engine);
            var results = await processor.Process(pending);
            await SaveTranslationsAsync(results, engine);
        }

        return new List<Result>();
    }

    private async Task<Dictionary<string, List<string>>> GetPendingTranslationsAsync(Guid applicationId, TranslationEngine engine)
    {
        var machineTranslations = await Repository.Queryable()
            .Where(x=>x.Text == null && x.TranslationDate == null && x.EngineId == engine)
            .Include(x => x.Phrase)
            .ThenInclude(x => x.Applications.Where(a => a.ApplicationId == applicationId))
            .ToListAsync();

        var dictionary = machineTranslations.GroupBy(x => x.LanguageId)
            .ToDictionary(x => x.Key, x => x.Select(a => a.Phrase.Text).ToList());

        return dictionary;

    }

}