using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using TranslationPro.Base.Common.Services.Interfaces;
using TranslationPro.Base.Entities;
using TranslationPro.Shared.Common;
using TranslationPro.Shared.Models;

namespace TranslationPro.Base.Services;

public interface IApplicationTranslationService : IService<ApplicationTranslation>
{
    Task<List<ApplicationTranslation>> GetPendingTranslations(Guid applicationId, int[] phraseIds);

    Task<Result> AddTranslationsForLanguage(Guid applicationId, string languageId);

    Task<PagedList<T>> GetTranslationsForApplicationForLanguage<T>(Guid applicationId, string languageId,
        PagingQuery paging) where T : ApplicationTranslationOutput;

    Task<int> CopyTranslationFromPhraseList(Guid applicationId, int phraseId);
    Task<int> CopyTranslationsFromLanguage(Guid applicationId, string languageId);
    Task<Result> ReplaceTranslation(Guid applicationId, int phraseId, TranslationReplacementOptions input);

}