using System;
using System.Threading.Tasks;
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
        private IRepositoryAsync<Language> _languageRepository;
        public TranslationService(IServiceProvider serviceProvider, IUnitOfWorkAsync unitOfWork) : base(serviceProvider)
        {
            _languageRepository = unitOfWork.RepositoryAsync<Language>();
        }

        public Task<Result> CreateTranslation(Guid applicationId, CreateTranslationDto input)
        {


            throw new NotImplementedException();
        }

        public Task<Result> UpdateTranslation(Guid applicationId, int translationId, UpdateTranslationDto input)
        {
            throw new NotImplementedException();
        }

        public Task<PagedList<T>> GetTranslations<T>(Guid applicationId, PagingQuery query)
        {
            throw new NotImplementedException();
        }
    }
}
