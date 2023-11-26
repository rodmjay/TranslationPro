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


    public async Task AddLanguagesToApplicationPhrases(Guid applicationId, string[] languageIds)
    {
        var phrases = await _applicationPhraseService.GetPhraseTextsForApplication(applicationId);
        await CreateAndTranslatePhrases(applicationId, languageIds, phrases);
    }

    public async Task AddLanguageToApplicationPhrases(Guid applicationId, string languageId)
    {
        var phrases = await _applicationPhraseService.GetPhraseTextsForApplication(applicationId);
        await CreateAndTranslatePhrases(applicationId, new[] { languageId }, phrases);
    }

    public async Task<List<T>> CreatePhrases<T>(Guid applicationId, string[] phrases) where T : ApplicationPhraseOutput
    {
        var languages = await _applicationLanguageService.GetLanguagesForApplication(applicationId);

        await CreateAndTranslatePhrases(applicationId, languages, phrases);

        return await _applicationPhraseService.GetPhrasesAsync<T>(applicationId, phrases);
    }

    public async Task CreateAndTranslatePhrases(Guid applicationId, string[] languageIds, string[] phrases)
    {
        var texts = phrases.Where(x => !string.IsNullOrWhiteSpace(x)).Select(x => x.Trim()).Distinct().ToArray();

        await _applicationLanguageService.EnsureApplicationLanguages(applicationId, languageIds);

        var createPhrases = await _applicationPhraseService.ScaffoldPhrases(applicationId, texts);
        
        var pending = await _applicationTranslationService.GetPendingTranslations(applicationId, createPhrases.Phrases, languageIds);

        if (pending.Count > 0)
        {
            var translationResult = await _translationProxy.Translate(new PhraseBulkCreateOptions()
            {
                LanguageIds = pending.Select(x => x.LanguageId).Distinct().ToArray(),
                Texts = pending.Select(x => x.ApplicationPhrase.Text).Distinct().ToArray()
            });

            foreach (var phrase in translationResult)
            {
                var translations = phrase.MachineTranslations.GroupBy(x => x.LanguageId)
                    .ToDictionary(x => x.Key, x => x.ToList());

                foreach (var (languageId, value) in translations)
                {
                    var applicationTranslation = pending
                        .FirstOrDefault(x => x.ApplicationPhrase.Text.ToUpper() == phrase.Text.ToUpper() && x.LanguageId == languageId);

                    if (applicationTranslation != null)
                    {
                        applicationTranslation.Text = value.First().Text;
                        applicationTranslation.MachineTranslations = value.Count;
                        applicationTranslation.ObjectState = ObjectState.Modified;

                        _applicationTranslationRepository.Update(applicationTranslation);
                    }
                }
            }

            _applicationTranslationRepository.Commit();
        }
    }


    public Task<PagedList<T>> GetPhrasesForApplicationAsync<T>(Guid applicationId, PagingQuery query,
        PhraseFilters filters)
        where T : ApplicationPhraseOutput
    {
        return _applicationPhraseService.GetPhrasesForApplicationAsync<T>(applicationId, query, filters);
    }

    public Task<Dictionary<int, string>> GetApplicationPhraseList(Guid applicationId, string language)
    {
        return _applicationTranslationService.GetApplicationPhraseList(applicationId, language);
    }

    public Task<Result> DeletePhraseAsync(Guid applicationId, int phraseId)
    {
        return _applicationPhraseService.DeletePhraseAsync(applicationId, phraseId);
    }

}