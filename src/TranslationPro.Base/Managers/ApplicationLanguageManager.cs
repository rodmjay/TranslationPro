#region Header Info

// Copyright 2023 Rod Johnson.  All rights reserved

#endregion

using System;
using System.Threading.Tasks;
using TranslationPro.Base.Messaging;
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
    private readonly JobSender _jobSender;
    private readonly IJobService _jobService;

    public ApplicationLanguageManager(
        IApplicationLanguageService applicationLanguageService,
        IApplicationPhraseService applicationPhraseService,
        IApplicationTranslationService applicationTranslationService,
        JobSender jobSender,
        IJobService jobService)
    {
        _applicationLanguageService = applicationLanguageService;
        _applicationPhraseService = applicationPhraseService;
        _applicationTranslationService = applicationTranslationService;
        _jobSender = jobSender;
        _jobService = jobService;
    }
    public async Task<Result> AddLanguageToApplication(Guid applicationId, ApplicationLanguageOptions options)
    {

        var addLanguageToApplicationResult = await _applicationLanguageService.AddLanguageToApplication(applicationId, options);

        if (addLanguageToApplicationResult.Succeeded)
        {
            var createJob = new JobCreateOptions
            {
                Languages = new[] { options.Language },
                Phrases = await _applicationPhraseService.GetPhraseIdsForApplication(applicationId)
            };

            var createJobResult = await _jobService.CreateJob(applicationId, createJob);

            
            await _jobSender.SendJobMessage(applicationId, int.Parse(createJobResult.Id.ToString()));

            return createJobResult;

        }

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