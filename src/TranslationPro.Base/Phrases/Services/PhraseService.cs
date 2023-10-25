using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using TranslationPro.Base.Applications.Entities;
using TranslationPro.Base.Common.Data.Enums;
using TranslationPro.Base.Common.Data.Interfaces;
using TranslationPro.Base.Common.Extensions;
using TranslationPro.Base.Common.Models;
using TranslationPro.Base.Common.Services.Bases;
using TranslationPro.Base.Phrases.Entities;
using TranslationPro.Base.Phrases.Extensions;
using TranslationPro.Base.Phrases.Interfaces;
using TranslationPro.Base.Phrases.Models;
using TranslationPro.Base.Translations.Entities;

namespace TranslationPro.Base.Phrases.Services;

public class PhraseService : BaseService<Phrase>, IPhraseService
{
    private readonly IRepositoryAsync<Application> _applicationRepository;
    private readonly PhraseErrorDescriber _errorDescriber;

    public PhraseService(IServiceProvider serviceProvider, PhraseErrorDescriber errorDescriber) : base(serviceProvider)
    {
        _errorDescriber = errorDescriber;
        _applicationRepository = UnitOfWork.RepositoryAsync<Application>();
    }

    private IQueryable<Application> Applications => _applicationRepository.Queryable().Include(x => x.Languages);
    private IQueryable<Phrase> Phrases => Repository.Queryable().Include(x => x.Translations);

    public Task<PagedList<T>> GetPhrasesForApplicationAsync<T>(Guid applicationId, PagingQuery paging,
        PhraseFilters filters) where T : PhraseDto
    {
        return this.PaginateAsync<Phrase, T>(x => x.ApplicationId == applicationId, filters.GetExpression(), paging);
    }

    public async Task<Dictionary<int, string>> GetApplicationPhraseList(Guid applicationId, string language)
    {
        var phrases = await Phrases.Include(x => x.Translations.Where(t => t.LanguageId == language))
            .Where(x => x.ApplicationId == applicationId).ToListAsync();

        return phrases.SelectMany(x => x.Translations).ToDictionary(x => x.PhraseId, x => x.Text);
    }

    public async Task<Result> BulkUploadPhrases(Guid applicationId, List<string> inputs)
    {
        var phrases = Phrases.Where(x => x.ApplicationId == applicationId).ToList();

        foreach (var input in inputs)
        {
            var existing = phrases
                .FirstOrDefault(x => x.ApplicationId == applicationId && x.Text == input);

            if (existing != null) continue;

            var phraseId = await GetNextPhraseIdAsync(applicationId);

            var phrase = new Phrase
            {
                Id = phraseId,
                Text = input,
                ApplicationId = applicationId,
                ObjectState = ObjectState.Added
            };

            var application = await Applications.Where(x => x.Id == applicationId).FirstOrDefaultAsync();

            foreach (var lang in application.Languages)
                phrase.Translations.Add(new Translation
                {
                    LanguageId = lang.LanguageId,
                    ApplicationId = applicationId,
                    PhraseId = phraseId,
                    ObjectState = ObjectState.Added
                });
        }

        var records = Repository.Commit();

        return Result.Success(records);
    }


    public async Task<Result> CreatePhraseAsync(Guid applicationId, PhraseInput input)
    {
        // does phrase already exist?
        var existing = await Phrases.Where(x => x.ApplicationId == applicationId && x.Text == input.Text)
            .FirstOrDefaultAsync();

        if (existing != null)
            return Result.Success(existing.Id);

        // create new phrase with id specific to application
        var phraseId = await GetNextPhraseIdAsync(applicationId);

        var phrase = new Phrase
        {
            Id = phraseId,
            Text = input.Text,
            ApplicationId = applicationId,
            ObjectState = ObjectState.Added
        };

        var application = await Applications.Where(x => x.Id == applicationId).FirstOrDefaultAsync();

        // add empty translation for each supported language... these will get translated by ChatGPT
        foreach (var lang in application.Languages)
            phrase.Translations.Add(new Translation
            {
                LanguageId = lang.LanguageId,
                ApplicationId = applicationId,
                PhraseId = phraseId,
                ObjectState = ObjectState.Added
            });

        // save to database
        var records = Repository.InsertOrUpdateGraph(phrase, true);
        if (records > 0)
            return Result.Success(phrase.Id);

        return Result.Failed(_errorDescriber.UnableToCreatePhrase());
    }

    public async Task<Result> UpdatePhraseAsync(Guid applicationId, int phraseId, PhraseInput input)
    {
        var existing = await Phrases.Where(x => x.ApplicationId == applicationId && x.Id == phraseId)
            .FirstOrDefaultAsync();

        // error if phrase doesn't exist
        if (existing == null)
            return Result.Failed(_errorDescriber.PhraseDoesntExist(phraseId));

        // skip if the text is the same
        if (existing.Text == input.Text)
            return Result.Success(phraseId);

        existing.Text = input.Text;
        existing.ObjectState = ObjectState.Modified;

        // re-translate if the text is different
        foreach (var translation in existing.Translations)
        {
            translation.Text = null;
            translation.TranslationDate = null;
            translation.ObjectState = ObjectState.Modified;
        }

        var records = Repository.InsertOrUpdateGraph(existing, true);
        if (records > 0)
            return Result.Success(phraseId);

        return Result.Failed(_errorDescriber.UnableToUpdatePhrase(phraseId));
    }

    public async Task<Result> DeletePhraseAsync(Guid applicationId, int phraseId)
    {
        var phrase = await Phrases.Where(x => x.Id == phraseId).FirstOrDefaultAsync().ConfigureAwait(false);

        if (phrase == null)
            return Result.Failed(_errorDescriber.PhraseDoesntExist(phraseId));

        var records = Repository.Delete(phrase, true);

        if (records > 0)
            return Result.Success();

        return Result.Failed(_errorDescriber.UnableToDeletePhrase(phraseId));
    }


    private async Task<int> GetNextPhraseIdAsync(Guid applicationId)
    {
        var lastPhrase = await Phrases.Where(x => x.ApplicationId == applicationId).OrderByDescending(x => x.Id)
            .FirstOrDefaultAsync().ConfigureAwait(false);

        if (lastPhrase == null)
            return 10000;

        return lastPhrase.Id + 1;
    }
}