#region Header Info

// Copyright 2023 Rod Johnson.  All rights reserved

#endregion

using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using TranslationPro.Shared.Common;
using TranslationPro.Shared.Filters;
using TranslationPro.Shared.Models;

namespace TranslationPro.Shared.Interfaces;

public interface IPhrasesController
{

    Task<PhraseOutput> GetPhraseAsync(Guid applicationId, int phraseId);

    //Task<Result> BulkUploadAsync(Guid applicationId,
    //     List<string> input);

    Task<Result> CreatePhraseAsync(Guid applicationId,
        PhraseOptions input);

    Task<Result> UpdatePhraseAsync(Guid applicationId, int phraseId,
        PhraseOptions input);

    Task<PagedList<PhraseOutput>> GetPhrasesAsync(Guid applicationId, PagingQuery paging,
         PhraseFilters filters);

    Task<Dictionary<int, string>> GetPhrasesForApplicationAndLanguageAsync(Guid applicationId,
        string language);

    Task<Result> DeletePhraseAsync(Guid applicationId, int phraseId);
}