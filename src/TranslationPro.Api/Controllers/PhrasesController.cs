using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using TranslationPro.Base.Common.Middleware.Bases;
using TranslationPro.Base.Common.Models;
using TranslationPro.Base.Translations.Interfaces;
using TranslationPro.Base.Translations.Models;

namespace TranslationPro.Api.Controllers;

[Route("v1.0/applications/{applicationId}/phrases")]
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

    [HttpPut("{phraseId}")]
    public async Task<Result> UpdatePhrase([FromRoute] Guid applicationId, [FromRoute] int phraseId,
        [FromBody] UpdatePhraseDto input)
    {
        await AssertUserHasAccessToApplication(applicationId);

        return await _phraseService.UpdatePhraseAsync(applicationId, phraseId, input).ConfigureAwait(false);
    }

    [HttpGet]
    public async Task<PagedList<PhraseDto>> GetPhrases([FromRoute] Guid applicationId, [FromQuery] PagingQuery paging, [FromQuery] PhraseFilters filters)
    {
        await AssertUserHasAccessToApplication(applicationId);

        return await _phraseService.GetPhrasesForApplicationAsync<PhraseDto>(applicationId, paging, filters).ConfigureAwait(false);
    }

    [HttpGet("{language}")]
    public async Task<Dictionary<int,string>> GetPhrasesForApplicationAndLanguage([FromRoute] Guid applicationId, [FromRoute]string language)
    {
        await AssertUserHasAccessToApplication(applicationId);

        return await _phraseService.GetApplicationPhraseList(applicationId, language).ConfigureAwait(false);
    }

    [HttpDelete("{phraseId}")]
    public async Task<Result> DeletePhrase([FromRoute] Guid applicationId, [FromRoute] int phraseId)
    {
        await AssertUserHasAccessToApplication(applicationId);

        return await _phraseService.DeletePhraseAsync(applicationId, phraseId);
    }
}