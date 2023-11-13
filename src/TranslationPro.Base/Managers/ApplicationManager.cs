using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using TranslationPro.Base.Services;
using TranslationPro.Shared.Common;
using TranslationPro.Shared.Models;

namespace TranslationPro.Base.Managers
{
    public class ApplicationManager
    {
        private readonly IApplicationService _applicationService;

        public ApplicationManager(IApplicationService applicationService)
        {
            _applicationService = applicationService;
        }

        public Task<T> GetApplication<T>(Guid applicationId) where T : ApplicationOutput
        {
            return _applicationService.GetApplication<T>(applicationId);
        }

        public Task<Result> CreateApplicationAsync(int userId, ApplicationCreateOptions input)
        {
            return _applicationService.CreateApplicationAsync(userId, input);
        }

        public Task<List<T>> GetApplicationsForUserAsync<T>(int userId) where T : ApplicationOutput
        {
            return _applicationService.GetApplicationsForUserAsync<T>(userId);
        }

        public Task<Result> UpdateApplicationAsync(Guid applicationId, ApplicationOptions input)
        {
            return _applicationService.UpdateApplicationAsync(applicationId, input);
        }

        public Task<Result> DeleteApplicationAsync(Guid applicationId)
        {
            return _applicationService.DeleteApplicationAsync(applicationId);
        }
    }
}
