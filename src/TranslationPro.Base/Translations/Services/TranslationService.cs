using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper.QueryableExtensions;
using Microsoft.EntityFrameworkCore;
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

        private IQueryable<Translation> Translations => Repository.Queryable();

        public Task<Result> CreateTranslationAsync(Guid applicationId, int phraseId, TranslationInput input)
        {
            throw new NotImplementedException();
        }

        public Task<Result> UpdateTranslationAsync(Guid applicationId, int translationId, TranslationInput input)
        {
            throw new NotImplementedException();
        }

        public Task<List<T>> GetTranslationsForLanguageAndApplicationAsync<T>(Guid applicationId, string languageId) where T : TranslationDto
        {
            return Translations.Where(x => x.ApplicationId == applicationId && x.LanguageId == languageId)
                .ProjectTo<T>(ProjectionMapping).ToListAsync();
        }
    }
}
