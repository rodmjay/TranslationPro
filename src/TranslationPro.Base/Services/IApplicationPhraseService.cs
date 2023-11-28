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
    Task<string[]> GetPhrasesWithPendingTranslation(Guid applicationId);
    Task<string[]> GetPhraseTextsForApplication(Guid applicationId);

    Task<PagedList<T>> GetPhrasesForApplicationAsync<T>(Guid applicationId, PagingQuery query, PhraseFilters filters)
        where T : ApplicationPhraseOutput;

    Task<T> GetPhraseAsync<T>(Guid applicationId, int phraseId) where T : ApplicationPhraseOutput;
    Task<List<T>> GetPhrasesAsync<T>(Guid applicationId, string[] phrases) where T : ApplicationPhraseOutput;
    Task<Result> DeletePhraseAsync(Guid applicationId, int phraseId);
    Task<EnsurePhrasesResult> ScaffoldPhrases(Guid applicationId, string[] phrases);
}