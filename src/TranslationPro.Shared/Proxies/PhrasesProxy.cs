﻿using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using TranslationPro.Shared.Common;
using TranslationPro.Shared.Filters;
using TranslationPro.Shared.Helpers;
using TranslationPro.Shared.Interfaces;
using TranslationPro.Shared.Models;
using TranslationPro.Shared.Results;

namespace TranslationPro.Shared.Proxies;

public class PhrasesProxy : BaseProxy, IPhrasesController
{

    public Task<ApplicationPhraseDetails> GetPhraseAsync(Guid applicationId, int phraseId)
    {
        return DoGet<ApplicationPhraseDetails>($"{ApplicationUrl}/{applicationId}/phrases/{phraseId}");
    }

    public Task<ApplicationPhraseCreateResult> CreatePhraseAsync(Guid applicationId, PhraseOptions input)
    {
        return DoPost<PhraseOptions, ApplicationPhraseCreateResult>($"{ApplicationUrl}/{applicationId}/phrases", input);
    }

    public Task<Result> UpdatePhraseAsync(Guid applicationId, int phraseId, PhraseOptions input)
    {
        return DoPut<PhraseOptions, Result>($"{ApplicationUrl}/{applicationId}/phrases/{phraseId}", input);
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


    public PhrasesProxy(HttpClient httpClient) : base(httpClient)
    {
    }
}