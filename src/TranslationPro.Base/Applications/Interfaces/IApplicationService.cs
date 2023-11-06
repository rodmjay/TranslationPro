#region Header Info

// Copyright 2023 Rod Johnson.  All rights reserved

#endregion

using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using TranslationPro.Base.Applications.Entities;
using TranslationPro.Base.Common.Services.Interfaces;
using TranslationPro.Shared.Common;
using TranslationPro.Shared.Models;

namespace TranslationPro.Base.Applications.Interfaces;

public interface IApplicationService : IService<Application>
{
    Task<T> GetApplication<T>(Guid applicationId) where T : ApplicationOutput;
    Task<List<T>> GetApplicationsAsync<T>();
    Task<Result> CreateApplicationAsync(int userId, ApplicationCreateOptions input);
    Task<List<T>> GetApplicationsForUserAsync<T>(int userId) where T : ApplicationOutput;
    Task<Result> UpdateApplicationAsync(Guid applicationId, ApplicationOptions input);

    Task<Result> DeleteApplicationAsync(Guid applicationId);
}