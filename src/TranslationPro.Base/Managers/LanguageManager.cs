using System.Collections.Generic;
using System.Threading.Tasks;
using TranslationPro.Base.Services;
using TranslationPro.Shared.Models;

namespace TranslationPro.Base.Managers;

public class LanguageManager
{
    private readonly ILanguageService _languageService;
    private readonly IApplicationLanguageService _applicationLanguageService;
    private readonly IApplicationTranslationService _applicationTranslationService;
    private readonly IPhraseService _phraseService;
    private readonly IMachineTranslationService _machineTranslationService;

    public LanguageManager(
        ILanguageService languageService,
        IApplicationLanguageService applicationLanguageService,
        IApplicationTranslationService applicationTranslationService,
        IPhraseService phraseService,
        IMachineTranslationService machineTranslationService)
    {
        _languageService = languageService;
        _applicationLanguageService = applicationLanguageService;
        _applicationTranslationService = applicationTranslationService;
        _phraseService = phraseService;
        _machineTranslationService = machineTranslationService;
    }

    public Task<List<T>> GetLanguagesAsync<T>() where T : LanguageOutput
    {
        return _languageService.GetLanguagesAsync<T>();
    }

    public Task<List<T>> GetAllLanguagesAsync<T>() where T : LanguageOutput
    {
        return _languageService.GetAllLanguagesAsync<T>();
    }

    public Task<T> GetLanguageAsync<T>(string languageId) where T : LanguageOutput
    {
        return _languageService.GetLanguageAsync<T>(languageId);
    }
}