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
            .Include(x => x.Phrases)
            .Include(x => x.HumanTranslations)
            .Include(x=>x.Phrases)
            .ThenInclude(x => x.Phrase)
            .ThenInclude(x=>x.MachineTranslations)
        ;

        private IQueryable<ApplicationLanguage> ApplicationLanguages =>
            Repository.Queryable().Include(x => x.Language).Include(x=>x.Application);

        public async Task<Result> AddLanguageToApplication(Guid applicationId, ApplicationLanguageInput input)
        {
            _logger.LogInformation(GetLogMessage("Adding language: {0} to application: {1}"), input.Language, applicationId);

            var application = await Applications.Where(x => x.Id == applicationId).FirstAsync();

            var appLanguage = application.Languages.FirstOrDefault(x => x.LanguageId == input.Language);
            if (appLanguage != null)
                return Result.Success();
            
            appLanguage = new ApplicationLanguage()
            {
                ApplicationId = applicationId,
                LanguageId = input.Language,
                ObjectState = ObjectState.Added
            };
            
            var records = Repository.InsertOrUpdateGraph(appLanguage, true);
            if (records > 0)
                return Result.Success();

            return Result.Failed();
        }

        public async Task<Result> RemoveLanguageFromApplication(Guid applicationId, string languageId)
        {
            throw new NotImplementedException();
        }
    }
}
