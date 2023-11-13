#region Header Info

// Copyright 2023 Rod Johnson.  All rights reserved

#endregion

using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Caching.Distributed;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;
using SendGrid.Helpers.Errors.Model;
using TranslationPro.Base.Common.Settings;
using TranslationPro.Base.Services;
using TranslationPro.Base.Users.Interfaces;

namespace TranslationPro.Base.Common.Middleware.Bases;

[ApiController]
[Produces("application/json")]
[Route("v1.0/[controller]")]
public class BaseController : ControllerBase
{
    private readonly IUserAccessor _userAccessor;
    protected readonly AppSettings AppSettings;
    protected readonly IDistributedCache Cache;
    protected readonly IPermissionService PermissionService;

    /// <param name="serviceProvider"></param>
    protected BaseController(IServiceProvider serviceProvider)
    {
        _userAccessor = serviceProvider.GetService<IUserAccessor>();
        PermissionService = serviceProvider.GetRequiredService<IPermissionService>();
        Cache = serviceProvider.GetRequiredService<IDistributedCache>();
        AppSettings = serviceProvider.GetRequiredService<IOptions<AppSettings>>().Value;
    }

    protected async Task AssertUserHasAccessToApplication(Guid applicationId)
    {
        var user = await GetCurrentUser();

        var userHasAccessToApplication = await PermissionService.UserCanAccessApplication(user.Id, applicationId);

        if (!userHasAccessToApplication)
            throw new ForbiddenException("User does not have access to application");
    }

    protected async Task<IUser> GetCurrentUser()
    {
        return await _userAccessor.GetUser(User);
    }
}