using System;
using System.Threading.Tasks;
using TranslationPro.Base.Common.Middleware.Bases;
using TranslationPro.Base.Common.Models;
using TranslationPro.Base.Translations.Interfaces;
using TranslationPro.Base.Translations.Models;

namespace TranslationPro.Api.Controllers;

public class TranslationsController : BaseController
{
    private readonly ITranslationService _translationService;

    protected TranslationsController(IServiceProvider serviceProvider, ITranslationService translationService) : base(serviceProvider)
    {
        _translationService = translationService;
    }

    public async Task<Result> CreateTranslation(CreateTranslationDto input)
    {
        Guid guid = Guid.NewGuid();
        return await _translationService.CreateTranslation(guid, input);
    }
}