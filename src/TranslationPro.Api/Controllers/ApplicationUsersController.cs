#region Header Info

// Copyright 2023 Rod Johnson.  All rights reserved

#endregion

using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using TranslationPro.Base.ApplicationUsers.Interfaces;
using TranslationPro.Base.ApplicationUsers.Models;
using TranslationPro.Base.Common.Middleware.Bases;
using TranslationPro.Base.Common.Models;

namespace TranslationPro.Api.Controllers;

[Microsoft.AspNetCore.Components.Route("v1.0/applications/{applicationId}/users")]
public class ApplicationUsersController : BaseController
{
    private readonly IApplicationUserService _applicationUserService;

    public ApplicationUsersController(IServiceProvider serviceProvider, IApplicationUserService applicationUserService) : base(serviceProvider)
    {
        _applicationUserService = applicationUserService;
    }

    [HttpPost]
    public async Task<Result> InviteUser([FromRoute] Guid applicationId, [FromBody] CreateApplicationUser input)
    {
        return await _applicationUserService.InviteUserAsync(applicationId, input).ConfigureAwait(false);
    }
}