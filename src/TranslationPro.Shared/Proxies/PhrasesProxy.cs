using TranslationPro.Shared.Common;
using TranslationPro.Shared.Filters;
using TranslationPro.Shared.Helpers;
using TranslationPro.Shared.Interfaces;
using TranslationPro.Shared.Models;

namespace TranslationPro.Shared.Proxies;

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

    public Task<Result> CreatePhraseAsync(Guid applicationId, PhraseOptions input)
    {
        return DoPost<PhraseOptions, Result>($"{ApplicationUrl}/{applicationId}/phrases", input);
    }

    public Task<Result> UpdatePhraseAsync(Guid applicationId, int phraseId, PhraseOptions input)
    {
        return DoPut<PhraseOptions, Result>($"{ApplicationUrl}/{applicationId}/phrases/{phraseId}", input);
    }

    public Task<PagedList<PhraseDto>> GetPhrasesAsync(Guid applicationId, PagingQuery paging, PhraseFilters filters)
    {
        var querystring = UrlHelper.CombineObjectsToUrl(paging, filters);
        return DoGet<PagedList<PhraseDto>>($"{ApplicationUrl}/{applicationId}/phrases?{querystring}");
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