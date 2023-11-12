﻿#region Header Info

// Copyright 2023 Rod Johnson.  All rights reserved

#endregion

using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.Build.ObjectModelRemoting;
using TranslationPro.Base.Common.Services.Interfaces;
using TranslationPro.Base.Phrases.Entities;
using TranslationPro.Shared.Common;
using TranslationPro.Shared.Filters;
using TranslationPro.Shared.Models;

namespace TranslationPro.Base.Phrases.Interfaces;

public interface IApplicationPhraseService : IService<ApplicationPhrase>
{
    Task<PagedList<T>> GetPhrasesForApplicationAsync<T>(Guid applicationId, PagingQuery query, PhraseFilters filters)
        where T : ApplicationPhraseOutput;

    Task<T> GetPhraseAsync<T>(Guid applicationId, int phraseId) where T : ApplicationPhraseOutput;
    //Task<Result> BulkUploadPhrases(Guid applicationId, List<string> phrases);
    Task<Result> CreateApplicationPhrase(Guid applicationId, PhraseOptions input);
    Task<Result> DeletePhraseAsync(Guid applicationId, int phraseId);
    Task<Dictionary<int, string>> GetApplicationPhraseList(Guid applicationId, string language);

    Task<Result> ReplaceTranslation(Guid applicationId, int phraseId, TranslationReplacementOptions input); 
}