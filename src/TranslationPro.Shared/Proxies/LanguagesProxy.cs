using TranslationPro.Shared.Extensions;
using TranslationPro.Shared.Interfaces;
using TranslationPro.Shared.Models;

namespace TranslationPro.Shared.Proxies;

public class LanguagesProxy : BaseProxy, ILanguagesController
{
    protected string LanguageUrl = "/v1.0/languages";

    public async Task<List<LanguageDto>> GetLanguagesAsync()
    {
        var response = await HttpClient.GetAsync(LanguageUrl);

        return response.Content.DeserializeObject<List<LanguageDto>>();
    }


    public LanguagesProxy(HttpClient httpClient) : base(httpClient)
    {
    }
}