using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper.QueryableExtensions;
using Microsoft.EntityFrameworkCore;
using TranslationPro.Base.Applications.Entities;
using TranslationPro.Base.Applications.Interfaces;
using TranslationPro.Base.Applications.Models;
using TranslationPro.Base.Common.Models;
using TranslationPro.Base.Common.Services.Bases;

namespace TranslationPro.Base.Applications.Services
{
    public class ApplicationService : BaseService<Application>, IApplicationService
    {
        public ApplicationService(IServiceProvider serviceProvider) : base(serviceProvider)
        {
        }

        private IQueryable<Application> Applications => Repository.Queryable();

        public Task<Result> CreateApplicationAsync(int userId, ApplicationInputDto inputDto)
        {
            throw new NotImplementedException();
        }

        public Task<List<T>> GetApplicationsForUserAsync<T>(int userId) where T : ApplicationDto
        {
            return Applications.Where(x => x.UserId == userId).ProjectTo<T>(ProjectionMapping).ToListAsync();
        }

        public Task<Result> UpdateApplicationAsync(Guid applicationId, ApplicationInputDto dto)
        {
            throw new NotImplementedException();
        }

    }
}
