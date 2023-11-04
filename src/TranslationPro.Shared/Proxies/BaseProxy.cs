#region Header Info

// Copyright 2023 Rod Johnson.  All rights reserved

#endregion

using TranslationPro.Shared.Extensions;

namespace TranslationPro.Shared.Proxies;

public abstract class BaseProxy
{
    protected string ApplicationUrl = "/v1.0/applications";

    protected readonly HttpClient HttpClient;
    protected BaseProxy(HttpClient httpClient)
    {
        HttpClient = httpClient;
    }


    protected async Task<TOutput> DoPost<TInput, TOutput>(string url, TInput input)
    {
        var content = input.SerializeToUTF8Json();
        var response = await HttpClient.PostAsync(url, content);

        var result = response.Content.DeserializeObject<TOutput>();
        return result;
    }

    protected async Task<TOutput> DoGet<TOutput>(string url)
    {
        var response = await HttpClient.GetAsync(url);

        var result = response.Content.DeserializeObject<TOutput>();

        return result;
    }

    protected async Task<TOutput> DoPut<TInput, TOutput>(string url, TInput input)
    {
        var content = input.SerializeToUTF8Json();
        var response = await HttpClient.PutAsync(url, content);

        var result = response.Content.DeserializeObject<TOutput>();
        return result;
    }

    protected async Task<TOutput> DoDelete<TOutput>(string url)
    {
        var response = await HttpClient.DeleteAsync(url);

        var result = response.Content.DeserializeObject<TOutput>();
        return result;
    }

}