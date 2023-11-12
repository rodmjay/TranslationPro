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

    public ApplicationLanguagesProxy(HttpClient httpClient) : base(httpClient)
    {
    }
}