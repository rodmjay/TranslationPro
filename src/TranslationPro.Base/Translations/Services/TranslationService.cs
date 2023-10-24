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
    private readonly TranslationErrorDescriber _translationErrors;
    private readonly PhraseErrorDescriber _phraseErrors;
    private readonly IRepositoryAsync<Application> _applicationRepository;
    private readonly IRepositoryAsync<Phrase> _phraseRepository;

    public TranslationService(IServiceProvider serviceProvider, TranslationErrorDescriber translationErrors, PhraseErrorDescriber phraseErrors) : base(serviceProvider)
    {
        _translationErrors = translationErrors;
        _phraseErrors = phraseErrors;
        _applicationRepository = UnitOfWork.RepositoryAsync<Application>();
        _phraseRepository = UnitOfWork.RepositoryAsync<Phrase>();
    }

    private IQueryable<Translation> Translations =>
        Repository.Queryable().Include(x => x.Phrase).Include(x => x.Application);

    private IQueryable<Phrase> Phrases => _phraseRepository.Queryable().Include(x=>x.Application).Include(x => x.Translations);
    private IQueryable<Application> Applications => _applicationRepository.Queryable().Include(x => x.Languages);

    /// <summary>
    ///     Works for both create and update
    /// </summary>
    /// <param name="applicationId"></param>
    /// <param name="phraseId"></param>
    /// <param name="input"></param>
    /// <returns></returns>
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
                return Result.Failed(_translationErrors.LanguageDoesntExistInApplication(input.LanguageId, phrase.Application.Name));

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

    public Task<Result> DeleteTranslation(Guid applicationId, int phraseId, string languageId)
    {
        throw new NotImplementedException();
    }

    public Task<List<T>> GetTranslationsForLanguageAndApplicationAsync<T>(Guid applicationId, string languageId)
        where T : TranslationDto
    {
        return Translations.Where(x => x.ApplicationId == applicationId && x.LanguageId == languageId)
            .ProjectTo<T>(ProjectionMapping).ToListAsync();
    }

    public async Task<Dictionary<Guid, Dictionary<string, List<string>>>>
        GetMissingTranslationsByApplicationByLanguageAsync(Guid applicationId)
    {
        var translations = await Translations.Where(x => x.ApplicationId == applicationId && x.TranslationDate == null && x.Text == null).ToListAsync();

        var dictionary = translations.GroupBy(translation => translation.ApplicationId)
            .ToDictionary(x => x.Key, x => x.GroupBy(a => a.LanguageId)
                .ToDictionary(group => group.Key, group => group
                    .Select(translation => translation.Phrase.Text).ToList()));

        return dictionary;
    }

    public async Task<Result> SaveTranslationResultsAsync(Guid applicationId, List<TranslationResult> input)
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

        // generate your own google api key for cloud translation api and store in machine's environment variables (See readme)

        var apiKey = Environment.GetEnvironmentVariable("TranslationProGoogleApi");
        var client = TranslationClient.CreateFromApiKey(apiKey);

        // get all missing translations organized by language
        var missingTranslations = await GetMissingTranslationsByApplicationByLanguageAsync(applicationId);

        foreach (var appKeyValue in missingTranslations)
        {
            var application = await _applicationRepository.FirstOrDefaultAsync(x => x.Id == applicationId);
            if (application == null) continue;
            foreach (var langKeyValue in appKeyValue.Value)
            {
                var texts = langKeyValue.Value.Select(x => x.ToString()).ToList();
                var translations = await client.TranslateTextAsync(texts, langKeyValue.Key);
                var result = await SaveTranslationResultsAsync(application.Id, translations.ToList());
                results.Add(result);
            }
        }

        return results;
    }
}