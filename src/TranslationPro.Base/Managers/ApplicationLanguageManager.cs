#region Header Info

// Copyright 2023 Rod Johnson.  All rights reserved

#endregion

using System;
using System.Threading.Tasks;
using TranslationPro.Base.Services;
using TranslationPro.Shared.Common;
using TranslationPro.Shared.Models;

namespace TranslationPro.Base.Managers;

public class ApplicationLanguageManager
{
    private readonly ApplicationPhraseManager _phraseManager;
    private readonly IApplicationLanguageService _applicationLanguageService;
    private readonly IApplicationTranslationService _applicationTranslationService;

    public ApplicationLanguageManager(
        ApplicationPhraseManager phraseManager,
        IApplicationLanguageService applicationLanguageService,
        IApplicationTranslationService applicationTranslationService)
    {
        _phraseManager = phraseManager;
        _applicationLanguageService = applicationLanguageService;
        _applicationTranslationService = applicationTranslationService;
    }
    public Task<Result> RemoveLanguageFromApplication(Guid applicationId, string languageId)
    {
        return _applicationLanguageService.RemoveLanguageFromApplication(applicationId, languageId);
    }

    public Task<PagedList<T>> GetTranslationsForApplicationForLanguage<T>(Guid applicationId, string languageId,
        PagingQuery paging) where T : ApplicationTranslationOutput
    {
        return _applicationTranslationService.GetTranslationsForApplicationForLanguage<T>(applicationId, languageId,
            paging);
    }
}