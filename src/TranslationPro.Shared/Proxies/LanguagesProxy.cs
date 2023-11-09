using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using TranslationPro.Shared.Extensions;
using TranslationPro.Shared.Interfaces;
using TranslationPro.Shared.Models;

namespace TranslationPro.Shared.Proxies;

public class LanguagesProxy : BaseProxy, ILanguagesController
{
    protected string LanguageUrl = "/v1.0/languages";

    public async Task<List<LanguageOutput>> GetLanguagesAsync()
    {
        var response = await HttpClient.GetAsync(LanguageUrl);

        return response.Content.DeserializeObject<List<LanguageOutput>>();
    }

    public Task<List<LanguagesWithEnginesOutput>> GetAllLanguagesAsync()
    {
        throw new System.NotImplementedException();
    }


    public LanguagesProxy(HttpClient httpClient) : base(httpClient)
    {
    }
}