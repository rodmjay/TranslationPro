#region Header Info

// Copyright 2023 Rod Johnson.  All rights reserved

#endregion

using System.Collections.Generic;
using System.Threading.Tasks;
using TranslationPro.Base.Services;
using TranslationPro.Shared.Models;

namespace TranslationPro.Base.Managers;

public class EngineManager
{
    private readonly IEngineService _engineService;

    public EngineManager(IEngineService engineService)
    {
        _engineService = engineService;
    }

    public Task<List<T>> GetEngines<T>() where T : EngineOutput
    {
        return _engineService.GetEngines<T>();
    }
}