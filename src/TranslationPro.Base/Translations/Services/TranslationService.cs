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
using TranslationPro.Base.Permissions.Services;
using TranslationPro.Base.Phrases;
using TranslationPro.Base.Phrases.Entities;
using TranslationPro.Base.Translations.Entities;
using TranslationPro.Base.Translations.Interfaces;
using TranslationPro.Shared.Common;
using TranslationPro.Shared.Models;

namespace TranslationPro.Base.Translations.Services;

public class TranslationService : BaseService<Translation>, ITranslationService
{
    private static string GetLogMessage(string message, [CallerMemberName] string callerName = null)
    {
        return $"[{nameof(TranslationService)}.{callerName}] - {message}";
    }

    private readonly IRepositoryAsync<Application> _applicationRepository;
    private readonly PhraseErrorDescriber _phraseErrors;
    private readonly TranslationClient _googleClient;
    private readonly ILogger<TranslationService> _logger;
    private readonly IRepositoryAsync<Phrase> _phraseRepository;
    private readonly TranslationErrorDescriber _translationErrors;

    public TranslationService(IServiceProvider serviceProvider, TranslationErrorDescriber translationErrors,
        PhraseErrorDescriber phraseErrors, TranslationClient googleClient, ILogger<TranslationService> logger) : base(serviceProvider)
    {
        _translationErrors = translationErrors;
        _phraseErrors = phraseErrors;
        _googleClient = googleClient;
        _logger = logger;
        _applicationRepository = UnitOfWork.RepositoryAsync<Application>();
        _phraseRepository = UnitOfWork.RepositoryAsync<Phrase>();
    }

    private IQueryable<Translation> Translations =>
        Repository.Queryable().Include(x => x.Phrase).Include(x => x.Application);

    private IQueryable<Phrase> Phrases =>
        _phraseRepository.Queryable().Include(x => x.Application).ThenInclude(x=>x.Languages).Include(x => x.Translations);

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

        var translation = phrase.Translations.FirstOrDefault(x => x.LanguageId == input.LanguageId);
        if (translation == null)
        {
            var application = await Applications.Where(x => x.Id == applicationId).FirstAsync();

            var langExists = application.Languages.Any(x => x.LanguageId == input.LanguageId);

            if (!langExists)
                return Result.Failed(
                    _translationErrors.LanguageDoesntExistInApplication(input.LanguageId, phrase.Application.Name));

            translation = new Translation
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
        translation.TranslationDate = DateTime.UtcNow;

        var records = Repository.InsertOrUpdateGraph(translation, true);
        if (records > 0)
            return Result.Success();

        return Result.Failed(_translationErrors.UnableToUpdateTranslation(input.Text));
    }

    public async Task<Result> DeleteTranslation(Guid applicationId, int phraseId, string languageId)
    {
        var succeeded = await Repository.DeleteAsync(x =>
            x.ApplicationId == applicationId && x.PhraseId == phraseId && x.LanguageId == languageId);

        return succeeded ? Result.Success() : Result.Failed();
    }

    public Task<List<T>> GetTranslationsForApplicationForLanguage<T>(Guid applicationId, string languageId)
        where T : TranslationOutput
    {
        return Translations.Where(x => x.ApplicationId == applicationId && x.LanguageId == languageId)
            .ProjectTo<T>(ProjectionMapping).ToListAsync();
    }


    public async Task<List<Result>> ProcessTranslationsForApplicationAsync(Guid applicationId)
    {
        _logger.LogInformation(GetLogMessage("Processing Translations for application: {0}"), applicationId);

        var results = new List<Result>();

        var pendingTranslations = await GetPendingTranslationsForApplicationAsync(applicationId);

        var application = await _applicationRepository.FindAsync(applicationId);

        foreach (var langKeyValue in pendingTranslations)
        {
            var texts = langKeyValue.Value.Select(x => x.ToString()).ToList();
            var translations = await _googleClient.TranslateTextAsync(texts, langKeyValue.Key);
            var result = await SaveTranslationResultsAsync(application.Id, translations.ToList());
            results.Add(result);
        }

        return results;
    }

    public async Task<Result> ProcessTranslationsForApplicationLanguageAsync(Guid applicationId, string languageId)
    {
        _logger.LogInformation(GetLogMessage("Processing Translations for application: {0} and language: {1}"), applicationId, languageId);
        
        var missingTranslations = await GetPendingTranslationsForLanguageAsync(applicationId, languageId);
        var translations = await _googleClient.TranslateTextAsync(missingTranslations, languageId);
   
        return await SaveTranslationResultsAsync(applicationId, translations.ToList());
    }


    private async Task<Dictionary<string, List<string>>> GetPendingTranslationsForApplicationAsync(Guid applicationId)
    {
        var translations = await Translations
            .Where(x => x.ApplicationId == applicationId && x.TranslationDate == null && x.Text == null).ToListAsync();

        var dictionary = translations.GroupBy(a => a.LanguageId)
            .ToDictionary(group => group.Key, group => group
                .Select(translation => translation.Phrase.Text).ToList());

        return dictionary;
    }

    private async Task<List<string>> GetPendingTranslationsForLanguageAsync(Guid applicationId, string languageId)
    {
        var translations = await Translations
            .Where(x => x.ApplicationId == applicationId && x.LanguageId == languageId && x.TranslationDate == null && x.Text == null).ToListAsync();

        return translations.Select(x => x.Phrase.Text).ToList();
    }

    private async Task<Result> SaveTranslationResultsAsync(Guid applicationId, List<TranslationResult> input)
    {
        _logger.LogInformation(GetLogMessage("Saving {0} translations to application: {1}"), input.Count, applicationId);

        var translations = await Translations
            .Where(x => x.ApplicationId == applicationId && x.TranslationDate == null && x.Text == null)
            .ToListAsync();

        foreach (var tran in input)
        {
            var translation =
                translations
                    .FirstOrDefault(x => x.Phrase.Text == tran.OriginalText && x.LanguageId == tran.TargetLanguage);

            if (translation == null) continue;

            translation.Text = tran.TranslatedText;
            translation.TranslationDate = DateTime.UtcNow;
            translation.ObjectState = ObjectState.Modified;

            Repository.InsertOrUpdateGraph(translation);
        }

        var records = Repository.Commit();

        _logger.LogInformation(GetLogMessage("{0} translations saved to application: {1}"), records, applicationId);

        return Result.Success(records);
    }
}