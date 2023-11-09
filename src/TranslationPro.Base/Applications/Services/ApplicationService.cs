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
using TranslationPro.Base.ApplicationLanguages.Entities;
using TranslationPro.Base.Applications.Entities;
using TranslationPro.Base.Applications.Interfaces;
using TranslationPro.Base.ApplicationUsers.Entities;
using TranslationPro.Base.Common.Data.Enums;
using TranslationPro.Base.Common.Data.Interfaces;
using TranslationPro.Base.Common.Services.Bases;
using TranslationPro.Base.Engines.Entities;
using TranslationPro.Base.Languages.Entities;
using TranslationPro.Base.Phrases.Entities;
using TranslationPro.Base.Translations.Entities;
using TranslationPro.Shared.Common;
using TranslationPro.Shared.Enums;
using TranslationPro.Shared.Models;

namespace TranslationPro.Base.Applications.Services;

public class ApplicationService : BaseService<Application>, IApplicationService
{
    private static string GetLogMessage(string message, [CallerMemberName] string callerName = null)
    {
        return $"[{nameof(ApplicationService)}.{callerName}] - {message}";
    }


    private readonly ApplicationErrorDescriber _errorDescriber;
    private readonly ILogger<ApplicationService> _logger;
    private readonly IRepositoryAsync<Language> _languageRepository;
    private readonly IRepositoryAsync<ApplicationUser> _applicationUserRepository;
    private readonly IRepositoryAsync<Translation> _translationRepository;
    private readonly IRepositoryAsync<Phrase> _phraseRepository;

    public ApplicationService(IServiceProvider serviceProvider, ApplicationErrorDescriber errorDescriber, ILogger<ApplicationService> logger) : base(
        serviceProvider)
    {
        _errorDescriber = errorDescriber;
        _logger = logger;
        _languageRepository = UnitOfWork.RepositoryAsync<Language>();
        _applicationUserRepository = UnitOfWork.RepositoryAsync<ApplicationUser>();
        _phraseRepository = UnitOfWork.RepositoryAsync<Phrase>();
        _translationRepository = UnitOfWork.RepositoryAsync<Translation>();
    }

    private IQueryable<Application> Applications => Repository.Queryable().Include(x => x.Languages);

    private IQueryable<Phrase> Phrases => _phraseRepository.Queryable().Include(x => x.Translations);
    private IQueryable<ApplicationUser> ApplicationUsers => _applicationUserRepository.Queryable().Include(x => x.Application);
    private IQueryable<Language> Languages => _languageRepository.Queryable();


    public Task<T> GetApplication<T>(Guid applicationId) where T : ApplicationOutput
    {
        return Applications.Where(x => x.Id == applicationId).ProjectTo<T>(ProjectionMapping).FirstOrDefaultAsync();
    }

    public Task<List<T>> GetApplicationsAsync<T>()
    {
        return Applications.ProjectTo<T>(ProjectionMapping).ToListAsync();
    }

    public async Task<Result> CreateApplicationAsync(int userId, ApplicationCreateOptions input)
    {
        _logger.LogInformation(GetLogMessage("Creating Application: {0} For User: {1}"), input.Name, userId);

        var application = new Application
        {
            Name = input.Name,
            ObjectState = ObjectState.Added,
            Users = new List<ApplicationUser>()
            {
                new()
                {
                    UserId = userId,
                    ObjectState = ObjectState.Added,
                    Role = ApplicationRole.Owner
                }
            },
            Engines = new List<ApplicationEngine>()
            {
                new ApplicationEngine()
                {
                    EngineId = TranslationEngine.Google,
                    ObjectState = ObjectState.Added
                }
            }
        };

        var languages = await Languages.Where(x => input.Languages.Contains(x.Id)).ToListAsync();

        foreach (var lang in input.Languages)
        {
            var selectedLang = languages.FirstOrDefault(x => x.Id == lang);
            if (selectedLang != null)
                application.Languages.Add(new ApplicationLanguage
                {
                    LanguageId = selectedLang.Id,
                    ObjectState = ObjectState.Added
                });
        }

        var records = Repository.InsertOrUpdateGraph(application, true);
        if (records > 0)
        {
            _logger.LogInformation(GetLogMessage("Application Successfully Created: {0}"), input.Name);

            return Result.Success(application.Id);
        }

        return Result.Failed(_errorDescriber.UnableToCreateApplication());
    }

    public Task<List<T>> GetApplicationsForUserAsync<T>(int userId) where T : ApplicationOutput
    {
        return ApplicationUsers.Where(x => x.UserId == userId).Select(x => x.Application).ProjectTo<T>(ProjectionMapping).ToListAsync();
    }

    public async Task<Result> UpdateApplicationAsync(Guid applicationId, ApplicationOptions input)
    {
        _logger.LogInformation(GetLogMessage("Updating Application: {0}"), applicationId);

        var existing = await Applications.Where(x => x.Id == applicationId).FirstAsync();

        existing.Name = input.Name;
        existing.ObjectState = ObjectState.Modified;

        var records = Repository.InsertOrUpdateGraph(existing, true);
        if (records > 0)
        {
            _logger.LogInformation(GetLogMessage("Application Successfully Updated: {0}"), applicationId);
            return Result.Success(existing.Id);
        }

        return Result.Failed(_errorDescriber.UnableToUpdateApplication(existing.Name));
    }

    public async Task<Result> DeleteApplicationAsync(Guid applicationId)
    {
        var phrases = await Phrases.Where(x => x.ApplicationId == applicationId).ToListAsync();
        foreach (var phrase in phrases)
        {
            await _phraseRepository.DeleteAsync(phrase);
        }
        var phrasesDeleted = _phraseRepository.Commit();

        var application = await Applications.Where(x => x.Id == applicationId).FirstAsync();
        application.ObjectState = ObjectState.Deleted;

        var records = Repository.Delete(application, true);
        return records > 0 ? Result.Success() : Result.Failed(_errorDescriber.UnableToDeleteApplication(application.Name));
        
    }
}