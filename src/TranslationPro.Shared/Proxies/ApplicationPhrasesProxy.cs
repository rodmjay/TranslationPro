using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using TranslationPro.Shared.Common;
using TranslationPro.Shared.Filters;
using TranslationPro.Shared.Helpers;
using TranslationPro.Shared.Interfaces;
using TranslationPro.Shared.Models;

namespace TranslationPro.Shared.Proxies;

public class ApplicationPhrasesProxy : BaseProxy, IApplicationPhrasesController
{

    public Task<ApplicationPhraseDetails> GetPhraseAsync(Guid applicationId, int phraseId)
    {
        return DoGet<ApplicationPhraseDetails>($"{ApplicationUrl}/{applicationId}/phrases/{phraseId}");
    }

    public Task<List<ApplicationPhraseDetails>> CreatePhrasesAsync(Guid applicationId, ApplicationPhrasesCreateOptions input)
    {
        return DoPost<ApplicationPhrasesCreateOptions, List<ApplicationPhraseDetails>>($"{ApplicationUrl}/{applicationId}/phrases", input);
    }

    public Task<Result> ProcessPending(Guid applicationId)
    {
        return DoPost<Result>($"{ApplicationUrl}/{applicationId}/phrases/process");
    }

    public Task<Result> UpdatePhraseAsync(Guid applicationId, int phraseId, ApplicationPhrasesCreateOptions input)
    {
        return DoPut<ApplicationPhrasesCreateOptions, Result>($"{ApplicationUrl}/{applicationId}/phrases/{phraseId}", input);
    }

    public Task<PagedList<ApplicationPhraseOutput>> GetPhrasesAsync(Guid applicationId, PagingQuery paging, PhraseFilters filters)
    {
        var querystring = UrlHelper.CombineObjectsToUrl(paging, filters);
        return DoGet<PagedList<ApplicationPhraseOutput>>($"{ApplicationUrl}/{applicationId}/phrases?{querystring}");
    }

    public Task<Dictionary<int, string>> GetPhrasesForApplicationAndLanguageAsync(Guid applicationId, string language)
    {
        return DoGet<Dictionary<int, string>>($"{ApplicationUrl}/{applicationId}/phrases/{language}");

    }

    public Task<Result> DeletePhraseAsync(Guid applicationId, int phraseId)
    {
        return DoDelete<Result>($"{ApplicationUrl}/{applicationId}/phrases/{phraseId}");
    }


    public ApplicationPhrasesProxy(HttpClient httpClient) : base(httpClient)
    {
    }
}