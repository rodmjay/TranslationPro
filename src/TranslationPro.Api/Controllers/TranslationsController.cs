#region Header Info

// Copyright 2023 Rod Johnson.  All rights reserved

#endregion

using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using TranslationPro.Base.Common.Middleware.Bases;
using TranslationPro.Base.Interfaces;
using TranslationPro.Base.Services;
using TranslationPro.Shared.Common;
using TranslationPro.Shared.Interfaces;
using TranslationPro.Shared.Models;

namespace TranslationPro.Api.Controllers;

[Route("v1.0/applications/{applicationId}/phrases/{phraseId}/translations")]
public class TranslationsController : BaseController, ITranslationsController
{
    private readonly IApplicationTranslationService _applicationTranslationService;
    private readonly IMachineTranslationService _machineTranslationService;

    public TranslationsController(IServiceProvider serviceProvider, 
        IApplicationTranslationService applicationTranslationService,
        IMachineTranslationService machineTranslationService) : base(
        serviceProvider)
    {
        _applicationTranslationService = applicationTranslationService;
        _machineTranslationService = machineTranslationService;
    }


    [HttpPut()]
    public async Task<Result> ReplaceTranslation([FromRoute] Guid applicationId, [FromRoute] int phraseId,
        [FromBody] TranslationReplacementOptions options)
    {
        await AssertUserHasAccessToApplication(applicationId);
        return await _applicationTranslationService.ReplaceTranslation(applicationId, phraseId, options);
    }
}