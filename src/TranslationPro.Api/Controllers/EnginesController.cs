#region Header Info

// Copyright 2023 Rod Johnson.  All rights reserved

#endregion

using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using TranslationPro.Base.Common.Middleware.Bases;
using TranslationPro.Base.Managers;
using TranslationPro.Shared.Interfaces;
using TranslationPro.Shared.Models;

namespace TranslationPro.Api.Controllers;

public class EnginesController : BaseController, IEnginesController
{
    private readonly EngineManager _engineManager;

    public EnginesController(IServiceProvider serviceProvider, EngineManager engineManager) : base(serviceProvider)
    {
        _engineManager = engineManager;
    }
    
    [HttpGet]
    [AllowAnonymous]
    public async Task<List<EngineWithLanguagesOutput>> GetEnginesAsync()
    {
        return await _engineManager.GetEngines<EngineWithLanguagesOutput>();
    }
}