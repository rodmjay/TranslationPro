#region Header Info

// Copyright 2023 Rod Johnson.  All rights reserved

#endregion

using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;
using AutoMapper.QueryableExtensions;
using Google.Cloud.Translation.V2;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using TranslationPro.Base.Applications.Entities;
using TranslationPro.Base.Common.Data.Enums;
using TranslationPro.Base.Common.Data.Interfaces;
using TranslationPro.Base.Common.Services.Bases;
using TranslationPro.Base.Phrases;
using TranslationPro.Base.Phrases.Entities;
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
    private readonly TranslationClient _googleClient;
    private readonly ILogger<MachineTranslationService> _logger;
    private readonly IRepositoryAsync<ApplicationPhrase> _phraseRepository;
    private readonly IRepositoryAsync<HumanTranslation> _humanTranslationRepository;
    private readonly TranslationErrorDescriber _translationErrors;

    public MachineTranslationService(IServiceProvider serviceProvider, TranslationErrorDescriber translationErrors,
        PhraseErrorDescriber phraseErrors, TranslationClient googleClient, ILogger<MachineTranslationService> logger) : base(serviceProvider)
    {
        _translationErrors = translationErrors;
        _phraseErrors = phraseErrors;
        _googleClient = googleClient;
        _logger = logger;
        _applicationRepository = UnitOfWork.RepositoryAsync<Application>();
        _phraseRepository = UnitOfWork.RepositoryAsync<ApplicationPhrase>();
        _humanTranslationRepository = UnitOfWork.RepositoryAsync<HumanTranslation>();
    }

    private IQueryable<MachineTranslation> Translations =>
        Repository.Queryable().Include(x => x.Phrase);

    private IQueryable<ApplicationPhrase> Phrases =>
        _phraseRepository.Queryable();

    private IQueryable<Application> Applications => _applicationRepository.Queryable().Include(x => x.Languages);
    
    public async Task<Result> SaveTranslation(Guid applicationId, int phraseId, TranslationOptions input)
    {
        _logger.LogInformation(GetLogMessage("Saving translation: {0} for phrase: {1} in application: {2}"), 
            input.Text, 
            phraseId, 
            applicationId);

        var phrase = await Phrases.Where(x => x.Id == phraseId).FirstOrDefaultAsync();

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

    public async Task<List<Result>> ProcessTranslationsForApplicationAsync(Guid applicationId)
    {
        _logger.LogInformation(GetLogMessage("Processing Translations for application: {0}"), applicationId);

        var results = new List<Result>();

        //var pendingTranslations = await GetPendingTranslationsForApplicationAsync(applicationId);

        //var application = await _applicationRepository.FindAsync(applicationId);

        //foreach (var langKeyValue in pendingTranslations)
        //{
        //    var texts = langKeyValue.Value.Select(x => x.ToString()).ToList();
        //    var translations = await _googleClient.TranslateTextAsync(texts, langKeyValue.Key);
        //    var result = await SaveTranslationResultsAsync(application.Id, translations.ToList());
        //    results.Add(result);
        //}

        return results;
    }

    public async Task<Result> ProcessTranslationsForApplicationLanguageAsync(Guid applicationId, string languageId)
    {
        throw new NotImplementedException();
        //_logger.LogInformation(GetLogMessage("Processing Translations for application: {0} and language: {1}"), applicationId, languageId);

        //var missingTranslations = await GetPendingTranslationsForLanguageAsync(applicationId, languageId);
        //var translations = await _googleClient.TranslateTextAsync(missingTranslations, languageId);

        //return await SaveTranslationResultsAsync(applicationId, translations.ToList());
    }


    private async Task<Dictionary<string, List<string>>> GetPendingTranslationsForApplicationAsync(Guid applicationId)
    {
        throw new NotImplementedException();
    }

    private async Task<List<string>> GetPendingTranslationsForLanguageAsync(Guid applicationId, string languageId)
    {
        throw new NotImplementedException();
    }

    private async Task<Result> SaveTranslationResultsAsync(ICollection<TranslationResult> input)
    {
        _logger.LogInformation(GetLogMessage("Saving {0} translations"), input.Count);

        throw new NotImplementedException();
        //var translations = await Translations
        //    .Where(x => x.ApplicationId == applicationId && x.TranslationDate == null && x.Text == null)
        //    .ToListAsync();

        //foreach (var tran in input)
        //{
        //    var translation =
        //        translations
        //            .FirstOrDefault(x => x.ApplicationPhrase.Phrase.Text == tran.OriginalText && x.LanguageId == tran.TargetLanguage);

        //    if (translation == null) continue;

        //    translation.Text = tran.TranslatedText;
        //    translation.TranslationDate = DateTime.UtcNow;
        //    translation.EngineId = TranslationEngine.Google;;
        //    translation.ObjectState = ObjectState.Modified;

        //    Repository.InsertOrUpdateGraph(translation);
        //}

        //var records = Repository.Commit();

        //_logger.LogInformation(GetLogMessage("{0} translations saved to application: {1}"), records, applicationId);

        //return Result.Success(records);
    }
}