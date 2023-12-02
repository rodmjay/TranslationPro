﻿#region Header Info

// Copyright 2023 Rod Johnson.  All rights reserved

#endregion

using System;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using AutoMapper.QueryableExtensions;
using Microsoft.EntityFrameworkCore;
using TranslationPro.Base.Common.Services.Bases;
using TranslationPro.Base.Users.Entities;
using TranslationPro.Base.Users.Interfaces;
using TranslationPro.Base.Users.Managers;
using TranslationPro.Shared.Interfaces;
using TranslationPro.Shared.Models;

namespace TranslationPro.Base.Users.Services;

public class UserAccessor : BaseService<User>, IUserAccessor
{
    private readonly UserManager _userManager;

    public UserAccessor(
        UserManager userManager,
        IServiceProvider serviceProvider) : base(serviceProvider)
    {
        _userManager = userManager;
    }

    public Task<IUser> GetUser(ClaimsPrincipal principal)
    {
        var id = _userManager.GetUserId(principal);

        var userId = int.Parse(id);

        return _userManager.Users.Where(x => x.Id == userId)
            .ProjectTo<UserOutput>(ProjectionMapping)
            .Cast<IUser>()
            .FirstOrDefaultAsync();
    }
}