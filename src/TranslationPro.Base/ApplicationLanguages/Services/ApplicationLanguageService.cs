using System;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using TranslationPro.Base.ApplicationLanguages.Entities;
using TranslationPro.Base.ApplicationLanguages.Interfaces;
using TranslationPro.Base.Applications.Entities;
using TranslationPro.Base.Common.Data.Enums;
using TranslationPro.Base.Common.Data.Interfaces;
using TranslationPro.Base.Common.Services.Bases;
using TranslationPro.Base.Phrases.Entities;
using TranslationPro.Shared.Common;
using TranslationPro.Shared.Models;

namespace TranslationPro.Base.ApplicationLanguages.Services
{
    internal class ApplicationLanguageService : BaseService<ApplicationLanguage>, IApplicationEngineLanguageService
    {
        private readonly ILogger<ApplicationLanguageService> _logger;

        private static string GetLogMessage(string message, [CallerMemberName] string callerName = null)
        {
            return $"[{nameof(ApplicationLanguageService)}.{callerName}] - {message}";
        }

        private readonly IRepositoryAsync<Application> _applicationRepository;
        public ApplicationLanguageService(IServiceProvider serviceProvider, ILogger<ApplicationLanguageService> logger) : base(serviceProvider)
        {
            _logger = logger;
            _applicationRepository = UnitOfWork.RepositoryAsync<Application>();
        }

        private IQueryable<Application> Applications => _applicationRepository.Queryable()
            .Include(x => x.Languages)
            .ThenInclude(x=>x.Translations)
            .IgnoreQueryFilters();

        private IQueryable<ApplicationLanguage> ApplicationLanguages =>
            Repository.Queryable()
                .Include(x => x.Translations)
                .Include(x => x.Language)
                .Include(x => x.Application);

        public async Task<Result> AddLanguageToApplication(Guid applicationId, ApplicationLanguageInput input)
        {
            _logger.LogInformation(GetLogMessage("Adding language: {0} to application: {1}"), input.Language, applicationId);

            var application = await Applications.Where(x => x.Id == applicationId).FirstAsync();

            var appLanguage = application.Languages.FirstOrDefault(x => x.LanguageId == input.Language);

            if (appLanguage != null)
            {
                if (appLanguage.IsDeleted == false)
                {
                    return Result.Success();
                }

                if (appLanguage.IsDeleted)
                {
                    appLanguage.IsDeleted = false;
                    appLanguage.ObjectState = ObjectState.Modified;
                    
                    foreach (var translation in appLanguage.Translations)
                    {
                        translation.IsDeleted = false;
                        translation.ObjectState = ObjectState.Modified;
                    }
                    
                    var records = Repository.InsertOrUpdateGraph(appLanguage, true);
                    if (records > 0)
                        return Result.Success();

                    return Result.Failed();
                }
            }
            else
            {
                appLanguage = new ApplicationLanguage()
                {
                    ApplicationId = applicationId,
                    LanguageId = input.Language,
                    ObjectState = ObjectState.Added
                };

                var records = Repository.Update(appLanguage, true);
                if (records > 0)
                    return Result.Success();

            }

            return Result.Failed();
        }

        public async Task<Result> RemoveLanguageFromApplication(Guid applicationId, string languageId)
        {
            var applicationLanguage = await ApplicationLanguages
                .Where(x => x.ApplicationId == applicationId && x.LanguageId == languageId)
                .FirstOrDefaultAsync();

            if(applicationLanguage == null)
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
    }
}
