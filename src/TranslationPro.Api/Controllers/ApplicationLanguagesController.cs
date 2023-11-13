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
    private readonly ApplicationLanguageManager _applicationLanguageManager;

    public ApplicationLanguagesController(IServiceProvider serviceProvider,
        ApplicationLanguageManager applicationLanguageManager) : base(
        serviceProvider)
    {
        _applicationLanguageManager = applicationLanguageManager;
    }

    [HttpPost]
    public async Task<LanguageAddedResult> AddLanguageToApplicationAsync([FromRoute] Guid applicationId,
        [FromBody] ApplicationLanguageOptions options)
    {
        await AssertUserHasAccessToApplication(applicationId);

        var result = await _applicationLanguageManager.AddLanguageToApplication(applicationId, options);
        
        return result;
    }

    [HttpDelete("{languageId}")]
    public async Task<Result> RemoveLanguageFromApplicationAsync([FromRoute] Guid applicationId,
        [FromRoute] string languageId)
    {
        await AssertUserHasAccessToApplication(applicationId);
        var result = await _applicationLanguageManager.RemoveLanguageFromApplication(applicationId, languageId);

        return result;
    }
}