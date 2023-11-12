#region Header Info

// Copyright 2023 Rod Johnson.  All rights reserved

#endregion

using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using TranslationPro.Base.Common.Middleware.Bases;
using TranslationPro.Base.MachineTranslations.Interfaces;
using TranslationPro.Shared.Common;
using TranslationPro.Shared.Interfaces;
using TranslationPro.Shared.Models;

namespace TranslationPro.Api.Controllers;

[Route("v1.0/applications/{applicationId}/phrases/{phraseId}/translations")]
public class TranslationsController : BaseController, ITranslationsController
{
    private readonly IMachineTranslationService _machineTranslationService;

    public TranslationsController(IServiceProvider serviceProvider, 
        IMachineTranslationService machineTranslationService) : base(
        serviceProvider)
    {
        _machineTranslationService = machineTranslationService;
    }

    [HttpPost]
    public async Task<Result> SaveTranslation([FromRoute] Guid applicationId, [FromRoute] int phraseId,
        [FromBody] TranslationOptions input)
    {
        await AssertUserHasAccessToApplication(applicationId);
        return await _machineTranslationService.SaveTranslationAsync(applicationId, phraseId, input).ConfigureAwait(false);
    }

}