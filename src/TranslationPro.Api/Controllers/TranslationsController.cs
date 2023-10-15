using System;
using TranslationPro.Base.Common.Middleware.Bases;
using TranslationPro.Base.Translations.Interfaces;

namespace TranslationPro.Api.Controllers;

public class TranslationsController : BaseController
{
    private readonly ITranslationService _translationService;

    protected TranslationsController(IServiceProvider serviceProvider, ITranslationService translationService) : base(serviceProvider)
    {
        _translationService = translationService;
    }


}