using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using TranslationPro.Base.Applications.Entities;
using TranslationPro.Base.Applications.Models;
using TranslationPro.Base.Common.Models;
using TranslationPro.Base.Common.Services.Interfaces;

namespace TranslationPro.Base.Applications.Interfaces
{
    public interface IApplicationService : IService<Application>
    {
        Task<List<T>> GetApplicationsAsync<T>();
        Task<Result> CreateApplicationAsync(int userId, ApplicationInput input);
        Task<List<T>> GetApplicationsForUserAsync<T>(int userId) where T : ApplicationDto;
        Task<Result> UpdateApplicationAsync(Guid applicationId, ApplicationInput input);
    }
}
