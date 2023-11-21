#region Header Info

// Copyright 2023 Rod Johnson.  All rights reserved

#endregion

using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using TranslationPro.Base.Common.Middleware.Bases;
using TranslationPro.Base.Managers;
using TranslationPro.Shared.Common;
using TranslationPro.Shared.Interfaces;
using TranslationPro.Shared.Models;
using TranslationPro.Shared.Results;

namespace TranslationPro.Api.Controllers;

[Route("v1.0/applications/{applicationId}/languages")]
public class ApplicationLanguagesController : BaseController, IApplicationLanguagesController
{
    private readonly ApplicationPhraseManager _applicationPhraseManager;
    private readonly ApplicationLanguageManager _applicationLanguageManager;

    public ApplicationLanguagesController(IServiceProvider serviceProvider,
        ApplicationPhraseManager applicationPhraseManager,
        ApplicationLanguageManager applicationLanguageManager) : base(
        serviceProvider)
    {
        _applicationPhraseManager = applicationPhraseManager;
        _applicationLanguageManager = applicationLanguageManager;
    }

    [HttpPost]
    public async Task<Result> AddLanguageToApplicationAsync([FromRoute] Guid applicationId,
        [FromBody] ApplicationLanguageOptions options)
    {
        await AssertUserHasAccessToApplication(applicationId);

        await _applicationPhraseManager.AddLanguageToApplicationPhrases(applicationId, options.LanguageId);
        
        return Result.Success(options.LanguageId);
    }

    [HttpDelete("{languageId}")]
    public async Task<Result> RemoveLanguageFromApplicationAsync([FromRoute] Guid applicationId,
        [FromRoute] string languageId)
    {
        await AssertUserHasAccessToApplication(applicationId);
        var result = await _applicationLanguageManager.RemoveLanguageFromApplication(applicationId, languageId);

        return result;
    }

    [HttpGet("{languageId}")]
    public async Task<PagedList<ApplicationTranslationOutputWithOriginalPhrase>> GetTranslationsForLanguage(
        [FromRoute] Guid applicationId, 
        [FromRoute] string languageId, 
        [FromQuery] PagingQuery query)
    {
        await AssertUserHasAccessToApplication(applicationId);

        return await _applicationLanguageManager.GetTranslationsForApplicationForLanguage<ApplicationTranslationOutputWithOriginalPhrase>(
            applicationId, languageId, query);
    }
}