using System.Threading.Tasks;
using System;
using TranslationPro.Shared.Models;
using TranslationPro.Shared.Common;
using TranslationPro.Shared.Results;
using TranslationPro.Shared.Filters;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Microsoft.Extensions.Logging;
using TranslationPro.Base.Services;

namespace TranslationPro.Base.Managers;

public class PhraseManager
{
    private static string GetLogMessage(string message, [CallerMemberName] string callerName = null)
    {
        return $"[{nameof(PhraseManager)}.{callerName}] - {message}";
    }

    private readonly IPermissionService _permissionService;
    private readonly IApplicationTranslationService _applicationTranslationService;
    private readonly IApplicationPhraseService _applicationPhraseService;
    private readonly IPhraseService _phraseService;
    private readonly IMachineTranslationService _machineTranslationService;
    private readonly ILogger<PhraseManager> _logger;

    public PhraseManager(
        IPermissionService permissionService,
        IApplicationTranslationService applicationTranslationService,
        IApplicationPhraseService applicationPhraseService, 
        IPhraseService phraseService,
        IMachineTranslationService machineTranslationService,
        ILogger<PhraseManager> logger)
    {
        _permissionService = permissionService;
        _applicationTranslationService = applicationTranslationService;
        _applicationPhraseService = applicationPhraseService;
        _phraseService = phraseService;
        _machineTranslationService = machineTranslationService;
        _logger = logger;
    }

    public Task<T> GetPhraseAsync<T>(Guid applicationId, int phraseId) where T : ApplicationPhraseOutput
    {
        return _applicationPhraseService.GetPhraseAsync<T>(applicationId, phraseId);
    }

    public async Task<CreatePhraseResult> CreatePhrase(Guid applicationId, PhraseOptions input)
    {
        _logger.LogInformation(GetLogMessage("Creating Phrase: {0} for application: {1}"), input.Text, applicationId);

        var retVal = new CreatePhraseResult();

        var result = await _applicationPhraseService.CreateApplicationPhrase(applicationId, input).ConfigureAwait(false);
        if (result.Succeeded)
        {
            retVal.Succeeded = true;
            retVal.PhraseId = int.Parse(result.Id.ToString());
            retVal.TranslationsCreated = await _machineTranslationService.ProcessTranslationsAsync(applicationId);
            retVal.TranslationsCopied = await _applicationTranslationService
                .CopyTranslationFromPhraseList(applicationId, retVal.PhraseId.Value);
        }
        else
        {
            retVal.Errors = result.Errors;
        }

        return retVal;
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