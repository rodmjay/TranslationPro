using System.Collections.Generic;
using System.Threading.Tasks;
using System;
using TranslationPro.Shared.Common;
using TranslationPro.Shared.Models;
using TranslationPro.Base.Services;

namespace TranslationPro.Base.Managers;

public class ApplicationUsersManager
{
    private readonly IApplicationUserService _userService;

    public ApplicationUsersManager(IApplicationUserService userService)
    {
        _userService = userService;
    }

    public Task<Result> InviteUserAsync(Guid applicationId, ApplicationUserCreateOptions input)
    {
        return _userService.InviteUserAsync(applicationId, input);
    }

    public Task<List<T>> GetUsersForApplication<T>(Guid applicationId)
    {
        return _userService.GetUsersForApplication<T>(applicationId);
    }
}