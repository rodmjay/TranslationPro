#region Header Info

// Copyright 2023 Rod Johnson.  All rights reserved

#endregion

using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using TranslationPro.Shared.Common;
using TranslationPro.Shared.Phrases;

namespace TranslationPro.Api.Interfaces;

public interface IPhrasesController
{

    Task<PhraseDto> GetPhraseAsync(Guid applicationId, int phraseId);

    Task<Result> BulkUploadAsync(Guid applicationId,
        [FromBody] List<string> input);

    Task<Result> CreatePhraseAsync(Guid applicationId,
        [FromBody] PhraseInput input);

    Task<Result> UpdatePhraseAsync(Guid applicationId, int phraseId,
        [FromBody] PhraseInput input);

    Task<PagedList<PhraseDto>> GetPhrasesAsync(Guid applicationId, PagingQuery paging,
        [FromQuery] PhraseFilters filters);

    Task<Dictionary<int, string>> GetPhrasesForApplicationAndLanguageAsync(Guid applicationId,
        string language);

    Task<Result> DeletePhraseAsync(Guid applicationId, int phraseId);
}