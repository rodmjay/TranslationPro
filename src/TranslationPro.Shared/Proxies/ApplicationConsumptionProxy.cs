#region Header Info

// Copyright 2023 Rod Johnson.  All rights reserved

#endregion

using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using TranslationPro.Shared.Interfaces;
using TranslationPro.Shared.Models;

namespace TranslationPro.Shared.Proxies;

public class ApplicationConsumptionProxy : BaseProxy, IApplicationConsumptionController
{
    public ApplicationConsumptionProxy(HttpClient httpClient) : base(httpClient)
    {
    }

    public Task<Dictionary<DateTime, ConsumptionInfo>> GetConsumptionInfo(Guid applicationId, DateTime? startDate, DateTime? endDate)
    {
        return DoGet<Dictionary<DateTime, ConsumptionInfo>>($"{ApplicationUrl}/{applicationId}/consumption");
    }
}