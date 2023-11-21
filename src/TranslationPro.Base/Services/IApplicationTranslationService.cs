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
    Task<List<ApplicationTranslation>> GetPendingTranslations(Guid applicationId, int[] phraseIds, string[] languageIds);

    Task<Result> AddTranslationsForLanguage(Guid applicationId, string languageId);

    Task<PagedList<T>> GetTranslationsForApplicationForLanguage<T>(Guid applicationId, string languageId,
        PagingQuery paging) where T : ApplicationTranslationOutput;

    Task<Result> ReplaceTranslation(Guid applicationId, int phraseId, TranslationReplacementOptions input);

    Task ScaffoldTranslations(Guid applicationId, int[] phraseIds, string[] languageIds);
    Task<Dictionary<int, string>> GetApplicationPhraseList(Guid applicationId, string language);
}