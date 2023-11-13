#region Header Info

// Copyright 2023 Rod Johnson.  All rights reserved

#endregion

using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using TranslationPro.Base.Common.Middleware.Bases;
using TranslationPro.Base.Managers;
using TranslationPro.Base.Services;
using TranslationPro.Shared.Common;
using TranslationPro.Shared.Interfaces;
using TranslationPro.Shared.Models;

namespace TranslationPro.Api.Controllers;

[Route("v1.0/applications/{applicationId}/phrases/{phraseId}/translations")]
public class TranslationsController : BaseController, ITranslationsController
{
    private readonly ApplicationTranslationManager _applicationTranslationManager;

    public TranslationsController(IServiceProvider serviceProvider, 
        ApplicationTranslationManager applicationTranslationManager) : base(
        serviceProvider)
    {
        _applicationTranslationManager = applicationTranslationManager;
    }


    [HttpPut()]
    public async Task<Result> ReplaceTranslation([FromRoute] Guid applicationId, [FromRoute] int phraseId,
        [FromBody] TranslationReplacementOptions options)
    {
        await AssertUserHasAccessToApplication(applicationId);
        return await _applicationTranslationManager.ReplaceTranslation(applicationId, phraseId, options);
    }
}