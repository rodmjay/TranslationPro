using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using TranslationPro.Base.Common.Data.Enums;
using TranslationPro.Base.Common.Data.Interfaces;
using TranslationPro.Base.Common.Extensions;
using TranslationPro.Base.Common.Services.Bases;
using TranslationPro.Base.Entities;
using TranslationPro.Shared.Common;
using TranslationPro.Shared.Models;

namespace TranslationPro.Base.Services;

public class ApplicationTranslationService : BaseService<ApplicationTranslation>, IApplicationTranslationService
{
    private readonly IRepositoryAsync<ApplicationPhrase> _applicationPhraseRepository;
    private readonly IRepositoryAsync<Application> _applicationRepository;

    public ApplicationTranslationService(IServiceProvider serviceProvider) : base(serviceProvider)
    {
        _applicationPhraseRepository = UnitOfWork.RepositoryAsync<ApplicationPhrase>();
        _applicationRepository = UnitOfWork.RepositoryAsync<Application>();
    }

    private IQueryable<ApplicationTranslation> ApplicationTranslations => Repository.Queryable()
        .Include(x => x.ApplicationPhrase).Include(x => x.ApplicationLanguage);

    private IQueryable<Application> Applications => _applicationRepository.Queryable().Include(x => x.Languages);

    private IQueryable<ApplicationPhrase> ApplicationPhrases => _applicationPhraseRepository.Queryable()
        .Include(x => x.Translations);

    public async Task<List<ApplicationTranslation>> GetPendingTranslations(Guid applicationId, int[] phraseIds)
    {
        var translations = await ApplicationTranslations
            .Where(x => x.ApplicationId == applicationId && phraseIds.Contains(x.PhraseId) && x.Text == null)
            .ToListAsync();

        return translations;
    }

    public async Task<Result> AddTranslationsForLanguage(Guid applicationId, string languageId)
    {
        var phrases = await ApplicationPhrases.Where(x => x.ApplicationId == applicationId).ToListAsync();

        foreach (var phrase in phrases)
        {
            if (phrase.Translations.All(x => x.LanguageId != languageId))
            {
                phrase.Translations.Add(new ApplicationTranslation()
                {
                    LanguageId = languageId,
                    ObjectState = ObjectState.Added
                });
                
                _applicationPhraseRepository.InsertOrUpdateGraph(phrase, false);
            }
        }

        return Result.Success();
    }

    public Task<PagedList<T>> GetTranslationsForApplicationForLanguage<T>(Guid applicationId, string languageId, PagingQuery paging) where T : ApplicationTranslationOutput
    {
        return this.PaginateAsync<ApplicationTranslation, T>(
            x => x.ApplicationId == applicationId && x.LanguageId == languageId, paging);

    }

    public async Task<int> CopyTranslationFromPhraseList(Guid applicationId, int phraseId)
    {
        return 0;
        //var retVal = 0;

        //var application = await Applications.Where(x => x.Id == applicationId).FirstAsync();

        //var applicationPhrase = await ApplicationPhrases.Where(x => x.ApplicationId == applicationId && x.Id == phraseId)
        //    .FirstOrDefaultAsync();

        //if (applicationPhrase == null)
        //{
        //    retVal = 0;
        //    return retVal;
        //}

        //foreach (var language in application.EnabledLanguages())
        //{
        //    var machineTranslation = applicationPhrase.Phrase.MachineTranslations
        //        .OrderByDescending(x => x.Weight).FirstOrDefault(x => x.LanguageId == language);

        //    if (machineTranslation != null)
        //    {
        //        if (applicationPhrase.Translations.All(x => x.LanguageId != language))
        //        {
        //            applicationPhrase.Translations.Add(new ApplicationTranslation()
        //            {
        //                Text = machineTranslation.Text,
        //                LanguageId = language,
        //                ObjectState = ObjectState.Added
        //            });
        //        }

        //        applicationPhrase.ObjectState = ObjectState.Modified;
        //    }

        //}

        //if (applicationPhrase.ObjectState == ObjectState.Modified)
        //{
        //    retVal = _applicationPhraseRepository.Update(applicationPhrase, true);
        //}

        //return retVal;
    }

    public async Task<int> CopyTranslationsFromLanguage(Guid applicationId, string languageId)
    {
        var retVal = 0;

        var applicationPhrases = await ApplicationPhrases.Where(x => x.ApplicationId == applicationId)
            .ToListAsync();

        foreach (var phrase in applicationPhrases)
        {
            retVal += await CopyTranslationFromPhraseList(applicationId, phrase.Id);
        }

        return retVal;
    }


    public async Task<Result> ReplaceTranslation(Guid applicationId, int phraseId, TranslationReplacementOptions input)
    {
        var phrase = await ApplicationPhrases.Where(x => x.ApplicationId == applicationId && x.Id == phraseId)
            .FirstAsync();

        var translation = phrase.Translations.First(x => x.LanguageId == input.LanguageId);

        var originalText = translation.Text;
        var newText = input.Text;

        translation.Text = input.Text;
        translation.ObjectState = ObjectState.Modified;

        var records = _applicationPhraseRepository.Update(phrase, true);
        if (records > 0)
        {


            return Result.Success(phraseId);
        }
        return Result.Failed();
    }
}