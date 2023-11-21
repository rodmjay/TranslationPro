using System.Threading.Tasks;
using System;
using TranslationPro.Shared.Models;
using TranslationPro.Shared.Common;
using TranslationPro.Shared.Filters;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Microsoft.Extensions.Logging;
using TranslationPro.Base.Common.Data.Interfaces;
using TranslationPro.Base.Entities;
using TranslationPro.Base.Services;
using System.Linq;
using TranslationPro.Base.Common.Data.Enums;
using TranslationPro.Shared.Proxies;

namespace TranslationPro.Base.Managers;


public class ApplicationPhraseManager
{
    private static string GetLogMessage(string message, [CallerMemberName] string callerName = null)
    {
        return $"[{nameof(ApplicationPhraseManager)}.{callerName}] - {message}";
    }

    private readonly TranslationsProxy _translationProxy;
    private readonly IApplicationTranslationService _applicationTranslationService;
    private readonly IApplicationLanguageService _applicationLanguageService;
    private readonly IApplicationPhraseService _applicationPhraseService;
    private readonly ILogger<ApplicationPhraseManager> _logger;
    private readonly IRepositoryAsync<ApplicationTranslation> _applicationTranslationRepository;

    public ApplicationPhraseManager(
        IUnitOfWorkAsync unitOfWork,
        TranslationsProxy translationProxy,
        IApplicationTranslationService applicationTranslationService,
        IApplicationLanguageService applicationLanguageService,
        IApplicationPhraseService applicationPhraseService,
        ILogger<ApplicationPhraseManager> logger)
    {
        _applicationTranslationRepository = unitOfWork.RepositoryAsync<ApplicationTranslation>();
        _translationProxy = translationProxy;
        _applicationTranslationService = applicationTranslationService;
        _applicationLanguageService = applicationLanguageService;
        _applicationPhraseService = applicationPhraseService;
        _logger = logger;
    }

    public Task<T> GetPhraseAsync<T>(Guid applicationId, int phraseId) where T : ApplicationPhraseOutput
    {
        return _applicationPhraseService.GetPhraseAsync<T>(applicationId, phraseId);
    }

    public async Task<Result> AddLanguageToApplicationPhrases(Guid applicationId, string language)
    {
        var phrases = await _applicationPhraseService.GetPhraseTextsForApplication(applicationId);
        return await CreateAndTranslatePhrases(applicationId, new[] {language}, phrases);
    }

    public async Task<T> CreatePhrase<T>(Guid applicationId, string phrase) where T : ApplicationPhraseOutput
    {
        var languages = await _applicationLanguageService.GetLanguagesForApplication(applicationId);
        var translationResult = await CreateAndTranslatePhrases(applicationId, languages, new[] {phrase});

        return await _applicationPhraseService.GetPhraseAsync<T>(applicationId, phrase);
    }

    public async Task<Result> CreateAndTranslatePhrases(Guid applicationId, string[] languageIds, string[] phrases)
    {
        await _applicationLanguageService.EnsureApplicationLanguages(applicationId, languageIds);
        
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