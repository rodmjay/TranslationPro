#region Header Info

// Copyright 2023 Rod Johnson.  All rights reserved

#endregion

using System;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using TranslationPro.Base.Common.Middleware.Bases;
using TranslationPro.Base.Common.Settings;

namespace TranslationPro.Api.Controllers;

[AllowAnonymous]
public class SettingsController : BaseController
{
    private readonly AppSettings _settings;

    public SettingsController(IServiceProvider serviceProvider, IOptions<AppSettings> settings) : base(serviceProvider)
    {
        _settings = settings.Value;
    }

    [HttpGet]
    public IActionResult Get()
    {
        return new JsonResult(_settings);
    }
}