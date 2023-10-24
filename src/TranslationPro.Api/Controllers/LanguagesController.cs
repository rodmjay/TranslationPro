using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using TranslationPro.Base.Common.Middleware.Bases;
using TranslationPro.Base.Languages.Interfaces;
using TranslationPro.Base.Languages.Models;

namespace TranslationPro.Api.Controllers;

public class LanguagesController : BaseController
{
    private readonly ILanguageService _languageService;

    public LanguagesController(IServiceProvider serviceProvider, ILanguageService languageService) : base(
        serviceProvider)
    {
        _languageService = languageService;
    }

    [HttpGet]
    public async Task<List<LanguageDto>> GetLanguages()
    {
        return await _languageService.GetLanguagesAsync<LanguageDto>().ConfigureAwait(false);
    }
}