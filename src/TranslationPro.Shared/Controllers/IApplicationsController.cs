#region Header Info

// Copyright 2023 Rod Johnson.  All rights reserved

#endregion

using TranslationPro.Shared.Applications;
using TranslationPro.Shared.Common;

namespace TranslationPro.Shared.Controllers;

public interface IApplicationsController
{
    Task<ApplicationDto> GetApplicationAsync(Guid applicationId);
    Task<List<ApplicationDto>> GetApplicationsAsync();
    Task<Result> CreateApplicationAsync(CreateApplicationInput input);
    Task<Result> DeleteApplicationAsync(Guid applicationId);
    Task<Result> UpdateApplicationAsync(Guid applicationId, ApplicationInput input);
}