#region Header Info

// Copyright 2023 Rod Johnson.  All rights reserved

#endregion

using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using TranslationPro.Base.ApplicationLanguages.Interfaces;
using TranslationPro.Base.ApplicationLanguages.Models;
using TranslationPro.Base.Common.Middleware.Bases;
using TranslationPro.Base.Common.Models;

namespace TranslationPro.Api.Controllers;

[Route("v1.0/applications/{applicationId}/languages")]
public class ApplicationLanguagesController : BaseController
{
    private readonly IApplicationLanguageService _service;

    public ApplicationLanguagesController(IServiceProvider serviceProvider, IApplicationLanguageService service) : base(serviceProvider)
    {
        _service = service;
    }

    [HttpPost]
    public async Task<Result> AddLanguageToApplication([FromRoute] Guid applicationId,
        [FromBody] ApplicationLanguageInput input)
    {
        await AssertUserHasAccessToApplication(applicationId);

        var result = await _service.AddLanguageToApplication(applicationId, input);

        return result;
    }

    [HttpDelete]
    public async Task<Result> RemoveLanguageFromApplication([FromRoute] Guid applicationId,
        [FromBody] ApplicationLanguageInput input)
    {
        await AssertUserHasAccessToApplication(applicationId);

        var result = await _service.RemoveLanguageFromApplication(applicationId, input);

        return result;
    }
}