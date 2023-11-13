using System;
using System.Net.Http;
using System.Threading.Tasks;
using TranslationPro.Shared.Common;
using TranslationPro.Shared.Interfaces;
using TranslationPro.Shared.Models;

namespace TranslationPro.Shared.Proxies;

public class TranslationsProxy : BaseProxy, ITranslationsController
{
    public Task<Result> SaveTranslation(Guid applicationId, int phraseId, TranslationOptions input)
    {
        return DoPut<TranslationOptions, Result>($"{ApplicationUrl}/{applicationId}/phrases/{phraseId}", input);

    }

    public TranslationsProxy(HttpClient httpClient) : base(httpClient)
    {
    }

    public Task<Result> ReplaceTranslation(Guid applicationId, int phraseId, TranslationReplacementOptions options)
    {
        return DoPut<TranslationReplacementOptions, Result>($"{ApplicationUrl}/{applicationId}/phrases/{phraseId}/translations", options);
    }
}