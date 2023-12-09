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
    }

    private IQueryable<Application> Applications => _applicationRepository.Queryable()
        .Include(x=>x.Languages);

    private IQueryable<ApplicationPhrase> ApplicationPhrases => Repository.Queryable()
        .Include(x => x.Translations)
        .Include(x => x.Application);


    public async Task<string[]> GetPhrasesWithPendingTranslation(Guid applicationId)
    {
        var application = await Applications.Where(x => x.Id == applicationId).FirstAsync();

        var count = application.Languages.Count(x => !x.IsDeleted);

        var phrases = await ApplicationPhrases.Where(x => x.ApplicationId == applicationId)
            .ProjectTo<ApplicationPhraseOutput>(ProjectionMapping).ToListAsync();

        var phrasesWithEmptyTranslations = phrases.Where(x => x.PendingTranslationCount > 0).Select(x => x.Text).ToArray();

        var phrasesWithMissingTranslations = phrases.Where(x=>x.TranslationCount < count).Select(x => x.Text).ToArray();

        return phrasesWithEmptyTranslations.Union(phrasesWithMissingTranslations).ToArray();
    }

    public Task<string[]> GetPhraseTextsForApplication(Guid applicationId)
    {
        return ApplicationPhrases.Where(x => x.ApplicationId == applicationId).Select(x => x.Text).ToArrayAsync();
    }

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

    public Task<List<T>> GetPhrasesAsync<T>(Guid applicationId, string[] phrases) where T : ApplicationPhraseOutput
    {
        return ApplicationPhrases.Where(x => x.ApplicationId == applicationId && phrases.Contains(x.Text))
            .ProjectTo<T>(ProjectionMapping).ToListAsync();
    }
    

    public async Task<EnsurePhrasesResult> ScaffoldPhrases(Guid applicationId, string[] phrases)
    {
        var texts = phrases.Where(x => !string.IsNullOrWhiteSpace(x)).Select(x => x.Trim()).Distinct().ToArray();

        var retVal = new EnsurePhrasesResult()
        {
            PhrasesRequested = texts.Length
        };

        var existingPhrases = await ApplicationPhrases
            .Where(x => x.ApplicationId == applicationId && texts.Select(t=>t.ToUpper()).Contains(x.Text.ToUpper())).ToListAsync();

        retVal.ExistingPhrases = existingPhrases.Count;
        
        var phrasesAddedUpper = new List<string>();

        foreach (var text in texts)
        {
            if (existingPhrases.Any(x => x.Text.ToUpper() == text.ToUpper())) continue;

            if (phrasesAddedUpper.Contains(text.ToUpper())) continue;

            var applicationPhrase = new ApplicationPhrase()
            {
                Id = await GetCurrentPhraseIdAsync(applicationId),
                Text = text,
                ApplicationId = applicationId
            };

            await IncrementCurrentPhrase(applicationId);

            Repository.Insert(applicationPhrase);

            phrasesAddedUpper.Add(applicationPhrase.Text.ToUpper());
        }

        retVal.PhrasesAdded = Repository.Commit();

        retVal.Phrases = await ApplicationPhrases
            .Where(x => x.ApplicationId == applicationId && texts.Select(t=>t.ToUpper()).Contains(x.Text.ToUpper()))
            .Select(x => x.Id).ToArrayAsync();

        return retVal;
    }

    public Task<List<ApplicationPhrase>> GetPhrasesById(Guid applicationId, int[] phraseIds)
    {
        return ApplicationPhrases.Where(x => x.ApplicationId == applicationId && phraseIds.Contains(x.Id))
            .ToListAsync();
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


    private async Task<int> GetCurrentPhraseIdAsync(Guid applicationId)
    {
        return await Applications.Where(x => x.Id == applicationId).Select(x => x.CurrentPhraseId).FirstAsync();
    }

    private async Task IncrementCurrentPhrase(Guid applicationId)
    {
        var application = await Applications.Where(x => x.Id == applicationId).FirstAsync();
        application.CurrentPhraseId++;
        application.ObjectState = ObjectState.Modified;

        await _applicationRepository.UpdateAsync(application, true);
    }
}