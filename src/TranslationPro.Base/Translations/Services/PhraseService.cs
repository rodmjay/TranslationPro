using System;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using TranslationPro.Base.Applications.Entities;
using TranslationPro.Base.Common.Data.Enums;
using TranslationPro.Base.Common.Data.Interfaces;
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


    public Task<T> GetPhrasesAsync<T>(Guid applicationId) where T : PhraseDto
    {
        throw new NotImplementedException();
    }

    public async Task<Result> CreatePhraseAsync(Guid applicationId, CreatePhraseDto input)
    {
        var translationId = await GetNextPhraseIdAsync(applicationId);

        var phrase = new Phrase
        {
            Id = translationId,
            ObjectState = ObjectState.Added
        };

        var application = await Applications.Where(x => x.Id == applicationId).FirstOrDefaultAsync();

        // add empty translation for each supported language... these will get translated by ChatGPT
        foreach (var lang in application.Languages)
        {
            phrase.Translations.Add(new Translation()
            {
                LanguageId = lang.LanguageId,
                ApplicationId = lang.ApplicationId,
                PhraseId = translationId,
                ObjectState = ObjectState.Added
            });
        }

        throw new NotImplementedException();
    }

    public Task<Result> UpdatePhraseAsync(Guid applicationId, int phraseId, UpdatePhraseDto input)
    {
        throw new NotImplementedException();
    }
    
    public Task<Result> DeletePhraseAsync(Guid applicationId, int phraseId)
    {
        throw new NotImplementedException();
    }


    private Task<int> GetNextPhraseIdAsync(Guid applicationId)
    {
        throw new NotImplementedException();
    }
    
}