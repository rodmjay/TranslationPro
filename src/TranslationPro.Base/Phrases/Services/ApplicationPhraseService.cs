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
using TranslationPro.Base.Applications.Entities;
using TranslationPro.Base.Common.Data.Enums;
using TranslationPro.Base.Common.Data.Interfaces;
using TranslationPro.Base.Common.Extensions;
using TranslationPro.Base.Common.Services.Bases;
using TranslationPro.Base.Engines.Entities;
using TranslationPro.Base.Phrases.Entities;
using TranslationPro.Base.Phrases.Extensions;
using TranslationPro.Base.Phrases.Interfaces;
using TranslationPro.Base.Translations.Entities;
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
    private readonly IRepositoryAsync<ApplicationEngine> _applicationEngineRepository;
    private readonly IRepositoryAsync<Phrase> _phraseRepository;
    private readonly PhraseErrorDescriber _errorDescriber;
    private readonly ILogger<ApplicationPhraseService> _logger;

    public ApplicationPhraseService(IServiceProvider serviceProvider, PhraseErrorDescriber errorDescriber, ILogger<ApplicationPhraseService> logger) : base(serviceProvider)
    {
        _errorDescriber = errorDescriber;
        _logger = logger;
        _applicationRepository = UnitOfWork.RepositoryAsync<Application>();
        _phraseRepository = UnitOfWork.RepositoryAsync<Phrase>();
        _applicationEngineRepository = UnitOfWork.RepositoryAsync<ApplicationEngine>();
    }

    private IQueryable<Application> Applications => _applicationRepository.Queryable()
        .Include(x => x.EngineLanguages);

    private IQueryable<ApplicationPhrase> ApplicationPhrases => Repository.Queryable()
        .Include(x => x.Phrase)
        .Include(x => x.MachineTranslations);

    private IQueryable<Phrase> Phrases => _phraseRepository.Queryable()
        .Include(x => x.Translations);

    private IQueryable<ApplicationEngine> Engines => _applicationEngineRepository.Queryable()
        .Include(x=>x.Engine).ThenInclude(x=>x.Languages);

    public Task<PagedList<T>> GetPhrasesForApplicationAsync<T>(Guid applicationId, PagingQuery paging,
        PhraseFilters filters) where T : PhraseOutput
    {
        return this.PaginateAsync<ApplicationPhrase, T>(x => x.ApplicationId == applicationId, filters.GetExpression(), paging);
    }

    public Task<T> GetPhraseAsync<T>(Guid applicationId, int phraseId) where T : PhraseOutput
    {
        return ApplicationPhrases.Where(x => x.ApplicationId == applicationId && x.Id == phraseId).ProjectTo<T>(ProjectionMapping).FirstAsync();
    }

    public async Task<Dictionary<int, string>> GetApplicationPhraseList(Guid applicationId, string language)
    {
        var phrases = await ApplicationPhrases.Include(x => x.MachineTranslations.Where(t => t.LanguageId == language))
            .Where(x => x.ApplicationId == applicationId).ToListAsync();

        return phrases.SelectMany(x => x.MachineTranslations).ToDictionary(x => x.PhraseId, x => x.Text);
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


    public async Task<Result> CreatePhraseAsync(Guid applicationId, PhraseOptions input)
    {
        _logger.LogInformation(GetLogMessage("Creating Phrase: {0}"), input.Text);

        var applicationPhrase = await ApplicationPhrases
            .Where(x => x.ApplicationId == applicationId && x.Phrase.Text == input.Text).FirstOrDefaultAsync();

        if (applicationPhrase == null)
        {
            var application = await Applications.Where(x => x.Id == applicationId).FirstAsync();

            // does phrase exist in system?
            var phrase = await Phrases.Where(x => x.Text == input.Text).FirstOrDefaultAsync();
            if (phrase == null)
            {
                phrase = new Phrase()
                {
                    Text = input.Text,
                    ObjectState = ObjectState.Added
                };

                var phraseRecords = _phraseRepository.InsertOrUpdateGraph(phrase, true);
                if (phraseRecords > 0)
                {
                    _logger.LogInformation(GetLogMessage("New phrase created: {0}"), input.Text);
                }
            }

            // create application phrase
            var applicationPhraseId = await GetNextPhraseIdAsync(applicationId);

            applicationPhrase = new ApplicationPhrase
            {
                Id = applicationPhraseId,
                PhraseId = phrase.Id,
                ApplicationId = applicationId,
                ObjectState = ObjectState.Added
            };

            // add empty translation for each language and engine
            foreach (var lang in application.EngineLanguages)
            {
                applicationPhrase.MachineTranslations.Add(new ApplicationTranslation()
                {
                    ApplicationId = applicationId,
                    EngineId = lang.EngineId,
                    ObjectState = ObjectState.Added,
                    LanguageId = lang.LanguageId
                });
            }

            var records = Repository.InsertOrUpdateGraph(applicationPhrase, true);
            if (records > 0)
                return Result.Success(phrase.Id);
        }
        else
        {
            return Result.Success(applicationPhrase.Id);
        }
        
        return Result.Failed(_errorDescriber.UnableToCreatePhrase());
    }

    public async Task<Result> UpdatePhraseAsync(Guid applicationId, int phraseId, PhraseOptions input)
    {
        throw new NotImplementedException();
        //_logger.LogInformation(GetLogMessage("Updating phrase: {0} in application: {1}"), phraseId, applicationId);

        //var existing = await ApplicationPhrases.Where(x => x.ApplicationId == applicationId && x.Id == phraseId)
        //    .FirstOrDefaultAsync();

        //// error if phrase doesn't exist
        //if (existing == null)
        //    return Result.Failed(_errorDescriber.PhraseDoesntExist(phraseId));

        //// skip if the text is the same
        //if (existing.Text == input.Text)
        //    return Result.Success(phraseId);

        //existing.Text = input.Text;
        //existing.ObjectState = ObjectState.Modified;

        //// re-translate if the text is different
        //foreach (var translation in existing.Translations)
        //{
        //    translation.Text = null;
        //    translation.TranslationDate = null;
        //    translation.ObjectState = ObjectState.Modified;
        //}

        //var records = Repository.InsertOrUpdateGraph(existing, true);
        //if (records > 0)
        //    return Result.Success(phraseId);

        //return Result.Failed(_errorDescriber.UnableToUpdatePhrase(phraseId));
    }

    public async Task<Result> DeletePhraseAsync(Guid applicationId, int phraseId)
    {
        _logger.LogInformation(GetLogMessage("Deleting phrase: {0} in application: {1}"), phraseId, applicationId);

        var phrase = await ApplicationPhrases.Where(x => x.Id == phraseId).FirstOrDefaultAsync().ConfigureAwait(false);

        if (phrase == null)
            return Result.Failed(_errorDescriber.PhraseDoesntExist(phraseId));

        phrase.IsDeleted = true;
        phrase.ObjectState= ObjectState.Modified;

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