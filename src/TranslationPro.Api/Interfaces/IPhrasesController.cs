#region Header Info

// Copyright 2023 Rod Johnson.  All rights reserved

#endregion

using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using TranslationPro.Base.Common.Models;
using TranslationPro.Base.Phrases.Models;

namespace TranslationPro.Api.Interfaces;

public interface IPhrasesController
{
    Task<Result> BulkUpload(Guid applicationId,
        [FromBody] List<string> input);

    Task<Result> CreatePhrase(Guid applicationId,
        [FromBody] PhraseInput input);

    Task<Result> UpdatePhrase(Guid applicationId, int phraseId,
        [FromBody] PhraseInput input);

    Task<PagedList<PhraseDto>> GetPhrases(Guid applicationId, PagingQuery paging,
        [FromQuery] PhraseFilters filters);

    Task<Dictionary<int, string>> GetPhrasesForApplicationAndLanguage(Guid applicationId,
        string language);

    Task<Result> DeletePhrase(Guid applicationId, int phraseId);
}