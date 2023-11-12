#region Header Info

// Copyright 2023 Rod Johnson.  All rights reserved

#endregion

using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using TranslationPro.Base.Common.Middleware.Bases;
using TranslationPro.Base.Phrases.Services;
using TranslationPro.Shared.Common;

namespace TranslationPro.Api.Controllers;

public class TransController : BaseController
{
    private readonly MicrosoftTranslationService _microsoft;
    private readonly GoogleTranslationService _google;

    [HttpPost("Microsoft")]
    public async Task<Dictionary<string, List<GenericTranslationResult>>> TranslateMicrosoft([FromBody] Dictionary<string, List<string>> toTranslate)
    {
        var result = await _microsoft.Process(toTranslate);
        return result;
    }

    [HttpPost("Google")]
    public async Task<Dictionary<string, List<GenericTranslationResult>>> TranslateGoogle([FromBody] Dictionary<string, List<string>> toTranslate)
    {
        var result = await _google.Process(toTranslate);
        return result;
    }

    public TransController(IServiceProvider serviceProvider, MicrosoftTranslationService microsoft, GoogleTranslationService google) : base(serviceProvider)
    {
        _microsoft = microsoft;
        _google = google;
    }
}