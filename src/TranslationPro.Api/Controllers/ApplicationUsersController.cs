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

namespace TranslationPro.Api.Controllers;

[Route("v1.0/applications/{applicationId}/users")]
public class ApplicationUsersController : BaseController, IApplicationUsersController
{
    private readonly ApplicationUsersManager _applicationUsersManager;

    public ApplicationUsersController(IServiceProvider serviceProvider, ApplicationUsersManager applicationUsersManager)
        : base(serviceProvider)
    {
        _applicationUsersManager = applicationUsersManager;
    }

    [HttpPost]
    public async Task<Result> InviteUserAsync([FromRoute] Guid applicationId, [FromBody] ApplicationUserCreateOptions input)
    {
        await AssertUserHasAccessToApplication(applicationId);
        return await _applicationUsersManager.InviteUserAsync(applicationId, input).ConfigureAwait(false);
    }
}