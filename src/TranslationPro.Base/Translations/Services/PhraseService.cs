using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper.QueryableExtensions;
using Microsoft.EntityFrameworkCore;
using TranslationPro.Base.Applications.Entities;
using TranslationPro.Base.Common.Data.Enums;
using TranslationPro.Base.Common.Data.Interfaces;
using TranslationPro.Base.Common.Extensions;
using TranslationPro.Base.Common.Models;
using TranslationPro.Base.Common.Services.Bases;
using TranslationPro.Base.Translations.Entities;
using TranslationPro.Base.Translations.Interfaces;
using TranslationPro.Base.Translations.Models;

namespace TranslationPro.Base.Translations.Services;

public class PhraseService : BaseService<Phrase>, IPhraseService
{
    private readonly IRepositoryAsync<Application> _applicationRepository;

    public PhraseService(IServiceProvider serviceProvider) : base(serviceProvider)
    {
        _applicationRepository = UnitOfWork.RepositoryAsync<Application>();
    }

    private IQueryable<Application> Applications => _applicationRepository.Queryable().Include(x => x.Languages);
    private IQueryable<Phrase> Phrases => Repository.Queryable();
    
    public Task<PagedList<T>> GetPhrasesForApplicationAsync<T>(Guid applicationId, PagingQuery paging) where T : PhraseDto
    {
        return this.PaginateAsync<Phrase, T>(x => x.ApplicationId == applicationId, paging);
    }

    public async Task<Result> CreatePhraseAsync(Guid applicationId, CreatePhraseDto input)
    {
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
        {
            phrase.Translations.Add(new Translation()
            {
                LanguageId = lang.LanguageId,
                ApplicationId = applicationId,
                PhraseId = phraseId,
                ObjectState = ObjectState.Added
            });
        }

        var records = Repository.InsertOrUpdateGraph(phrase, true);
        if (records > 0)
            return Result.Success(phrase.Id);

        return Result.Failed();
    }

    public Task<Result> UpdatePhraseAsync(Guid applicationId, int phraseId, UpdatePhraseDto input)
    {
        throw new NotImplementedException();
    }
    
    public Task<Result> DeletePhraseAsync(Guid applicationId, int phraseId)
    {
        throw new NotImplementedException();
    }


    private async Task<int> GetNextPhraseIdAsync(Guid applicationId)
    {
        var lastPhrase = await Phrases.Where(x=>x.ApplicationId == applicationId).OrderByDescending(x=>x.Id)
            .FirstOrDefaultAsync().ConfigureAwait(false);

        if (lastPhrase == null)
            return 10000;

        return lastPhrase.Id + 1;
    }
    
}