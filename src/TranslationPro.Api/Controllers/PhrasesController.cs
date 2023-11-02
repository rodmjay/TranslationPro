#region Header Info

// Copyright 2023 Rod Johnson.  All rights reserved

#endregion

using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using TranslationPro.Base.Common.Middleware.Bases;
using TranslationPro.Base.Phrases.Interfaces;
using TranslationPro.Base.Translations.Interfaces;
using TranslationPro.Shared.Common;
using TranslationPro.Shared.Controllers;
using TranslationPro.Shared.Phrases;

namespace TranslationPro.Api.Controllers;

[Route("v1.0/applications/{applicationId}/phrases")]
public class PhrasesController : BaseController, IPhrasesController
{
    private readonly IPhraseService _phraseService;
    private readonly ITranslationService _transactionService;

    public PhrasesController(IServiceProvider serviceProvider, IPhraseService phraseService,
        ITranslationService transactionService) : base(serviceProvider)
    {
        _phraseService = phraseService;
        _transactionService = transactionService;
    }

    [HttpGet("{phraseId:int}")]
    public async Task<PhraseDto> GetPhraseAsync([FromRoute] Guid applicationId, [FromRoute] int phraseId)
    {
        await AssertUserHasAccessToApplication(applicationId);
        return await _phraseService.GetPhraseAsync<PhraseDto>(applicationId, phraseId);
    }

    [HttpPost("bulk")]
    public async Task<Result> BulkUploadAsync([FromRoute] Guid applicationId,
        [FromBody] List<string> input)
    {
        await AssertUserHasAccessToApplication(applicationId);
        var result = await _phraseService.BulkUploadPhrases(applicationId, input).ConfigureAwait(false);
        await _transactionService.ProcessTranslationsForApplicationAsync(applicationId);
        return result;
    }

    [HttpPost]
    public async Task<Result> CreatePhraseAsync([FromRoute] Guid applicationId,
        [FromBody] PhraseInput input)
    {
        await AssertUserHasAccessToApplication(applicationId);
        var result = await _phraseService.CreatePhraseAsync(applicationId, input).ConfigureAwait(false);
        await _transactionService.ProcessTranslationsForApplicationAsync(applicationId);

        return result;
    }

    [HttpPut("{phraseId}")]
    public async Task<Result> UpdatePhraseAsync([FromRoute] Guid applicationId, [FromRoute] int phraseId,
        [FromBody] PhraseInput input)
    {
        await AssertUserHasAccessToApplication(applicationId);
        var result = await _phraseService.UpdatePhraseAsync(applicationId, phraseId, input).ConfigureAwait(false);
        await _transactionService.ProcessTranslationsForApplicationAsync(applicationId);

        return result;
    }

    [HttpGet]
    public async Task<PagedList<PhraseDto>> GetPhrasesAsync([FromRoute] Guid applicationId,
        [FromQuery] PagingQuery paging,
        [FromQuery] PhraseFilters filters)
    {
        await AssertUserHasAccessToApplication(applicationId);
        return await _phraseService.GetPhrasesForApplicationAsync<PhraseDto>(applicationId, paging, filters)
            .ConfigureAwait(false);
    }

    [HttpGet("{language}")]
    [AllowAnonymous]
    public async Task<Dictionary<int, string>> GetPhrasesForApplicationAndLanguageAsync([FromRoute] Guid applicationId,
        [FromRoute] string language)
    {
        await AssertUserHasAccessToApplication(applicationId);
        return await _phraseService.GetApplicationPhraseList(applicationId, language).ConfigureAwait(false);
    }

    [HttpDelete("{phraseId}")]
    public async Task<Result> DeletePhraseAsync([FromRoute] Guid applicationId, [FromRoute] int phraseId)
    {
        await AssertUserHasAccessToApplication(applicationId);
        return await _phraseService.DeletePhraseAsync(applicationId, phraseId);
    }
}