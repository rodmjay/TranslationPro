using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using TranslationPro.Shared.Interfaces;
using TranslationPro.Shared.Models;

namespace TranslationPro.Shared.Proxies;

public class LanguagesProxy : BaseProxy, ILanguagesController
{
    protected string LanguageUrl = "/v1.0/languages";

    public Task<List<LanguageOutput>> GetLanguagesAsync()
    {
        return DoGet<List<LanguageOutput>>(LanguageUrl);

    }

    public Task<LanguageOutput> GetLanguageAsync(string languageId)
    {
        return DoGet<LanguageOutput>(LanguageUrl + $"/{languageId}");
    }

    public LanguagesProxy(HttpClient httpClient) : base(httpClient)
    {
    }
}