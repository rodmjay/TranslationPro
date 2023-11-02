#region Header Info

// Copyright 2023 Rod Johnson.  All rights reserved

#endregion

using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using TranslationPro.Shared.Applications;
using TranslationPro.Shared.Common;

namespace TranslationPro.Api.Interfaces;

public interface IApplicationsController
{
    Task<ApplicationDto> GetApplicationAsync(Guid applicationId);
    Task<List<ApplicationDto>> GetApplicationsAsync();
    Task<Result> CreateApplicationAsync(CreateApplicationInput input);
    Task<Result> DeleteApplicationAsync(Guid applicationId);
    Task<Result> UpdateApplicationAsync(Guid applicationId, [FromBody] ApplicationInput input);
}