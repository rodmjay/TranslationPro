#region Header Info

// Copyright 2023 Rod Johnson.  All rights reserved

#endregion

using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using TranslationPro.Base.Applications.Interfaces;
using TranslationPro.Base.Common.Middleware.Bases;
using TranslationPro.Shared.Common;
using TranslationPro.Shared.Interfaces;
using TranslationPro.Shared.Models;

namespace TranslationPro.Api.Controllers;

public class ApplicationsController : BaseController, IApplicationsController
{
    private readonly IApplicationService _service;

    public ApplicationsController(IServiceProvider serviceProvider, IApplicationService service) : base(serviceProvider)
    {
        _service = service;
    }

    [HttpGet("{applicationId}")]
    public async Task<ApplicationOutput> GetApplicationAsync([FromRoute] Guid applicationId)
    {
        await AssertUserHasAccessToApplication(applicationId);
        return await _service.GetApplication<ApplicationOutput>(applicationId).ConfigureAwait(false);
    }

    [HttpGet]
    public async Task<List<ApplicationOutput>> GetApplicationsAsync()
    {
        var user = await GetCurrentUser();
        return await _service.GetApplicationsForUserAsync<ApplicationOutput>(user.Id).ConfigureAwait(false);
    }

    [HttpPost]
    public async Task<Result> CreateApplicationAsync([FromBody] ApplicationCreateOptions input)
    {
        var user = await GetCurrentUser();
        return await _service.CreateApplicationAsync(user.Id, input).ConfigureAwait(false);
    }

    [HttpDelete("{applicationId}")]
    public async Task<Result> DeleteApplicationAsync([FromRoute] Guid applicationId)
    {
        await AssertUserHasAccessToApplication(applicationId);
        return await _service.DeleteApplicationAsync(applicationId).ConfigureAwait(false);
    }

    [HttpPut("{applicationId}")]
    public async Task<Result> UpdateApplicationAsync([FromRoute] Guid applicationId, [FromBody] ApplicationOptions input)
    {
        await AssertUserHasAccessToApplication(applicationId);
        return await _service.UpdateApplicationAsync(applicationId, input).ConfigureAwait(false);
    }
}