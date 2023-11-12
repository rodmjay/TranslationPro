#region Header Info

// Copyright 2023 Rod Johnson.  All rights reserved

#endregion

using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using TranslationPro.Base.Common.Middleware.Bases;
using TranslationPro.Base.MachineTranslations.Interfaces;
using TranslationPro.Base.Phrases.Interfaces;
using TranslationPro.Shared.Common;
using TranslationPro.Shared.Filters;
using TranslationPro.Shared.Interfaces;
using TranslationPro.Shared.Models;

namespace TranslationPro.Api.Controllers;

[Route("v1.0/applications/{applicationId}/phrases")]
public class PhrasesController : BaseController, IPhrasesController
{
    private readonly IApplicationPhraseService _applicationPhraseService;
    private readonly IMachineTranslationService _transactionService;
    private readonly IApplicationTranslationService _applicationTranslationService;

    public PhrasesController(IServiceProvider serviceProvider, IApplicationPhraseService applicationPhraseService,
        IMachineTranslationService transactionService, IApplicationTranslationService applicationTranslationService) : base(serviceProvider)
    {
        _applicationPhraseService = applicationPhraseService;
        _transactionService = transactionService;
        _applicationTranslationService = applicationTranslationService;
    }

    [HttpGet("{phraseId:int}")]
    public async Task<ApplicationPhraseDetails> GetPhraseAsync([FromRoute] Guid applicationId,
        [FromRoute] int phraseId)
    {
        await AssertUserHasAccessToApplication(applicationId);
        return await _applicationPhraseService.GetPhraseAsync<ApplicationPhraseDetails>(applicationId, phraseId);
    }

    //[HttpPost("bulk")]
    //public async Task<Result> BulkUploadAsync([FromRoute] Guid applicationId,
    //    [FromBody] List<string> input)
    //{
    //    await AssertUserHasAccessToApplication(applicationId);
    //    var result = await _applicationPhraseService.BulkUploadPhrases(applicationId, input).ConfigureAwait(false);
    //    await _transactionService.ProcessTranslationsForApplicationAsync(applicationId);
    //    return result;
    //}

    [HttpPost]
    public async Task<Result> CreatePhraseAsync([FromRoute] Guid applicationId,
        [FromBody] PhraseOptions input)
    {
        await AssertUserHasAccessToApplication(applicationId);
        var result = await _applicationPhraseService.CreateApplicationPhrase(applicationId, input).ConfigureAwait(false);
        await _transactionService.ProcessTranslationsAsync(applicationId);
        await _applicationTranslationService.CopyTranslationFromPhraseList(applicationId,
            int.Parse(result.Id.ToString()));
        
        return result;
    }
    

    [HttpGet]
    public async Task<PagedList<ApplicationPhraseOutput>> GetPhrasesAsync([FromRoute] Guid applicationId,
        [FromQuery] PagingQuery paging,
        [FromQuery] PhraseFilters filters)
    {
        await AssertUserHasAccessToApplication(applicationId);
        return await _applicationPhraseService.GetPhrasesForApplicationAsync<ApplicationPhraseOutput>(applicationId, paging, filters)
            .ConfigureAwait(false);
    }

    [HttpGet("{language}")]
    [AllowAnonymous]
    public async Task<Dictionary<int, string>> GetPhrasesForApplicationAndLanguageAsync([FromRoute] Guid applicationId,
        [FromRoute] string language)
    {
        await AssertUserHasAccessToApplication(applicationId);
        return await _applicationPhraseService.GetApplicationPhraseList(applicationId, language).ConfigureAwait(false);
    }

    [HttpDelete("{phraseId}")]
    public async Task<Result> DeletePhraseAsync([FromRoute] Guid applicationId, [FromRoute] int phraseId)
    {
        await AssertUserHasAccessToApplication(applicationId);
        return await _applicationPhraseService.DeletePhraseAsync(applicationId, phraseId);
    }

    [HttpPut("{phraseId}")]
    public async Task<Result> ReplaceTranslation([FromRoute] Guid applicationId, [FromRoute] int phraseId,
        [FromBody] TranslationReplacementOptions options)
    {
        await AssertUserHasAccessToApplication(applicationId);
        return await _applicationPhraseService.ReplaceTranslation(applicationId, phraseId, options);
    }
}