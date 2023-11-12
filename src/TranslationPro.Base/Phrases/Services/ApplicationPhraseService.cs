﻿#region Header Info

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
using TranslationPro.Base.Applications.Entities;
using TranslationPro.Base.Common.Data.Enums;
using TranslationPro.Base.Common.Data.Interfaces;
using TranslationPro.Base.Common.Extensions;
using TranslationPro.Base.Common.Services.Bases;
using TranslationPro.Base.Phrases.Entities;
using TranslationPro.Base.Phrases.Extensions;
using TranslationPro.Base.Phrases.Interfaces;
using TranslationPro.Shared.Common;
using TranslationPro.Shared.Filters;
using TranslationPro.Shared.Models;

namespace TranslationPro.Base.Phrases.Services;

public class ApplicationPhraseService : BaseService<ApplicationPhrase>, IApplicationPhraseService
{
    private static string GetLogMessage(string message, [CallerMemberName] string callerName = null)
    {
        return $"[{nameof(ApplicationPhraseService)}.{callerName}] - {message}";
    }

    private readonly IRepositoryAsync<Application> _applicationRepository;
    private readonly IRepositoryAsync<ApplicationTranslation> _applicationTranslationRepository;
    private readonly IPhraseService _phraseService;
    private readonly PhraseErrorDescriber _errorDescriber;
    private readonly ILogger<ApplicationPhraseService> _logger;

    public ApplicationPhraseService(
        IPhraseService phraseService,
        IServiceProvider serviceProvider,
        PhraseErrorDescriber errorDescriber,
        ILogger<ApplicationPhraseService> logger) : base(serviceProvider)
    {
        _phraseService = phraseService;
        _errorDescriber = errorDescriber;
        _logger = logger;
        _applicationRepository = UnitOfWork.RepositoryAsync<Application>();
        _applicationTranslationRepository = UnitOfWork.RepositoryAsync<ApplicationTranslation>();
    }

    private IQueryable<ApplicationPhrase> ApplicationPhrases => Repository.Queryable()
        .Include(x=>x.Translations)
        .Include(x => x.Application)
        .Include(x => x.Phrase)
        .ThenInclude(x => x.MachineTranslations);

    private IQueryable<ApplicationTranslation> ApplicationTranslations => _applicationTranslationRepository.Queryable()
        .Include(x=>x.ApplicationPhrase);

    private IQueryable<Application> Applications => _applicationRepository.Queryable().Include(x => x.Languages)
        .ThenInclude(x => x.Language).ThenInclude(x => x.Engines).ThenInclude(x => x.Engine);

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
        var phraseIds = await ApplicationTranslations.Where(at=>at.LanguageId == language).GroupBy(x => x.PhraseId)
            .ToDictionaryAsync(g => g.Key, g => g.Select(x => x.Text).First());

        return phraseIds;
    }

    public async Task<Result> ReplaceTranslation(Guid applicationId, int phraseId, TranslationReplacementOptions input)
    {
        var phrase = await ApplicationPhrases.Where(x => x.ApplicationId == applicationId && x.Id == phraseId)
            .FirstAsync();

        var translation = phrase.Translations.First(x => x.LanguageId == input.LanguageId);

        translation.Text = input.Text;
        translation.ObjectState = ObjectState.Modified;

        var records = Repository.Update(phrase, true);
        if (records > 0)
        {
            return Result.Success(phraseId);
        }
        return Result.Failed();
    }

    //public async Task<Result> BulkUploadPhrases(Guid applicationId, List<string> inputs)
    //{
    //    var phrases = Phrases.Where(x => x.ApplicationId == applicationId).ToList();

    //    foreach (var input in inputs)
    //    {
    //        var existing = phrases
    //            .FirstOrDefault(x => x.ApplicationId == applicationId && x.Text == input);

    //        if (existing != null) continue;

    //        var phraseId = await GetNextPhraseIdAsync(applicationId);

    //        var phrase = new ApplicationPhrase
    //        {
    //            Id = phraseId,
    //            Text = input,
    //            ApplicationId = applicationId,
    //            ObjectState = ObjectState.Added
    //        };

    //        var application = await Applications.Where(x => x.Id == applicationId).FirstOrDefaultAsync();

    //        foreach (var lang in application.Languages)
    //            phrase.Translations.Add(new ApplicationTranslation
    //            {
    //                LanguageId = lang.LanguageId,
    //                ApplicationId = applicationId,
    //                PhraseId = phraseId,
    //                ObjectState = ObjectState.Added
    //            });
    //    }

    //    var records = Repository.Commit();

    //    return Result.Success(records);
    //}


    public async Task<Result> CreateApplicationPhrase(Guid applicationId, PhraseOptions input)
    {
        _logger.LogInformation(GetLogMessage("Creating Phrase: {0}"), input.Text);

        var application = await Applications.Where(x => x.Id == applicationId).FirstAsync(); ;

        var applicationPhrase = await ApplicationPhrases
            .Where(x => x.ApplicationId == applicationId && x.Phrase.Text == input.Text).FirstOrDefaultAsync();

        if (applicationPhrase == null)
        {
            var phraseResult = await _phraseService.EnsurePhraseWithLanguages(new CreatePhraseOptions()
            {
                Text = input.Text,
                Languages = application.Languages.Select(x => x.LanguageId).ToList()
            });

            var applicationPhraseId = await GetNextPhraseIdAsync(applicationId);

            applicationPhrase = new ApplicationPhrase
            {
                Id = applicationPhraseId,
                PhraseId = int.Parse(phraseResult.Id.ToString()),
                ApplicationId = applicationId,
                ObjectState = ObjectState.Added
            };

            var records = Repository.InsertOrUpdateGraph(applicationPhrase, true);
            if (records > 0)
                return Result.Success(applicationPhrase.Id);
        }
        else
        {
            return Result.Success(applicationPhrase.Id);
        }

        return Result.Failed(_errorDescriber.UnableToCreatePhrase());
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