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
using TranslationPro.Base.Translations.Entities;
using TranslationPro.Shared.Common;
using TranslationPro.Shared.Models;

namespace TranslationPro.Base.ApplicationLanguages.Services
{
    internal class ApplicationEngineLanguageService : BaseService<ApplicationEngineLanguage>, IApplicationEngineLanguageService
    {
        private readonly ILogger<ApplicationEngineLanguageService> _logger;

        private static string GetLogMessage(string message, [CallerMemberName] string callerName = null)
        {
            return $"[{nameof(ApplicationEngineLanguageService)}.{callerName}] - {message}";
        }


        private readonly IRepositoryAsync<Application> _applicationRepository;
        private readonly IRepositoryAsync<ApplicationTranslation> _translationRepository;
        public ApplicationEngineLanguageService(IServiceProvider serviceProvider, ILogger<ApplicationEngineLanguageService> logger) : base(serviceProvider)
        {
            _logger = logger;
            _applicationRepository = UnitOfWork.RepositoryAsync<Application>();
            _translationRepository = UnitOfWork.RepositoryAsync<ApplicationTranslation>();
        }

        private IQueryable<Application> Applications => _applicationRepository.Queryable().Include(x => x.EngineLanguages)
            .Include(x => x.Phrases).Include(x => x.Translations);

        private IQueryable<ApplicationTranslation> Translations => _translationRepository.Queryable();

        private IQueryable<ApplicationEngineLanguage> ApplicationLanguages =>
            Repository.Queryable().Include(x => x.Translations);

        public async Task<Result> AddLanguageToApplication(Guid applicationId, ApplicationLanguageInput input)
        {
            _logger.LogInformation(GetLogMessage("Adding language: {0} to application: {1}"), input.Language, applicationId);

            var application = await Applications.Where(x => x.Id == applicationId).FirstAsync();

            var appLanguage = application.EngineLanguages.FirstOrDefault(x => x.LanguageId == input.Language);
            if (appLanguage != null)
                return Result.Success();

            // assuming the app language doesn't exist, create new one
            appLanguage = new ApplicationEngineLanguage()
            {
                ApplicationId = applicationId,
                LanguageId = input.Language,
                ObjectState = ObjectState.Added
            };

            foreach (var phrase in application.Phrases)
            {
                // create a new translation record for each phrase
                phrase.MachineTranslations.Add(new ApplicationTranslation()
                {
                    LanguageId = input.Language,
                    ApplicationId = applicationId,
                    Text = null,
                    TranslationDate = null,
                    ObjectState = ObjectState.Added
                });
            }

            var records = Repository.InsertOrUpdateGraph(appLanguage, true);
            if (records > 0)
                return Result.Success();

            return Result.Failed();
        }

        public async Task<Result> RemoveLanguageFromApplication(Guid applicationId, string languageId)
        {
            _logger.LogInformation(GetLogMessage("Removing language: {0} from application: {1}"), languageId, applicationId);

            var translations = await Translations
                .Where(x => x.ApplicationId == applicationId && x.LanguageId == languageId)
                .ToListAsync();

            foreach (var translation in translations)
            {
                _translationRepository.Delete(translation, false);
            }

            var count = _translationRepository.Commit();

            var applicationLanguage = await ApplicationLanguages
                .Where(x => x.ApplicationId == applicationId && x.LanguageId == languageId)
                .FirstAsync();

            applicationLanguage.ObjectState = ObjectState.Deleted;
            

            var records = Repository.InsertOrUpdateGraph(applicationLanguage, true);
            if(records > 0)
                return Result.Success();

            return Result.Failed();
        }
    }
}
