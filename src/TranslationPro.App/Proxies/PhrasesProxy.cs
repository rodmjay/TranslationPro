﻿using TranslationPro.Shared.Common;
using TranslationPro.Shared.Controllers;
using TranslationPro.Shared.Phrases;

namespace TranslationPro.App.Proxies;

public class PhrasesProxy : BaseProxy, IPhrasesController
{

    public Task<PhraseDto> GetPhraseAsync(Guid applicationId, int phraseId)
    {
        return DoGet<PhraseDto>($"{ApplicationUrl}/{applicationId}/phrases/{phraseId}");
    }

    public Task<Result> BulkUploadAsync(Guid applicationId, List<string> input)
    {
        return DoPost<List<string>, Result>($"{ApplicationUrl}/{applicationId}/phrases/bulk", input);
    }

    public Task<Result> CreatePhraseAsync(Guid applicationId, PhraseInput input)
    {
        return DoPost<PhraseInput, Result>($"{ApplicationUrl}/{applicationId}/phrases", input);
    }

    public Task<Result> UpdatePhraseAsync(Guid applicationId, int phraseId, PhraseInput input)
    {
        return DoPut<PhraseInput, Result>($"{ApplicationUrl}/{applicationId}/phrases/{phraseId}", input);
    }

    public Task<PagedList<PhraseDto>> GetPhrasesAsync(Guid applicationId, PagingQuery paging, PhraseFilters filters)
    {
        return DoGet<PagedList<PhraseDto>>($"{ApplicationUrl}/{applicationId}/phrases");
    }

    public Task<Dictionary<int, string>> GetPhrasesForApplicationAndLanguageAsync(Guid applicationId, string language)
    {
        return DoGet<Dictionary<int, string>>($"{ApplicationUrl}/{applicationId}/phrases/{language}");

    }

    public Task<Result> DeletePhraseAsync(Guid applicationId, int phraseId)
    {
        return DoDelete<Result>($"{ApplicationUrl}/{applicationId}/phrases/{phraseId}");
    }
    public PhrasesProxy(HttpClient httpClient) : base(httpClient)
    {
    }
}