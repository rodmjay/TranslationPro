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

    public ApplicationTranslationService(IServiceProvider serviceProvider) : base(serviceProvider)
    {
        _applicationPhraseRepository = UnitOfWork.RepositoryAsync<ApplicationPhrase>();
    }

    private IQueryable<ApplicationTranslation> ApplicationTranslations => Repository.Queryable()
        .Include(x => x.ApplicationPhrase).Include(x => x.ApplicationLanguage);

    private IQueryable<ApplicationPhrase> ApplicationPhrases => _applicationPhraseRepository.Queryable()
        .Include(x => x.Translations);

    public async Task<List<ApplicationTranslation>> GetPendingTranslations(Guid applicationId, int[] phraseIds, string[] languageIds)
    {
        await ScaffoldTranslations(applicationId, phraseIds, languageIds);

        var translations = await ApplicationTranslations
            .Where(x => x.ApplicationId == applicationId 
                        && phraseIds.Contains(x.PhraseId) 
                        && languageIds.Contains(x.LanguageId) && x.Text == null)
            .ToListAsync();

        return translations;
    }


    public async Task ScaffoldTranslations(Guid applicationId, int[] phraseIds, string[] languageIds)
    {
        var phrases = await ApplicationPhrases.Where(x => x.ApplicationId == applicationId && phraseIds.Contains(x.Id))
            .ToListAsync();

        foreach (var phrase in phrases)
        {
            foreach (var language in languageIds)
            {
                var translation = phrase.Translations.FirstOrDefault(x => x.LanguageId == language);

                if (translation != null) continue;

                phrase.Translations.Add(new ApplicationTranslation()
                {
                    LanguageId = language,
                    ObjectState = ObjectState.Added,
                    Created = DateTimeOffset.UtcNow
                });

                phrase.ObjectState = ObjectState.Modified;
            }

            _applicationPhraseRepository.Update(phrase);
        }

        _applicationPhraseRepository.Commit();
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

    public async Task<Dictionary<int, string>> GetApplicationPhraseList(Guid applicationId, string language)
    {
        var phraseIds = await ApplicationTranslations.Where(at => at.LanguageId == language && !at.IsDeleted).GroupBy(x => x.PhraseId)
            .ToDictionaryAsync(g => g.Key, g => g.Select(x => x.Text).First());

        return phraseIds;
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