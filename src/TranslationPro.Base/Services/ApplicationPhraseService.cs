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
        _applicationTranslationRepository = UnitOfWork.RepositoryAsync<ApplicationTranslation>();
    }

    private IQueryable<ApplicationPhrase> ApplicationPhrases => Repository.Queryable()
        .Include(x => x.Translations)
        .Include(x => x.Application);

    private IQueryable<ApplicationTranslation> ApplicationTranslations => _applicationTranslationRepository.Queryable()
        .Include(x => x.ApplicationPhrase);

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
            .Where(x => x.ApplicationId == applicationId && texts.Contains(x.Text)).ToListAsync();

        retVal.ExistingPhrases = existingPhrases.Count;

        var nextId = await GetNextPhraseIdAsync(applicationId);

        for (var index = 0; index < texts.Length; index++)
        {
            var text = texts[index];
            if (existingPhrases.Any(x => x.Text == text)) continue;

            var applicationPhrase = new ApplicationPhrase()
            {
                Id = nextId + index,
                Text = text,
                ApplicationId = applicationId
            };

            Repository.Insert(applicationPhrase);
        }

        retVal.PhrasesAdded = Repository.Commit();

        retVal.Phrases = await ApplicationPhrases
            .Where(x => x.ApplicationId == applicationId && texts.Contains(x.Text))
            .Select(x => x.Id).ToArrayAsync();

        return retVal;
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