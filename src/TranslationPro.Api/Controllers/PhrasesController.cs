using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using TranslationPro.Base.Common.Middleware.Bases;
using TranslationPro.Base.Common.Models;
using TranslationPro.Base.Translations.Interfaces;
using TranslationPro.Base.Translations.Models;

namespace TranslationPro.Api.Controllers;

[Route("v1.0/{applicationId}/phrases")]
public class PhrasesController : BaseController
{
    private readonly IPhraseService _phraseService;

    public PhrasesController(IServiceProvider serviceProvider, IPhraseService phraseService) : base(serviceProvider)
    {
        _phraseService = phraseService;
    }

    [HttpPost]
    public async Task<Result> CreatePhrase([FromRoute] Guid applicationId, [FromRoute] int translationId,
        [FromBody] CreatePhraseDto input)
    {
        await AssertUserHasAccessToApplication(applicationId);

        return await _phraseService.CreatePhraseAsync(applicationId, input).ConfigureAwait(false);
    }

    [HttpGet]
    public async Task<List<PhraseDto>> GetPhrases([FromRoute] Guid applicationId)
    {
        await AssertUserHasAccessToApplication(applicationId);

        return await _phraseService.GetPhrasesForApplicationAsync<PhraseDto>(applicationId).ConfigureAwait(false);
    }
}