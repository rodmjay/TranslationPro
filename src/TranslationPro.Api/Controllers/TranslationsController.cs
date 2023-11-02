#region Header Info

// Copyright 2023 Rod Johnson.  All rights reserved

#endregion

using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using TranslationPro.Api.Interfaces;
using TranslationPro.Base.Common.Middleware.Bases;
using TranslationPro.Base.Translations.Interfaces;
using TranslationPro.Shared.Common;
using TranslationPro.Shared.Translations;

namespace TranslationPro.Api.Controllers;

[Route("v1.0/applications/{applicationId}/phrases/{phraseId}/translations")]
public class TranslationsController : BaseController, ITranslationsController
{
    private readonly ITranslationService _translationService;

    public TranslationsController(IServiceProvider serviceProvider, ITranslationService translationService) : base(
        serviceProvider)
    {
        _translationService = translationService;
    }

    [HttpPost]
    public async Task<Result> SaveTranslation([FromRoute] Guid applicationId, [FromRoute] int phraseId,
        [FromBody] TranslationInput input)
    {
        await AssertUserHasAccessToApplication(applicationId);
        return await _translationService.SaveTranslation(applicationId, phraseId, input).ConfigureAwait(false);
    }
}