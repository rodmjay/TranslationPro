#region Header Info

// Copyright 2023 Rod Johnson.  All rights reserved

#endregion

using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using TranslationPro.Shared.Extensions;
using TranslationPro.Shared.Interfaces;
using TranslationPro.Shared.Models;

namespace TranslationPro.Shared.Proxies;

public class EnginesProxy : BaseProxy, IEnginesController
{
    protected string EnginesUrl = "/v1.0/engines";
    public EnginesProxy(HttpClient httpClient) : base(httpClient)
    {
    }

    public async Task<List<EngineWithLanguagesOutput>> GetEnginesAsync()
    {
        var response = await HttpClient.GetAsync(EnginesUrl);

        return response.Content.DeserializeObject<List<EngineWithLanguagesOutput>>();
    }
}