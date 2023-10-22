using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using TranslationPro.Base.Common.Middleware.Bases;
using TranslationPro.Base.Common.Models;
using TranslationPro.Base.Translations.Interfaces;
using TranslationPro.Base.Translations.Models;

namespace TranslationPro.Api.Controllers;

[Route("v1.0/{applicationId}/translations")]
public class TranslationsController : BaseController
{
    private readonly ITranslationService _translationService;

    public TranslationsController(IServiceProvider serviceProvider, ITranslationService translationService) : base(serviceProvider)
    {
        _translationService = translationService;
    }
    
}