using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using TranslationPro.Base.Common.Middleware.Bases;
using TranslationPro.Base.Services;
using TranslationPro.Shared.Interfaces;
using TranslationPro.Shared.Models;

namespace TranslationPro.Api.Controllers;

[AllowAnonymous]
public class LanguagesController : BaseController, ILanguagesController
{
    private readonly ILanguageService _languageService;

    public LanguagesController(IServiceProvider serviceProvider, ILanguageService languageService) : base(serviceProvider)
    {
        _languageService = languageService;
    }

    [HttpGet]
    public async Task<List<LanguageOutput>> GetLanguagesAsync()
    {
        return await _languageService.GetLanguagesAsync<LanguageOutput>();
    }

    [HttpGet("{languageId}")]
    public Task<LanguageOutput> GetLanguageAsync([FromRoute] string languageId)
    {
        return _languageService.GetLanguageAsync<LanguageOutput>(languageId);
    }
}