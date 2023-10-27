#region Header Info

// Copyright 2023 Rod Johnson.  All rights reserved

#endregion

using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using TranslationPro.Api.Interfaces;
using TranslationPro.Base.ApplicationLanguages.Interfaces;
using TranslationPro.Base.ApplicationLanguages.Models;
using TranslationPro.Base.Common.Middleware.Bases;
using TranslationPro.Base.Common.Models;
using TranslationPro.Base.Translations.Interfaces;

namespace TranslationPro.Api.Controllers;

[Route("v1.0/applications/{applicationId}/languages")]
public class ApplicationLanguagesController : BaseController, IApplicationLanguagesController
{
    private readonly IApplicationLanguageService _applicationLanguageService;
    private readonly ITranslationService _translationService;

    public ApplicationLanguagesController(IServiceProvider serviceProvider, IApplicationLanguageService applicationLanguageService, ITranslationService translationService) : base(serviceProvider)
    {
        _applicationLanguageService = applicationLanguageService;
        _translationService = translationService;
    }

    [HttpPost]
    public async Task<Result> AddLanguageToApplication([FromRoute] Guid applicationId,
        [FromBody] ApplicationLanguageInput input)
    {
        await AssertUserHasAccessToApplication(applicationId);

        var result = await _applicationLanguageService.AddLanguageToApplication(applicationId, input);
        await _translationService.ProcessTranslationsForApplicationLanguageAsync(applicationId, input.Language);
        return result;
    }

    [HttpDelete("{languageId}")]
    public async Task<Result> RemoveLanguageFromApplication([FromRoute] Guid applicationId,
        [FromRoute] string languageId)
    {
        await AssertUserHasAccessToApplication(applicationId);

        var result = await _applicationLanguageService.RemoveLanguageFromApplication(applicationId, languageId);

        return result;
    }
}