#region Header Info

// Copyright 2023 Rod Johnson.  All rights reserved

#endregion

using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using TranslationPro.Shared.Common;
using TranslationPro.Shared.Models;

namespace TranslationPro.Shared.Interfaces;

public interface IApplicationsController
{
    Task<ApplicationOutput> GetApplicationAsync(Guid applicationId);
    Task<List<ApplicationOutput>> GetApplicationsAsync();
    Task<Result> CreateApplicationAsync(ApplicationCreateOptions input);
    Task<Result> DeleteApplicationAsync(Guid applicationId);
    Task<Result> UpdateApplicationAsync(Guid applicationId, ApplicationOptions input);
}