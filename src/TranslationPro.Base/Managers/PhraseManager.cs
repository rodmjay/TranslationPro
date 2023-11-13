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
    private readonly IRepositoryAsync<Application> _applicationRepository;

    public PhraseManager(
        IUnitOfWorkAsync unitOfWork,
        IPermissionService permissionService,
        IApplicationTranslationService applicationTranslationService,
        IApplicationPhraseService applicationPhraseService, 
        IPhraseService phraseService,
        IMachineTranslationService machineTranslationService,
        ILogger<PhraseManager> logger)
    {
        _applicationRepository = unitOfWork.RepositoryAsync<Application>();
        _permissionService = permissionService;
        _applicationTranslationService = applicationTranslationService;
        _applicationPhraseService = applicationPhraseService;
        _phraseService = phraseService;
        _machineTranslationService = machineTranslationService;
        _logger = logger;
    }

    private IQueryable<Application> Applications => _applicationRepository.Queryable().Include(x => x.Languages);

    public Task<T> GetPhraseAsync<T>(Guid applicationId, int phraseId) where T : ApplicationPhraseOutput
    {
        return _applicationPhraseService.GetPhraseAsync<T>(applicationId, phraseId);
    }

    public async Task<ApplicationPhraseCreateResult> CreatePhrase(Guid applicationId, PhraseOptions input)
    {
        _logger.LogInformation(GetLogMessage("Creating Phrase: {0} for application: {1}"), input.Text, applicationId);

        var retVal = new ApplicationPhraseCreateResult();

        var application = await Applications.Where(x=>x.Id == applicationId).FirstAsync();

        var phraseResult = await _phraseService.EnsurePhraseWithLanguages(new PhraseCreateOptions()
        {
            Text = input.Text,
            Languages = application.Languages.Select(x => x.LanguageId).ToList()
        });

        if (phraseResult.Succeeded)
        {
            var phraseId = int.Parse(phraseResult.Id.ToString());

            var result = await _applicationPhraseService.CreateApplicationPhrase(applicationId, phraseId, input).ConfigureAwait(false);
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
        }
        else
        {
            retVal.Errors = phraseResult.Errors;
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