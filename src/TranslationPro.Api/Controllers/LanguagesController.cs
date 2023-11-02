#region Header Info

// Copyright 2023 Rod Johnson.  All rights reserved

#endregion

using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using TranslationPro.Base.Common.Middleware.Bases;
using TranslationPro.Base.Languages.Interfaces;
using TranslationPro.Shared.Controllers;
using TranslationPro.Shared.Languages;

namespace TranslationPro.Api.Controllers;

public class LanguagesController : BaseController, ILanguagesController
{
    private readonly ILanguageService _languageService;

    public LanguagesController(IServiceProvider serviceProvider, ILanguageService languageService) : base(
        serviceProvider)
    {
        _languageService = languageService;
    }

    [HttpGet]
    public async Task<List<LanguageDto>> GetLanguagesAsync()
    {
        return await _languageService.GetLanguagesAsync<LanguageDto>().ConfigureAwait(false);
    }
}