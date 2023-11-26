using Microsoft.Extensions.Options;
using System;
using System.Net.Http;
using System.Threading.Tasks;
using TranslationPro.Shared.Common;
using TranslationPro.Shared.Interfaces;
using TranslationPro.Shared.Models;

namespace TranslationPro.Shared.Proxies;

public class ApplicationLanguagesProxy : BaseProxy, IApplicationLanguagesController
{
    public Task<Result> AddLanguageToApplicationAsync(Guid applicationId, ApplicationLanguageOptions options)
    {
        return DoPost<ApplicationLanguageOptions, Result>($"{ApplicationUrl}/{applicationId}/languages", options);
    }

    public Task<Result> RemoveLanguageFromApplicationAsync(Guid applicationId, string languageId)
    {
        return DoDelete<Result>($"{ApplicationUrl}/{applicationId}/languages/{languageId}");
    }

    public Task<PagedList<ApplicationTranslationOutputWithOriginalPhrase>> GetTranslationsForLanguage(Guid applicationId,
        string languageId, PagingQuery query)
    {
        return DoGet<PagedList<ApplicationTranslationOutputWithOriginalPhrase>>(
            $"{ApplicationUrl}/{applicationId}/languages/{languageId}");
    }

    public Task<Result> SyncLanguages(Guid applicationId, string[] languageIds)
    {
        return DoPost<string[], Result>($"{ApplicationUrl}/{applicationId}/languages/sync", languageIds);
    }

    public ApplicationLanguagesProxy(HttpClient httpClient) : base(httpClient)
    {
    }
}