#region Header Info

// Copyright 2023 Rod Johnson.  All rights reserved

#endregion

using System;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using TranslationPro.Base.Common.Middleware.Bases;

namespace TranslationPro.Api.Controllers;

public class IdentityController : BaseController
{
    public IdentityController(IServiceProvider serviceProvider) : base(serviceProvider)
    {
    }

    [HttpGet]
    public IActionResult Get()
    {
        return new JsonResult(from c in User.Claims select new {c.Type, c.Value});
    }
}