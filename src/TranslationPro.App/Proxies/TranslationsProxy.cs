using TranslationPro.Shared.Common;
using TranslationPro.Shared.Controllers;
using TranslationPro.Shared.Translations;

namespace TranslationPro.App.Proxies;

public class TranslationsProxy : BaseProxy, ITranslationsController
{
    public Task<Result> SaveTranslation(Guid applicationId, int phraseId, TranslationInput input)
    {
        return DoPut<TranslationInput, Result>($"{ApplicationUrl}/{applicationId}/phrases/{phraseId}", input);

    }

    public TranslationsProxy(HttpClient httpClient) : base(httpClient)
    {
    }
}