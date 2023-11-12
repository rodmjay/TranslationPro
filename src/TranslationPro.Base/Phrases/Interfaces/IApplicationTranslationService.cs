using System;
using System.Threading.Tasks;
using TranslationPro.Base.Common.Services.Interfaces;
using TranslationPro.Base.Phrases.Entities;
using TranslationPro.Shared.Common;

namespace TranslationPro.Base.Phrases.Interfaces;

public interface IApplicationTranslationService : IService<ApplicationTranslation>
{
    Task<Result> CopyTranslationFromPhraseList(Guid applicationId, int phraseId);

    Task<Result> CopyTranslationsFromLanguage(Guid applicationId, string languageId);
}