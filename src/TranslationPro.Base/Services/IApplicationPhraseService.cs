#region Header Info

// Copyright 2023 Rod Johnson.  All rights reserved

#endregion

using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using TranslationPro.Base.Common.Services.Interfaces;
using TranslationPro.Base.Entities;
using TranslationPro.Shared.Common;
using TranslationPro.Shared.Filters;
using TranslationPro.Shared.Models;

namespace TranslationPro.Base.Services;

public interface IApplicationPhraseService : IService<ApplicationPhrase>
{
    Task<string[]> GetPhraseTextsForApplication(Guid applicationId);

    Task<PagedList<T>> GetPhrasesForApplicationAsync<T>(Guid applicationId, PagingQuery query, PhraseFilters filters)
        where T : ApplicationPhraseOutput;

    Task<T> GetPhraseAsync<T>(Guid applicationId, int phraseId) where T : ApplicationPhraseOutput;
    Task<T> GetPhraseAsync<T>(Guid applicationId, string phrase) where T : ApplicationPhraseOutput;
    //Task<Result> BulkUploadPhrases(Guid applicationId, List<string> phrases);
    Task<ApplicationPhrase> CreateApplicationPhrase(Guid applicationId, PhraseOptions input);
    Task<Result> SaveApplicationPhrase(ApplicationPhrase phrase);
    Task<Result> DeletePhraseAsync(Guid applicationId, int phraseId);
    Task<Dictionary<int, string>> GetApplicationPhraseList(Guid applicationId, string language);


    Task<EnsurePhrasesResult> EnsureApplicationPhrases(Guid applicationId, string[] phrases);
    Task EnsurePhrasesWithTranslations(Guid applicationId, int[] phraseIds, string[] languageIds);
}