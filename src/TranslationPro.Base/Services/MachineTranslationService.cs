#region Header Info

// Copyright 2023 Rod Johnson.  All rights reserved

#endregion

using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using TranslationPro.Base.Common.Data.Enums;
using TranslationPro.Base.Common.Data.Interfaces;
using TranslationPro.Base.Common.Services.Bases;
using TranslationPro.Base.Entities;
using TranslationPro.Base.Errors;
using TranslationPro.Shared.Common;
using TranslationPro.Shared.Enums;
using TranslationPro.Shared.Results;

namespace TranslationPro.Base.Services;

public class MachineTranslationService : BaseService<MachineTranslation>, IMachineTranslationService
{
    private static string GetLogMessage(string message, [CallerMemberName] string callerName = null)
    {
        return $"[{nameof(MachineTranslationService)}.{callerName}] - {message}";
    }

    private readonly PhraseErrorDescriber _phraseErrors;
    private readonly ILogger<MachineTranslationService> _logger;
    private readonly IRepositoryAsync<Phrase> _phraseRepository;
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
        _phraseRepository = UnitOfWork.RepositoryAsync<Phrase>();
    }

    private IQueryable<Phrase> Phrases =>
        _phraseRepository.Queryable();

    private async Task<int> SaveTranslationsAsync(Dictionary<string, List<GenericTranslationResult>> input, TranslationEngine engine)
    {
        _logger.LogInformation(GetLogMessage("Saving Translations..."));
        var retVal = 0;
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

                retVal += _phraseRepository.InsertOrUpdateGraph(phrase, true);
            }

        }

        return retVal;
    }

    public async Task<Result> AdjustWeights(int phraseId, string languageId, string oldText, string newText)
    {
        var phrase = await Phrases.Where(x => x.Id == phraseId).FirstAsync();

        var oldTranslation = phrase.MachineTranslations.FirstOrDefault(x => x.Text == oldText && x.LanguageId == languageId);

        var newTranslation = phrase.MachineTranslations.FirstOrDefault(x => x.Text == newText && x.LanguageId == languageId);

        if (oldTranslation == null || newTranslation == null) return Result.Success();

        if (oldTranslation.EngineId != newTranslation.EngineId)
        {
            phrase.ObjectState = ObjectState.Modified;

            oldTranslation.Weight -= 1;
            oldTranslation.ObjectState = newTranslation.ObjectState;

            newTranslation.Weight += 1;
            newTranslation.ObjectState = ObjectState.Modified;

            var records = _phraseRepository.InsertOrUpdateGraph(phrase, true);
            return records > 0 ? Result.Success(phraseId) : Result.Failed();
        }
        return Result.Success(); ;
    }

    public async Task<int> ProcessTranslationsAsync(Guid applicationId)
    {
        _logger.LogInformation(GetLogMessage("Processing Translations for application: {0}"), applicationId);

        var retVal = 0;

        var engines = new Dictionary<TranslationEngine, ITranslationProcessor>()
        {
            { TranslationEngine.Google, _googleService },
            { TranslationEngine.Azure, _microsoftService }
        };

        foreach (var (engine, processor) in engines)
        {
            var pending = await GetPendingTranslationsAsync(applicationId, engine);
            var results = await processor.Process(pending);
            retVal += await SaveTranslationsAsync(results, engine);
        }

        return retVal;
    }

    private async Task<Dictionary<string, List<string>>> GetPendingTranslationsAsync(Guid applicationId, TranslationEngine engine)
    {
        var machineTranslations = await Repository.Queryable()
            .Where(x => x.Text == null && x.TranslationDate == null && x.EngineId == engine)
            .Include(x => x.Phrase)
            .ThenInclude(x => x.Applications.Where(a => a.ApplicationId == applicationId))
            .ToListAsync();

        var dictionary = machineTranslations.GroupBy(x => x.LanguageId)
            .ToDictionary(x => x.Key, x => x.Select(a => a.Phrase.Text).ToList());

        return dictionary;

    }

}