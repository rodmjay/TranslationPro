using System;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using TranslationPro.Base.Common.Data.Enums;
using TranslationPro.Base.Common.Data.Interfaces;
using TranslationPro.Base.Common.Services.Bases;
using TranslationPro.Base.Entities;
using TranslationPro.Shared.Common;

namespace TranslationPro.Base.Services
{
    internal class ApplicationLanguageService : BaseService<ApplicationLanguage>, IApplicationLanguageService
    {
        private readonly ILogger<ApplicationLanguageService> _logger;

        private static string GetLogMessage(string message, [CallerMemberName] string callerName = null)
        {
            return $"[{nameof(ApplicationLanguageService)}.{callerName}] - {message}";
        }

        private readonly IRepositoryAsync<Application> _applicationRepository;
        public ApplicationLanguageService(IServiceProvider serviceProvider,
            ILogger<ApplicationLanguageService> logger) : base(serviceProvider)
        {
            _logger = logger;
            _applicationRepository = UnitOfWork.RepositoryAsync<Application>();
        }

        private IQueryable<Application> Applications => _applicationRepository.Queryable()
            .Include(x => x.Languages)
            .ThenInclude(x => x.Translations)
            .IgnoreQueryFilters();

        private IQueryable<ApplicationLanguage> ApplicationLanguages =>
            Repository.Queryable()
                .Include(x => x.Translations)
                .Include(x => x.Application)
                .IgnoreQueryFilters();
        

        public async Task<Result> RemoveLanguageFromApplication(Guid applicationId, string languageId)
        {
            var applicationLanguage = await ApplicationLanguages
                .Where(x => x.ApplicationId == applicationId && x.LanguageId == languageId)
                .FirstOrDefaultAsync();

            if (applicationLanguage == null)
                return Result.Success();

            foreach (var translation in applicationLanguage.Translations)
            {
                translation.IsDeleted = true;
                translation.ObjectState = ObjectState.Modified;
            }

            applicationLanguage.IsDeleted = true;
            applicationLanguage.ObjectState = ObjectState.Modified;

            var records = Repository.Update(applicationLanguage, true);
            if (records > 0)
                return Result.Success();
            return Result.Failed();
        }

        public Task<string[]> GetLanguagesForApplication(Guid applicationId)
        {
            return ApplicationLanguages.Where(x => x.ApplicationId == applicationId).Select(x => x.LanguageId)
                .ToArrayAsync();
        }

        public async Task EnsureApplicationLanguages(Guid applicationId, string[] languageIds)
        {
            var appLanguages = await ApplicationLanguages
                .Where(x => x.ApplicationId == applicationId && languageIds.Contains(x.LanguageId)).ToListAsync();


            foreach (var languageId in languageIds)
            {
                var appLanguage = appLanguages.FirstOrDefault(x => x.LanguageId == languageId);

                if (appLanguage == null)
                {
                    appLanguage = new  ApplicationLanguage()
                    {
                        ApplicationId = applicationId,
                        LanguageId = languageId,
                        ObjectState = ObjectState.Added
                    };

                    Repository.Insert(appLanguage);
                }
                else
                {
                    appLanguage.IsDeleted = false;
                    appLanguage.ObjectState = ObjectState.Modified;

                    foreach (var translation in appLanguage.Translations)
                    {
                        translation.ObjectState = ObjectState.Modified;
                        translation.IsDeleted = false;
                    }


                    Repository.Update(appLanguage);
                }

            }

            Repository.Commit();
        }
    }
}
