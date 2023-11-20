using System.Threading.Tasks;
using System;
using TranslationPro.Shared.Models;
using TranslationPro.Shared.Common;
using TranslationPro.Shared.Results;
using TranslationPro.Shared.Filters;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Microsoft.Extensions.Logging;
using TranslationPro.Base.Common.Data.Interfaces;
using TranslationPro.Base.Entities;
using TranslationPro.Base.Services;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using TranslationPro.Base.Common.Data.Enums;
using TranslationPro.Shared.Proxies;
using TranslationPro.Shared.Interfaces;

namespace TranslationPro.Base.Managers;


public class ApplicationPhraseManager
{
    private static string GetLogMessage(string message, [CallerMemberName] string callerName = null)
    {
        return $"[{nameof(ApplicationPhraseManager)}.{callerName}] - {message}";
    }

    private readonly IPermissionService _permissionService;
    private readonly TranslationsProxy _translationProxy;
    private readonly IApplicationTranslationService _applicationTranslationService;
    private readonly IApplicationLanguageService _applicationLanguageService;
    private readonly IApplicationPhraseService _applicationPhraseService;
    private readonly ILogger<ApplicationPhraseManager> _logger;
    private readonly IRepositoryAsync<Application> _applicationRepository;
    private readonly IRepositoryAsync<ApplicationPhrase> _applicationPhraseRepository;
    private readonly IRepositoryAsync<ApplicationTranslation> _applicationTranslationRepository;

    public ApplicationPhraseManager(
        IUnitOfWorkAsync unitOfWork,
        IPermissionService permissionService,
        TranslationsProxy translationProxy,
        IApplicationTranslationService applicationTranslationService,
        IApplicationLanguageService applicationLanguageService,
        IApplicationPhraseService applicationPhraseService,
        ILogger<ApplicationPhraseManager> logger)
    {
        _applicationRepository = unitOfWork.RepositoryAsync<Application>();
        _applicationPhraseRepository = unitOfWork.RepositoryAsync<ApplicationPhrase>();
        _applicationTranslationRepository = unitOfWork.RepositoryAsync<ApplicationTranslation>();
        _permissionService = permissionService;
        _translationProxy = translationProxy;
        _applicationTranslationService = applicationTranslationService;
        _applicationLanguageService = applicationLanguageService;
        _applicationPhraseService = applicationPhraseService;
        _logger = logger;
    }

    private IQueryable<Application> Applications => _applicationRepository.Queryable().Include(x => x.Languages);

    public Task<T> GetPhraseAsync<T>(Guid applicationId, int phraseId) where T : ApplicationPhraseOutput
    {
        return _applicationPhraseService.GetPhraseAsync<T>(applicationId, phraseId);
    }

    public async Task<Result> CreatePhraseLanguages(Guid applicationId, string language)
    {
        var phrases = await _applicationPhraseService.GetPhraseTextsForApplication(applicationId);
        return await CreatePhrases(applicationId, new[] {language}, phrases);
    }

    public async Task<Result> CreatePhrase(Guid applicationId, string phrase)
    {
        var languages = await _applicationLanguageService.GetLanguagesForApplication(applicationId);
        return await CreatePhrases(applicationId, languages, new[] {phrase});
    }

    public async Task<Result> CreatePhrases(Guid applicationId, string[] languageIds, string[] phrases)
    {
        var createPhrases = await _applicationPhraseService.EnsureApplicationPhrases(applicationId, phrases);

        await _applicationPhraseService.EnsurePhrasesWithTranslations(applicationId, createPhrases.Phrases, languageIds);

        var pending = await _applicationTranslationService.GetPendingTranslations(applicationId, createPhrases.Phrases);

        var translateOptions = new PhraseBulkCreateOptions()
        {
            LanguageIds = pending.Select(x=>x.LanguageId).Distinct().ToArray(),
            Texts = pending.Select(x=>x.ApplicationPhrase.Text).Distinct().ToArray()
        };
        
        var translationResult = await _translationProxy.Translate(translateOptions);

        foreach (var phrase in translationResult)
        {
            var translations = phrase.MachineTranslations.GroupBy(x => x.LanguageId)
                .ToDictionary(x => x.Key, x => x.First());

            foreach (var translation in translations)
            {
                var applicationTranslation = pending
                    .FirstOrDefault(x => x.ApplicationPhrase.Text == phrase.Text && x.LanguageId == translation.Key);

                if (applicationTranslation != null)
                {
                    applicationTranslation.Text = translation.Value.Text;
                    applicationTranslation.ObjectState = ObjectState.Modified;

                    _applicationTranslationRepository.Update(applicationTranslation);
                }
            }
        }

        _applicationTranslationRepository.Commit();

        return Result.Success();
    }

    public async Task<Result> CreatePhrase(Guid applicationId, PhraseOptions input)
    {
        _logger.LogInformation(GetLogMessage("Creating Phrase: {0} for application: {1}"), input.Text, applicationId);
        
        var languages = await _applicationLanguageService.GetLanguagesForApplication(applicationId);
        
        var applicationPhrase = await _applicationPhraseService.CreateApplicationPhrase(applicationId, input);

        var result = await _translationProxy.Translate(new PhraseBulkCreateOptions()
        {
            LanguageIds = languages,
            Texts = new[] { input.Text }
        });
        
        foreach (var phrase in result)
        {
            if (phrase.Text == applicationPhrase.Text)
            {
                // todo: use weights to get the right translation
                var translations = phrase.MachineTranslations.GroupBy(x => x.LanguageId)
                    .ToDictionary(x => x.Key, x => x.Select(t=>t.Text).First());

                foreach (var (language, firstTranslation) in translations)
                {
                    applicationPhrase.Translations.Add(new ApplicationTranslation()
                    {
                        LanguageId = language,
                        Text = firstTranslation,
                        ObjectState = ObjectState.Added
                    });
                    applicationPhrase.ObjectState = ObjectState.Modified;
                }
            }
        }

        if (applicationPhrase.ObjectState == ObjectState.Modified)
        {
            await _applicationPhraseService.SaveApplicationPhrase(applicationPhrase);
        }

        return Result.Success(applicationPhrase.Id);
    }

    public Task<PagedList<T>> GetPhrasesForApplicationAsync<T>(Guid applicationId, PagingQuery query,
        PhraseFilters filters)
        where T : ApplicationPhraseOutput
    {
        return _applicationPhraseService.GetPhrasesForApplicationAsync<T>(applicationId, query, filters);
    }

    public Task<Dictionary<int, string>> GetApplicationPhraseList(Guid applicationId, string language)
    {
        return _applicationPhraseService.GetApplicationPhraseList(applicationId, language);
    }

    public Task<Result> DeletePhraseAsync(Guid applicationId, int phraseId)
    {
        return _applicationPhraseService.DeletePhraseAsync(applicationId, phraseId);
    }

}