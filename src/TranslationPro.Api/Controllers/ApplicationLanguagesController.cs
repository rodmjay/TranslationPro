#region Header Info

// Copyright 2023 Rod Johnson.  All rights reserved

#endregion

using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using TranslationPro.Base.Common.Middleware.Bases;
using TranslationPro.Base.Interfaces;
using TranslationPro.Shared.Common;
using TranslationPro.Shared.Interfaces;
using TranslationPro.Shared.Models;

namespace TranslationPro.Api.Controllers;

[Route("v1.0/applications/{applicationId}/languages")]
public class ApplicationLanguagesController : BaseController, IApplicationLanguagesController
{
    private readonly IApplicationLanguageService _applicationLanguageService;
    private readonly IApplicationTranslationService _applicationTranslationService;
    private readonly IMachineTranslationService _machineTranslationService;

    public ApplicationLanguagesController(IServiceProvider serviceProvider,
        IApplicationLanguageService applicationLanguageService,
        IApplicationTranslationService applicationTranslationService,
        IPhraseService phraseService,
        IMachineTranslationService machineTranslationService) : base(
        serviceProvider)
    {
        _applicationLanguageService = applicationLanguageService;
        _applicationTranslationService = applicationTranslationService;
        _machineTranslationService = machineTranslationService;
    }

    [HttpPost]
    public async Task<Result> AddLanguageToApplicationAsync([FromRoute] Guid applicationId,
        [FromBody] ApplicationLanguageOptions options)
    {
        await AssertUserHasAccessToApplication(applicationId);

        var result = await _applicationLanguageService.AddLanguageToApplication(applicationId, options);
        await _machineTranslationService.ProcessTranslationsAsync(applicationId);
        await _applicationTranslationService.CopyTranslationsFromLanguage(applicationId,options.Language);
        return result;
    }

    [HttpDelete("{languageId}")]
    public async Task<Result> RemoveLanguageFromApplicationAsync([FromRoute] Guid applicationId,
        [FromRoute] string languageId)
    {
        await AssertUserHasAccessToApplication(applicationId);
        var result = await _applicationLanguageService.RemoveLanguageFromApplication(applicationId, languageId);

        return result;
    }
}