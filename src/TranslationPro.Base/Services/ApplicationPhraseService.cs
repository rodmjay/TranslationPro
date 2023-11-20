#region Header Info

// Copyright 2023 Rod Johnson.  All rights reserved

#endregion

using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;
using AutoMapper.QueryableExtensions;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using TranslationPro.Base.Common.Data.Enums;
using TranslationPro.Base.Common.Data.Interfaces;
using TranslationPro.Base.Common.Extensions;
using TranslationPro.Base.Common.Services.Bases;
using TranslationPro.Base.Entities;
using TranslationPro.Base.Errors;
using TranslationPro.Base.Extensions;
using TranslationPro.Shared.Common;
using TranslationPro.Shared.Filters;
using TranslationPro.Shared.Models;

namespace TranslationPro.Base.Services;

public class ApplicationPhraseService : BaseService<ApplicationPhrase>, IApplicationPhraseService
{
    private static string GetLogMessage(string message, [CallerMemberName] string callerName = null)
    {
        return $"[{nameof(ApplicationPhraseService)}.{callerName}] - {message}";
    }

    private readonly IRepositoryAsync<Application> _applicationRepository;
    private readonly IRepositoryAsync<ApplicationTranslation> _applicationTranslationRepository;
    private readonly PhraseErrorDescriber _errorDescriber;
    private readonly ILogger<ApplicationPhraseService> _logger;

    public ApplicationPhraseService(
        IServiceProvider serviceProvider,
        PhraseErrorDescriber errorDescriber,
        ILogger<ApplicationPhraseService> logger) : base(serviceProvider)
    {
        _errorDescriber = errorDescriber;
        _logger = logger;
        _applicationRepository = UnitOfWork.RepositoryAsync<Application>();
        _applicationTranslationRepository = UnitOfWork.RepositoryAsync<ApplicationTranslation>();
    }

    private IQueryable<ApplicationPhrase> ApplicationPhrases => Repository.Queryable()
        .Include(x => x.Translations)
        .Include(x => x.Application);

    private IQueryable<ApplicationTranslation> ApplicationTranslations => _applicationTranslationRepository.Queryable()
        .Include(x => x.ApplicationPhrase);
    
    public Task<PagedList<T>> GetPhrasesForApplicationAsync<T>(Guid applicationId, PagingQuery paging,
        PhraseFilters filters) where T : ApplicationPhraseOutput
    {
        return this.PaginateAsync<ApplicationPhrase, T>(x => x.ApplicationId == applicationId, filters.GetExpression(), paging);
    }

    public Task<T> GetPhraseAsync<T>(Guid applicationId, int phraseId) where T : ApplicationPhraseOutput
    {
        return ApplicationPhrases.Where(x => x.ApplicationId == applicationId && x.Id == phraseId)
            .ProjectTo<T>(ProjectionMapping).FirstAsync();
    }

    public async Task<Dictionary<int, string>> GetApplicationPhraseList(Guid applicationId, string language)
    {
        var phraseIds = await ApplicationTranslations.Where(at => at.LanguageId == language && !at.IsDeleted).GroupBy(x => x.PhraseId)
            .ToDictionaryAsync(g => g.Key, g => g.Select(x => x.Text).First());

        return phraseIds;
    }
    

    public async Task<ApplicationPhrase> CreateApplicationPhrase(Guid applicationId, PhraseOptions input)
    {
        _logger.LogInformation(GetLogMessage("Creating Phrase: {0}"), input.Text);

        var applicationPhrase = await ApplicationPhrases
            .Where(x => x.ApplicationId == applicationId && x.Text == input.Text).FirstOrDefaultAsync();

        if (applicationPhrase == null)
        {
            var applicationPhraseId = await GetNextPhraseIdAsync(applicationId);

            applicationPhrase = new ApplicationPhrase
            {
                Id = applicationPhraseId,
                Text = input.Text,
                ApplicationId = applicationId,
                ObjectState = ObjectState.Added
            };

            var records = Repository.InsertOrUpdateGraph(applicationPhrase, true);
        }

        return applicationPhrase;

    }

    public Task<Result> SaveApplicationPhrase(ApplicationPhrase phrase)
    {
        var records = Repository.InsertOrUpdateGraph(phrase, true);
        if (records > 0)
            return Task.FromResult(Result.Success(phrase.Id));
        return Task.FromResult(Result.Failed());
    }


    public async Task<Result> DeletePhraseAsync(Guid applicationId, int phraseId)
    {
        _logger.LogInformation(GetLogMessage("Deleting phrase: {0} in application: {1}"), phraseId, applicationId);

        var phrase = await ApplicationPhrases.Where(x => x.Id == phraseId).FirstOrDefaultAsync().ConfigureAwait(false);

        if (phrase == null)
            return Result.Failed(_errorDescriber.PhraseDoesntExist(phraseId));

        phrase.IsDeleted = true;
        phrase.ObjectState = ObjectState.Modified;

        var records = Repository.InsertOrUpdateGraph(phrase, true);

        if (records > 0)
            return Result.Success();

        return Result.Failed(_errorDescriber.UnableToDeletePhrase(phraseId));
    }


    private async Task<int> GetNextPhraseIdAsync(Guid applicationId)
    {
        var lastPhrase = await ApplicationPhrases.Where(x => x.ApplicationId == applicationId).OrderByDescending(x => x.Id)
            .FirstOrDefaultAsync().ConfigureAwait(false);

        if (lastPhrase == null)
            return 10000;

        return lastPhrase.Id + 1;
    }
}