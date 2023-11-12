#region Header Info

// Copyright 2023 Rod Johnson.  All rights reserved

#endregion

using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using TranslationPro.Base.Common.Middleware.Bases;
using TranslationPro.Base.MachineTranslations.Interfaces;
using TranslationPro.Shared.Interfaces;
using TranslationPro.Shared.Models;

namespace TranslationPro.Api.Controllers;

public class EnginesController : BaseController, IEnginesController
{
    private readonly IEngineService _engineService;

    public EnginesController(IServiceProvider serviceProvider, IEngineService engineService) : base(serviceProvider)
    {
        _engineService = engineService;
    }
    
    [HttpGet]
    [AllowAnonymous]
    public async Task<List<EngineWithLanguagesOutput>> GetEnginesAsync()
    {
        return await _engineService.GetEngines<EngineWithLanguagesOutput>();
    }
}