#region Header Info

// Copyright 2023 Rod Johnson.  All rights reserved

#endregion

using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using TranslationPro.Base.ApplicationLanguages.Interfaces;
using TranslationPro.Base.Common.Middleware.Bases;
using TranslationPro.Base.MachineTranslations.Interfaces;
using TranslationPro.Base.Phrases.Interfaces;
using TranslationPro.Shared.Common;
using TranslationPro.Shared.Interfaces;
using TranslationPro.Shared.Models;

namespace TranslationPro.Api.Controllers;

[Route("v1.0/applications/{applicationId}/languages")]
public class ApplicationLanguagesController : BaseController, IApplicationLanguagesController
{
    private readonly IApplicationEngineLanguageService _applicationEngineLanguageService;
    private readonly IApplicationTranslationService _applicationTranslationService;
    private readonly IMachineTranslationService _machineTranslationService;

    public ApplicationLanguagesController(IServiceProvider serviceProvider,
        IApplicationEngineLanguageService applicationEngineLanguageService,
        IApplicationTranslationService applicationTranslationService,
        IPhraseService phraseService,
        IMachineTranslationService machineTranslationService) : base(
        serviceProvider)
    {
        _applicationEngineLanguageService = applicationEngineLanguageService;
        _applicationTranslationService = applicationTranslationService;
        _machineTranslationService = machineTranslationService;
    }

    [HttpPost]
    public async Task<Result> AddLanguageToApplicationAsync([FromRoute] Guid applicationId,
        [FromBody] ApplicationLanguageOptions options)
    {
        await AssertUserHasAccessToApplication(applicationId);

        var result = await _applicationEngineLanguageService.AddLanguageToApplication(applicationId, options);
        await _machineTranslationService.ProcessTranslationsAsync(applicationId);
        await _applicationTranslationService.CopyTranslationsFromLanguage(applicationId,options.Language);
        return result;
    }

    [HttpDelete("{languageId}")]
    public async Task<Result> RemoveLanguageFromApplicationAsync([FromRoute] Guid applicationId,
        [FromRoute] string languageId)
    {
        await AssertUserHasAccessToApplication(applicationId);
        var result = await _applicationEngineLanguageService.RemoveLanguageFromApplication(applicationId, languageId);

        return result;
    }
}