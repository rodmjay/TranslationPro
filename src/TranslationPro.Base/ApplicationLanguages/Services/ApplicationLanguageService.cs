using System;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
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
    internal class ApplicationLanguageService : BaseService<ApplicationLanguage>, IApplicationLanguageService
    {
        private readonly IRepositoryAsync<Application> _applicationRepository;
        public ApplicationLanguageService(IServiceProvider serviceProvider) : base(serviceProvider)
        {
            _applicationRepository = UnitOfWork.RepositoryAsync<Application>();
        }

        private IQueryable<Application> Applications => _applicationRepository.Queryable().Include(x => x.Languages)
            .Include(x => x.Phrases).Include(x => x.Translations);

        private IQueryable<ApplicationLanguage> ApplicationLanguages =>
            Repository.Queryable().Include(x => x.Translations);

        public async Task<Result> AddLanguageToApplication(Guid applicationId, ApplicationLanguageInput input)
        {
            var application = await Applications.Where(x => x.Id == applicationId).FirstAsync();

            var appLanguage = application.Languages.FirstOrDefault(x => x.LanguageId == input.Language);
            if (appLanguage != null)
                return Result.Success();

            // assuming the app language doesn't exist, create new one
            appLanguage = new ApplicationLanguage()
            {
                ApplicationId = applicationId,
                LanguageId = input.Language,
                ObjectState = ObjectState.Added
            };

            foreach (var phrase in application.Phrases)
            {
                // create a new translation record for each phrase
                phrase.Translations.Add(new Translation()
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
            var applicationLanguage = await ApplicationLanguages
                .Where(x => x.ApplicationId == applicationId && x.LanguageId == languageId)
                .FirstAsync();

            applicationLanguage.ObjectState = ObjectState.Deleted;

            foreach (var translation in applicationLanguage.Translations)
            {
                translation.ObjectState = ObjectState.Deleted;
            }

            var records = Repository.InsertOrUpdateGraph(applicationLanguage, true);
            if(records > 0)
                return Result.Success();

            return Result.Failed();
        }
    }
}
