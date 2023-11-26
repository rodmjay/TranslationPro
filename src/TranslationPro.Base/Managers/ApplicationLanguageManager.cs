#region Header Info

// Copyright 2023 Rod Johnson.  All rights reserved

#endregion

using System;
using System.Linq;
using System.Threading.Tasks;
using TranslationPro.Base.Services;
using TranslationPro.Shared.Common;
using TranslationPro.Shared.Models;

namespace TranslationPro.Base.Managers;

public class ApplicationLanguageManager
{
    private readonly IApplicationLanguageService _applicationLanguageService;
    private readonly IApplicationTranslationService _applicationTranslationService;

    public ApplicationLanguageManager(
        IApplicationLanguageService applicationLanguageService,
        IApplicationTranslationService applicationTranslationService)
    {
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

    public async Task<string[]> SyncLanguages(Guid applicationId, string[] languageIds)
    {
        var applicationLanguages = await _applicationLanguageService.GetLanguagesForApplication(applicationId);

        var languagesToRemove = applicationLanguages.Where(x => !languageIds.Contains(x)).ToList();

        var languagesToAdd = languageIds.Except(applicationLanguages).ToArray();

        foreach (var languageId in languagesToRemove)
        {
            await _applicationLanguageService.RemoveLanguageFromApplication(applicationId, languageId);
        }

        return languagesToAdd;
    }
}