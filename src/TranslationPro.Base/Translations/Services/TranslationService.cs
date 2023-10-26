#region Header Info

// Copyright 2023 Rod Johnson.  All rights reserved

#endregion

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper.QueryableExtensions;
using Google.Cloud.Translation.V2;
using Microsoft.EntityFrameworkCore;
using TranslationPro.Base.Applications.Entities;
using TranslationPro.Base.Common.Data.Enums;
using TranslationPro.Base.Common.Data.Interfaces;
using TranslationPro.Base.Common.Models;
using TranslationPro.Base.Common.Services.Bases;
using TranslationPro.Base.Phrases.Entities;
using TranslationPro.Base.Phrases.Models;
using TranslationPro.Base.Translations.Entities;
using TranslationPro.Base.Translations.Interfaces;
using TranslationPro.Base.Translations.Models;

namespace TranslationPro.Base.Translations.Services;

public class TranslationService : BaseService<Translation>, ITranslationService
{
    private readonly IRepositoryAsync<Application> _applicationRepository;
    private readonly PhraseErrorDescriber _phraseErrors;
    private readonly TranslationClient _googleClient;
    private readonly IRepositoryAsync<Phrase> _phraseRepository;
    private readonly TranslationErrorDescriber _translationErrors;

    public TranslationService(IServiceProvider serviceProvider, TranslationErrorDescriber translationErrors,
        PhraseErrorDescriber phraseErrors, TranslationClient googleClient) : base(serviceProvider)
    {
        _translationErrors = translationErrors;
        _phraseErrors = phraseErrors;
        _googleClient = googleClient;
        _applicationRepository = UnitOfWork.RepositoryAsync<Application>();
        _phraseRepository = UnitOfWork.RepositoryAsync<Phrase>();
    }

    private IQueryable<Translation> Translations =>
        Repository.Queryable().Include(x => x.Phrase).Include(x => x.Application);

    private IQueryable<Phrase> Phrases =>
        _phraseRepository.Queryable().Include(x => x.Application).ThenInclude(x=>x.Languages).Include(x => x.Translations);

    private IQueryable<Application> Applications => _applicationRepository.Queryable().Include(x => x.Languages);
    
    public async Task<Result> SaveTranslation(Guid applicationId, int phraseId, TranslationInput input)
    {
        var phrase = await Phrases.Where(x => x.Id == phraseId).FirstOrDefaultAsync();

        if (phrase == null)
            return Result.Failed(_phraseErrors.PhraseDoesntExist(phraseId));

        var translation = phrase.Translations.FirstOrDefault(x => x.LanguageId == input.LanguageId);
        if (translation == null)
        {
            var application = await Applications.Where(x => x.Id == applicationId).FirstOrDefaultAsync();

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
        where T : TranslationDto
    {
        return Translations.Where(x => x.ApplicationId == applicationId && x.LanguageId == languageId)
            .ProjectTo<T>(ProjectionMapping).ToListAsync();
    }

    private async Task<Dictionary<string, List<string>>>
        GetPendingTranslationsForApplicationAsync(Guid applicationId)
    {
        var translations = await Translations
            .Where(x => x.ApplicationId == applicationId && x.TranslationDate == null && x.Text == null).ToListAsync();

        var dictionary = translations.GroupBy(a => a.LanguageId)
                .ToDictionary(group => group.Key, group => group
                    .Select(translation => translation.Phrase.Text).ToList());

        return dictionary;
    }

    private async Task<List<string>> GetPendingTranslationsForPhraseAsync(Guid applicationId, int phraseId)
    {
        var translations = await Translations
            .Where(x => x.ApplicationId == applicationId && x.PhraseId == phraseId && x.TranslationDate == null && x.Text == null).ToListAsync();

        return translations.Select(x => x.Phrase.Text).ToList();
    }

    private async Task<List<string>> GetPendingTranslationsForLanguageAsync(Guid applicationId, string languageId)
    {
        var translations = await Translations
            .Where(x => x.ApplicationId == applicationId && x.LanguageId == languageId && x.TranslationDate == null && x.Text == null).ToListAsync();

        return translations.Select(x => x.Phrase.Text).ToList();
    }

    private async Task<Result> SaveTranslationResultsAsync(Guid applicationId, List<TranslationResult> input)
    {
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
        return Result.Success(records);
    }

    public async Task<List<Result>> ProcessTranslationsForApplicationAsync(Guid applicationId)
    {
        var results = new List<Result>();

        var pendingTranslations = await GetPendingTranslationsForApplicationAsync(applicationId);

        var application = await _applicationRepository.FirstOrDefaultAsync(x => x.Id == applicationId);

        foreach (var langKeyValue in pendingTranslations)
        {
            var texts = langKeyValue.Value.Select(x => x.ToString()).ToList();
            var translations = await _googleClient.TranslateTextAsync(texts, langKeyValue.Key);
            var result = await SaveTranslationResultsAsync(application.Id, translations.ToList());
            results.Add(result);
        }

        return results;
    }

    public async Task<List<Result>> ProcessTranslationsForApplicationLanguageAsync(Guid applicationId, string languageId)
    {
        var results = new List<Result>();
        
        var missingTranslations = await GetPendingTranslationsForLanguageAsync(applicationId, languageId);
        var translations = await _googleClient.TranslateTextAsync(missingTranslations, languageId);
        var result = await SaveTranslationResultsAsync(applicationId, translations.ToList());

        results.Add(result);

        return results;
    }
    
}