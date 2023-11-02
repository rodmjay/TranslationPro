#region Header Info

// Copyright 2023 Rod Johnson.  All rights reserved

#endregion

using TranslationPro.Shared.Common;
using TranslationPro.Shared.Phrases;

namespace TranslationPro.Shared.Controllers;

public interface IPhrasesController
{

    Task<PhraseDto> GetPhraseAsync(Guid applicationId, int phraseId);

    Task<Result> BulkUploadAsync(Guid applicationId,
         List<string> input);

    Task<Result> CreatePhraseAsync(Guid applicationId,
        PhraseInput input);

    Task<Result> UpdatePhraseAsync(Guid applicationId, int phraseId,
        PhraseInput input);

    Task<PagedList<PhraseDto>> GetPhrasesAsync(Guid applicationId, PagingQuery paging,
         PhraseFilters filters);

    Task<Dictionary<int, string>> GetPhrasesForApplicationAndLanguageAsync(Guid applicationId,
        string language);

    Task<Result> DeletePhraseAsync(Guid applicationId, int phraseId);
}