#region Header Info

// Copyright 2023 Rod Johnson.  All rights reserved

#endregion

using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using TranslationPro.Base.Common.Middleware.Bases;
using TranslationPro.Base.Users.Interfaces;
using TranslationPro.Shared.Interfaces;
using TranslationPro.Shared.Models;

namespace TranslationPro.Api.Controllers;

public class UserController : BaseController, IUserController
{
    private readonly IUserService _userService;

    public UserController(IServiceProvider serviceProvider, IUserService userService) : base(serviceProvider)
    {
        _userService = userService;
    }

    [HttpGet]
    public async Task<UserOutput> GetUser()
    {
        var user = await GetCurrentUser();

        return await _userService.GetUserById<UserOutput>(user.Id);
    }

}