using System;
using System.Threading.Tasks;
using TranslationPro.Base.Applications.Entities;
using TranslationPro.Base.Common.Data.Interfaces;
using TranslationPro.Base.Common.Models;
using TranslationPro.Base.Common.Services.Bases;
using TranslationPro.Base.Languages.Entities;
using TranslationPro.Base.Translations.Entities;
using TranslationPro.Base.Translations.Interfaces;
using TranslationPro.Base.Translations.Models;

namespace TranslationPro.Base.Translations.Services
{
    public class TranslationService : BaseService<Translation>, ITranslationService
    {
        private readonly IRepositoryAsync<Language> _languageRepository;
        private readonly IRepositoryAsync<Application> _applicationRepository;
        public TranslationService(IServiceProvider serviceProvider, IUnitOfWorkAsync unitOfWork) : base(serviceProvider)
        {
            _languageRepository = unitOfWork.RepositoryAsync<Language>();
            _applicationRepository = unitOfWork.RepositoryAsync<Application>();
        }

        public Task<Result> CreateTranslationAsync(Guid applicationId, int phraseId, TranslationInput input)
        {
            throw new NotImplementedException();
        }

        public Task<Result> UpdateTranslationAsync(Guid applicationId, int translationId, TranslationInput input)
        {
            throw new NotImplementedException();
        }
        
    }
}
