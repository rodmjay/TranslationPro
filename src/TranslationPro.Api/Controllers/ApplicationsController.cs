#region Header Info

// Copyright 2023 Rod Johnson.  All rights reserved

#endregion

using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using TranslationPro.Base.Common.Middleware.Bases;
using TranslationPro.Base.Managers;
using TranslationPro.Shared.Common;
using TranslationPro.Shared.Interfaces;
using TranslationPro.Shared.Models;

namespace TranslationPro.Api.Controllers;

public class ApplicationsController : BaseController, IApplicationsController
{
    private readonly ApplicationManager _applicationManager;

    public ApplicationsController(IServiceProvider serviceProvider, ApplicationManager applicationManager) : base(serviceProvider)
    {
        _applicationManager = applicationManager;
    }

    [HttpGet("{applicationId}")]
    public async Task<ApplicationOutput> GetApplicationAsync([FromRoute] Guid applicationId)
    {
        await AssertUserHasAccessToApplication(applicationId);
        return await _applicationManager.GetApplication<ApplicationOutput>(applicationId).ConfigureAwait(false);
    }

    [HttpGet]
    public async Task<List<ApplicationOutput>> GetApplicationsAsync()
    {
        try
        {
            var user = await GetCurrentUser();
            return await _applicationManager.GetApplicationsForUserAsync<ApplicationOutput>(user.Id).ConfigureAwait(false);
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            throw;
        }
    }

    [HttpPost]
    public async Task<Result> CreateApplicationAsync([FromBody] ApplicationCreateOptions input)
    {
        var user = await GetCurrentUser();
        return await _applicationManager.CreateApplicationAsync(user.Id, input).ConfigureAwait(false);
    }

    [HttpDelete("{applicationId}")]
    public async Task<Result> DeleteApplicationAsync([FromRoute] Guid applicationId)
    {
        await AssertUserHasAccessToApplication(applicationId);
        return await _applicationManager.DeleteApplicationAsync(applicationId).ConfigureAwait(false);
    }

    [HttpPut("{applicationId}")]
    public async Task<Result> UpdateApplicationAsync([FromRoute] Guid applicationId, [FromBody] ApplicationOptions input)
    {
        await AssertUserHasAccessToApplication(applicationId);
        return await _applicationManager.UpdateApplicationAsync(applicationId, input).ConfigureAwait(false);
    }
}