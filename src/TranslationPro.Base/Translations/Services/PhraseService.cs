using System;
using System.Threading.Tasks;
using TranslationPro.Base.Common.Models;
using TranslationPro.Base.Common.Services.Bases;
using TranslationPro.Base.Common.Services.Interfaces;
using TranslationPro.Base.Translations.Entities;
using TranslationPro.Base.Translations.Interfaces;
using TranslationPro.Base.Translations.Models;

namespace TranslationPro.Base.Translations.Services;

public class PhraseService : BaseService<Phrase>, IPhraseService
{
    public PhraseService(IServiceProvider serviceProvider) : base(serviceProvider)
    {
    }

    public Task<T> GetPhrases<T>(Guid applicationId) where T : PhraseDto
    {
        throw new NotImplementedException();
    }

    public Task<Result> CreatePhrase(Guid applicationId, CreatePhraseDto input)
    {
        throw new NotImplementedException();
    }

    public Task<Result> UpdatePhrase(Guid applicationId, int phraseId, UpdatePhraseDto input)
    {
        throw new NotImplementedException();
    }
    

    public Task<Result> DeletePhrase(Guid applicationId, int translationId)
    {
        throw new NotImplementedException();
    }
}