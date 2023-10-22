using System;
using TranslationPro.Base.Common.Middleware.Bases;
using TranslationPro.Base.Languages.Interfaces;

namespace TranslationPro.Api.Controllers
{
    public class LanguagesController : BaseController
    {
        private readonly ILanguageService _languageService;

        protected LanguagesController(IServiceProvider serviceProvider, ILanguageService languageService) : base(serviceProvider)
        {
            _languageService = languageService;
        }

    }
}
