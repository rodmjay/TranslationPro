using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using TranslationPro.Base.Applications.Entities;
using TranslationPro.Base.Applications.Interfaces;
using TranslationPro.Base.Applications.Models;
using TranslationPro.Base.Common.Models;
using TranslationPro.Base.Common.Services.Bases;

namespace TranslationPro.Base.Applications.Services
{
    public class ApplicationService  :BaseService<Application>, IApplicationService
    {
        public ApplicationService(IServiceProvider serviceProvider) : base(serviceProvider)
        {
        }


        public Task<Result> CreateApplication(int userId, CreateApplicationDto dto)
        {
            throw new NotImplementedException();
        }

        public Task<List<T>> GetApplications<T>(int userId) where T : ApplicationDto
        {
            throw new NotImplementedException();
        }
    }
}
