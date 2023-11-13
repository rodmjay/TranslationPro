#region Header Info

// Copyright 2023 Rod Johnson.  All rights reserved

#endregion

using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using TranslationPro.Base.Common.Middleware.Bases;
using TranslationPro.Base.Interfaces;
using TranslationPro.Shared.Interfaces;
using TranslationPro.Shared.Models;

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
    [AllowAnonymous]
    public async Task<List<LanguageOutput>> GetLanguagesAsync()
    {
        return await _languageService.GetLanguagesAsync<LanguageOutput>().ConfigureAwait(false);
    }

    [HttpGet("all")]
    [AllowAnonymous]
    public async Task<List<LanguagesWithEnginesOutput>> GetAllLanguagesAsync()
    {
        return await _languageService.GetAllLanguagesAsync<LanguagesWithEnginesOutput>().ConfigureAwait(false);
    }

    [HttpGet("details")]
    [AllowAnonymous]
    public Task<LanguagesWithEnginesOutput> GetLanguageAsync([FromQuery]string languageId)
    {
        return _languageService.GetLanguageAsync<LanguagesWithEnginesOutput>(languageId);
    }
}