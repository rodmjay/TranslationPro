using System;
using System.Threading.Tasks;
using TranslationPro.Base.Common.Models;
using TranslationPro.Base.Common.Services.Interfaces;
using TranslationPro.Base.Translations.Entities;
using TranslationPro.Base.Translations.Models;

namespace TranslationPro.Base.Translations.Interfaces;

public interface IPhraseService : IService<Phrase>
{
    Task<T> GetPhrases<T>(Guid applicationId) where T : PhraseDto;
    Task<Result> CreatePhrase(Guid applicationId, CreatePhraseDto input);
    Task<Result> UpdatePhrase(Guid applicationId, int phraseId, UpdatePhraseDto input);
    Task<Result> DeletePhrase(Guid applicationId, int translationId);
}