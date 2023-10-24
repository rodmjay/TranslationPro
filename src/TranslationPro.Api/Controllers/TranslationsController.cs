using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using TranslationPro.Base.Common.Middleware.Bases;
using TranslationPro.Base.Common.Models;
using TranslationPro.Base.Translations.Interfaces;
using TranslationPro.Base.Translations.Models;

namespace TranslationPro.Api.Controllers;

[Route("v1.0/applications/{applicationId}/phrases/{phraseId}/translations")]
public class TranslationsController : BaseController
{
    private readonly ITranslationService _translationService;

    public TranslationsController(IServiceProvider serviceProvider, ITranslationService translationService) : base(
        serviceProvider)
    {
        _translationService = translationService;
    }

    [HttpPost]
    public async Task<Result> SaveTranslation([FromRoute] Guid applicationId, [FromRoute] int phraseId,
        [FromBody] TranslationInput input)
    {
        return await _translationService.SaveTranslation(applicationId, phraseId, input).ConfigureAwait(false);
    }
}