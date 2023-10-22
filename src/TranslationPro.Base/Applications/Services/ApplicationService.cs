using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper.QueryableExtensions;
using Microsoft.EntityFrameworkCore;
using TranslationPro.Base.Applications.Entities;
using TranslationPro.Base.Applications.Interfaces;
using TranslationPro.Base.Applications.Models;
using TranslationPro.Base.Common.Data.Enums;
using TranslationPro.Base.Common.Data.Interfaces;
using TranslationPro.Base.Common.Models;
using TranslationPro.Base.Common.Services.Bases;
using TranslationPro.Base.Languages.Entities;

namespace TranslationPro.Base.Applications.Services
{
    public class ApplicationService : BaseService<Application>, IApplicationService
    {
        private readonly ApplicationErrorDescriber _errorDescriber;
        private readonly IRepositoryAsync<Language> _languageRepository;
        public ApplicationService(IServiceProvider serviceProvider, ApplicationErrorDescriber errorDescriber) : base(serviceProvider)
        {
            _errorDescriber = errorDescriber;
            _languageRepository = UnitOfWork.RepositoryAsync<Language>();
        }

        private IQueryable<Application> Applications => Repository.Queryable();
        private IQueryable<Language> Languages => _languageRepository.Queryable();

        public async Task<Result> CreateApplicationAsync(int userId, ApplicationInput input)
        {
            
            var application = new Application
            {
                UserId = userId,
                Name = input.Name,
                ApiKey = input.ApiKey,
                ObjectState = ObjectState.Added
            };

            // make sure the languages exist in database and remove any junk data
            var languages = await Languages.Where(x => input.Languages.Contains(x.Id)).ToListAsync();
            
            foreach (var lang in input.Languages)
            {
                var selectedLang = languages.FirstOrDefault(x => x.Id == lang);
                if (selectedLang != null)
                {
                    application.Languages.Add(new ApplicationLanguage()
                    {
                        LanguageId = selectedLang.Id,
                        ObjectState = ObjectState.Added
                    });
                }
            }

            var records = Repository.InsertOrUpdateGraph(application, true);
            if (records > 0)
                return Result.Success(application.Id);

            return Result.Failed();
        }

        public Task<List<T>> GetApplicationsForUserAsync<T>(int userId) where T : ApplicationDto
        {
            return Applications.Where(x => x.UserId == userId).ProjectTo<T>(ProjectionMapping).ToListAsync();
        }

        public Task<Result> UpdateApplicationAsync(Guid applicationId, ApplicationInput dto)
        {
            throw new NotImplementedException();
        }

    }
}
