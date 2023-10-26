#region Header Info

// Copyright 2023 Rod Johnson.  All rights reserved

#endregion

using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using TranslationPro.Base.Applications.Interfaces;
using TranslationPro.Base.Applications.Models;
using TranslationPro.Base.Common.Middleware.Bases;
using TranslationPro.Base.Common.Models;
using TranslationPro.Base.Translations.Interfaces;

namespace TranslationPro.Api.Controllers;

public class ApplicationsController : BaseController
{
    private readonly IApplicationService _service;
    private readonly ITranslationService _translationService;

    public ApplicationsController(IServiceProvider serviceProvider, IApplicationService service,
        ITranslationService translationService) : base(serviceProvider)
    {
        _service = service;
        _translationService = translationService;
    }

    [HttpGet]
    public async Task<List<ApplicationDto>> GetApplicationsAsync()
    {
        var user = await GetCurrentUser();
        return await _service.GetApplicationsForUserAsync<ApplicationDto>(user.Id);
    }

    [HttpPost]
    public async Task<Result> CreateApplicationAsync([FromBody] ApplicationInput input)
    {
        var user = await GetCurrentUser();
        return await _service.CreateApplicationAsync(user.Id, input).ConfigureAwait(false);
    }

    [HttpPut("{applicationId}")]
    public async Task<Result> UpdateApplicationAsync([FromRoute] Guid applicationId, [FromBody] ApplicationInput input)
    {
        await AssertUserHasAccessToApplication(applicationId);

        var result = await _service.UpdateApplicationAsync(applicationId, input).ConfigureAwait(false);

        await _translationService.ProcessTranslationsForApplicationAsync(applicationId);

        return result;
    }
}