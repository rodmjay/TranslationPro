using System;
using System.Net.Http;
using System.Threading.Tasks;
using TranslationPro.Shared.Common;
using TranslationPro.Shared.Interfaces;
using TranslationPro.Shared.Models;

namespace TranslationPro.App.Proxies;

public class ApplicationLanguagesProxy : BaseProxy, IApplicationLanguagesController
{
    public Task<Result> AddLanguageToApplicationAsync(Guid applicationId, ApplicationLanguageInput input)
    {
        return DoPost<ApplicationLanguageInput, Result>($"{ApplicationUrl}/{applicationId}/languages", input);
    }

    public Task<Result> RemoveLanguageFromApplicationAsync(Guid applicationId, string languageId)
    {
        return DoDelete<Result>($"{ApplicationUrl}/{applicationId}/languages/{languageId}");
    }

    public ApplicationLanguagesProxy(HttpClient httpClient) : base(httpClient)
    {
    }
}