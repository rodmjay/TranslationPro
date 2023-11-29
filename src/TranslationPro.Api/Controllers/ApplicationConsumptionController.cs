#region Header Info

// Copyright 2023 Rod Johnson.  All rights reserved

#endregion

using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using TranslationPro.Base.Common.Middleware.Bases;
using TranslationPro.Base.Services;
using TranslationPro.Shared.Interfaces;
using TranslationPro.Shared.Models;

namespace TranslationPro.Api.Controllers;

[Route("v1.0/applications/{applicationId}/consumption")]
public class ApplicationConsumptionController : BaseController, IApplicationConsumptionController
{
    private readonly IApplicationConsumptionService _consumptionService;

    public ApplicationConsumptionController(IServiceProvider serviceProvider, IApplicationConsumptionService consumptionService) : base(serviceProvider)
    {
        _consumptionService = consumptionService;
    }

    [HttpGet]
    public async Task<Dictionary<DateTime, ConsumptionInfo>> GetConsumptionInfo([FromRoute] Guid applicationId,
        [FromQuery] DateTime? startDate, [FromQuery] DateTime? endDate)
    {
        var normalizedStartDate = startDate ?? DateTime.MinValue;
        var normalizedEndDate = endDate ?? DateTime.MinValue;

        var consumptionInfo =
            await _consumptionService.GetConsumptionInfo(applicationId, normalizedStartDate, normalizedEndDate);

        return consumptionInfo;
    }
}