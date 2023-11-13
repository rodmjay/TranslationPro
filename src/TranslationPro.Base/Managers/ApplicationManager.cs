using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TranslationPro.Base.Interfaces;
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

    }
}
