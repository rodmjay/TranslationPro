#region Header Info

// Copyright 2023 Rod Johnson.  All rights reserved

#endregion

using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using TranslationPro.Api.Interfaces;
using TranslationPro.Base.Common.Middleware.Bases;
using TranslationPro.Base.Common.Models;
using TranslationPro.Base.Phrases.Interfaces;
using TranslationPro.Base.Phrases.Models;
using TranslationPro.Base.Translations.Interfaces;

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

    [HttpPost("bulk")]
    public async Task<Result> BulkUpload([FromRoute] Guid applicationId,
        [FromBody] List<string> input)
    {
        await AssertUserHasAccessToApplication(applicationId);

        var result = await _phraseService.BulkUploadPhrases(applicationId, input).ConfigureAwait(false);

        await _transactionService.ProcessTranslationsForApplicationAsync(applicationId);

        return result;
    }

    [HttpPost]
    public async Task<Result> CreatePhrase([FromRoute] Guid applicationId,
        [FromBody] PhraseInput input)
    {
        await AssertUserHasAccessToApplication(applicationId);

        var result = await _phraseService.CreatePhraseAsync(applicationId, input).ConfigureAwait(false);

        await _transactionService.ProcessTranslationsForApplicationAsync(applicationId);

        return result;
    }

    [HttpPut("{phraseId}")]
    public async Task<Result> UpdatePhrase([FromRoute] Guid applicationId, [FromRoute] int phraseId,
        [FromBody] PhraseInput input)
    {
        await AssertUserHasAccessToApplication(applicationId);

        var result = await _phraseService.UpdatePhraseAsync(applicationId, phraseId, input).ConfigureAwait(false);

        await _transactionService.ProcessTranslationsForApplicationAsync(applicationId);

        return result;
    }

    [HttpGet]
    public async Task<PagedList<PhraseDto>> GetPhrases([FromRoute] Guid applicationId, [FromQuery] PagingQuery paging,
        [FromQuery] PhraseFilters filters)
    {
        await AssertUserHasAccessToApplication(applicationId);

        return await _phraseService.GetPhrasesForApplicationAsync<PhraseDto>(applicationId, paging, filters)
            .ConfigureAwait(false);
    }

    [HttpGet("{language}")]
    public async Task<Dictionary<int, string>> GetPhrasesForApplicationAndLanguage([FromRoute] Guid applicationId,
        [FromRoute] string language)
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