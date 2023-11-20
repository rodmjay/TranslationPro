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
    private readonly IApplicationLanguageService _applicationLanguageService;
    private readonly IApplicationPhraseService _applicationPhraseService;
    private readonly IApplicationTranslationService _applicationTranslationService;

    public ApplicationLanguageManager(
        IApplicationLanguageService applicationLanguageService,
        IApplicationPhraseService applicationPhraseService,
        IApplicationTranslationService applicationTranslationService)
    {
        _applicationLanguageService = applicationLanguageService;
        _applicationPhraseService = applicationPhraseService;
        _applicationTranslationService = applicationTranslationService;
    }
    public async Task<Result> AddLanguageToApplication(Guid applicationId, ApplicationLanguageOptions options)
    {
        var addLanguageToApplicationResult = await _applicationLanguageService
            .AddLanguageToApplication(applicationId, options);
        
        
        return addLanguageToApplicationResult;
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