#region Header Info

// Copyright 2023 Rod Johnson.  All rights reserved

#endregion

using System;
using System.Threading.Tasks;
using TranslationPro.Base.Services;
using TranslationPro.Shared.Common;
using TranslationPro.Shared.Models;
using TranslationPro.Shared.Results;

namespace TranslationPro.Base.Managers;

public class ApplicationLanguageManager
{


    private readonly IApplicationLanguageService _applicationLanguageService;
    private readonly IApplicationPhraseService _applicationPhraseService;
    private readonly IApplicationTranslationService _applicationTranslationService;
    private readonly IPhraseService _phraseService;
    private readonly IMachineTranslationService _machineTranslationService;

    public ApplicationLanguageManager(
        IApplicationLanguageService applicationLanguageService,
        IApplicationPhraseService applicationPhraseService,
        IApplicationTranslationService applicationTranslationService,
        IPhraseService phraseService,
        IMachineTranslationService machineTranslationService)
    {
        _applicationLanguageService = applicationLanguageService;
        _applicationPhraseService = applicationPhraseService;
        _applicationTranslationService = applicationTranslationService;
        _phraseService = phraseService;
        _machineTranslationService = machineTranslationService;
    }
    public async Task<LanguageAddedResult> AddLanguageToApplication(Guid applicationId, ApplicationLanguageOptions options)
    {
        var phraseIds = await _applicationPhraseService.GetPhraseIdsForApplication(applicationId);
        var retVal = new LanguageAddedResult
        {
            PhrasesCreated = await _phraseService.EnsurePhrasesWithLanguage(applicationId, options.Language, phraseIds)
        };

        var result = await _applicationLanguageService.AddLanguageToApplication(applicationId, options);
        if (result.Succeeded)
        {
            retVal.Succeeded = true;
            retVal.TranslationsCreated = await _machineTranslationService.ProcessTranslationsAsync(applicationId);
            retVal.TranslationsCopied = await _applicationTranslationService.CopyTranslationsFromLanguage(applicationId, options.Language);
        }
        else
        {
            retVal.Errors = result.Errors;
        }
        return retVal;
    }

    public Task<Result> RemoveLanguageFromApplication(Guid applicationId, string languageId)
    {
        return _applicationLanguageService.RemoveLanguageFromApplication(applicationId, languageId);
    }
}