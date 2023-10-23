using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper.QueryableExtensions;
using Microsoft.EntityFrameworkCore;
using TranslationPro.Base.Applications.Entities;
using TranslationPro.Base.Common.Data.Enums;
using TranslationPro.Base.Common.Data.Interfaces;
using TranslationPro.Base.Common.Models;
using TranslationPro.Base.Common.Services.Bases;
using TranslationPro.Base.Languages.Entities;
using TranslationPro.Base.Phrases.Entities;
using TranslationPro.Base.Translations.Entities;
using TranslationPro.Base.Translations.Interfaces;
using TranslationPro.Base.Translations.Models;

namespace TranslationPro.Base.Translations.Services
{
    public class TranslationService : BaseService<Translation>, ITranslationService
    {
        private readonly IRepositoryAsync<Language> _languageRepository;
        private readonly IRepositoryAsync<Application> _applicationRepository;
        private readonly IRepositoryAsync<Phrase> _phraseRepository;
        public TranslationService(IServiceProvider serviceProvider) : base(serviceProvider)
        {
            _languageRepository = UnitOfWork.RepositoryAsync<Language>();
            _applicationRepository = UnitOfWork.RepositoryAsync<Application>();
            _phraseRepository = UnitOfWork.RepositoryAsync<Phrase>();
        }

        private IQueryable<Translation> Translations => Repository.Queryable();
        private IQueryable<Phrase> Phrases => _phraseRepository.Queryable().Include(x=>x.Translations);
        private IQueryable<Application> Applications => _applicationRepository.Queryable().Include(x => x.Languages);

        /// <summary>
        /// Works for both create and update
        /// </summary>
        /// <param name="applicationId"></param>
        /// <param name="phraseId"></param>
        /// <param name="input"></param>
        /// <returns></returns>
        public async Task<Result> SaveTranslation(Guid applicationId, int phraseId, TranslationInput input)
        {
            var phrase = await Phrases.Where(x => x.Id == phraseId).FirstOrDefaultAsync();
            
            if (phrase == null)
                return Result.Failed();

            var translation = phrase.Translations.FirstOrDefault(x => x.LanguageId == input.LanguageId);
            if (translation == null)
            {
                var application = await Applications.Where(x => x.Id == applicationId).FirstOrDefaultAsync();

                var langExists = application.Languages.Any(x => x.LanguageId == input.LanguageId);

                if (!langExists)
                    return Result.Failed();

                translation = new Translation
                {
                    ObjectState = ObjectState.Added
                };
            }
            else
            {
                translation.ObjectState = ObjectState.Modified;
            }

            translation.LanguageId = input.LanguageId;
            translation.PhraseId = phraseId;
            translation.ApplicationId = applicationId;
            translation.Text = input.Text;
            translation.TranslationDate = DateTime.UtcNow;

            var records = Repository.InsertOrUpdateGraph(translation, true);
            if(records > 0)
                return Result.Success();

            return Result.Failed();
        }
        

        public Task<List<T>> GetTranslationsForLanguageAndApplicationAsync<T>(Guid applicationId, string languageId) where T : TranslationDto
        {
            return Translations.Where(x => x.ApplicationId == applicationId && x.LanguageId == languageId)
                .ProjectTo<T>(ProjectionMapping).ToListAsync();
        }
    }
}
