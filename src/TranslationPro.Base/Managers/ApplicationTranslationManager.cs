#region Header Info

// Copyright 2023 Rod Johnson.  All rights reserved

#endregion

using System.Threading.Tasks;
using System;
using TranslationPro.Base.Services;
using TranslationPro.Shared.Common;
using TranslationPro.Shared.Models;

namespace TranslationPro.Base.Managers;

public class ApplicationTranslationManager
{
    private readonly IApplicationTranslationService _applicationTranslationService;

    public ApplicationTranslationManager(
        IApplicationTranslationService applicationTranslationService)
    {
        _applicationTranslationService = applicationTranslationService;
    }

    public Task<Result> ReplaceTranslation(Guid applicationId, int phraseId, TranslationReplacementOptions input)
    {
        return _applicationTranslationService.ReplaceTranslation(applicationId, phraseId, input);
    }

}