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
using TranslationPro.Base.Common.Services.Bases;
using TranslationPro.Base.Entities;
using TranslationPro.Base.Errors;
using TranslationPro.Base.Users.Entities;
using TranslationPro.Shared.Common;
using TranslationPro.Shared.Enums;
using TranslationPro.Shared.Models;

namespace TranslationPro.Base.Services;

public class ApplicationService : BaseService<Application>, IApplicationService
{
    private static string GetLogMessage(string message, [CallerMemberName] string callerName = null)
    {
        return $"[{nameof(ApplicationService)}.{callerName}] - {message}";
    }

    private readonly ApplicationErrorDescriber _errorDescriber;
    private readonly ILogger<ApplicationService> _logger;

    public ApplicationService(IServiceProvider serviceProvider, ApplicationErrorDescriber errorDescriber, ILogger<ApplicationService> logger) : base(
        serviceProvider)
    {
        _errorDescriber = errorDescriber;
        _logger = logger;
    }

    private IQueryable<Application> Applications => Repository.Queryable()
        .Include(x => x.Languages)
        .ThenInclude(x => x.Translations)
        .Include(x => x.Phrases);

    private IQueryable<User> Users => Repository.GetRepository<User>().Queryable().Include(x=>x.Subscription);
    private IQueryable<Subscription> Subscriptions => Repository.GetRepository<Subscription>().Queryable();

    public Task<T> GetApplication<T>(Guid applicationId) where T : ApplicationOutput
    {
        return Applications.Where(x => x.Id == applicationId).ProjectTo<T>(ProjectionMapping).FirstOrDefaultAsync();
    }

    public async Task<Result> CreateApplicationAsync(int userId, ApplicationCreateOptions input)
    {
        _logger.LogInformation(GetLogMessage("Creating Application: {0} For User: {1}"), input.Name, userId);

        var subscription = await Subscriptions.Where(x => x.UserId == userId).FirstOrDefaultAsync();
        if (subscription == null)
        {
            return Result.Failed(_errorDescriber.NoSubscription());
        }

        var application = new Application
        {
            SubscriptionId = subscription.UserId,
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
            Languages = input.Languages.Select(language => new ApplicationLanguage()
            {
                LanguageId = language,
                ObjectState = ObjectState.Added,
            }).ToList()
        };

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
        return Applications
            .SelectMany(x => x.Users)
            .Where(x => x.UserId == userId)
            .Select(x => x.Application)
            .ProjectTo<T>(ProjectionMapping)
            .ToListAsync();
    }

    public async Task<Result> UpdateApplicationAsync(Guid applicationId, ApplicationOptions input)
    {
        _logger.LogInformation(GetLogMessage("Updating Application: {0}"), applicationId);

        var application = await Applications.Where(x => x.Id == applicationId).FirstAsync();

        application.Name = input.Name;
        application.ObjectState = ObjectState.Modified;

        var records = Repository.InsertOrUpdateGraph(application, true);
        if (records > 0)
        {
            _logger.LogInformation(GetLogMessage("Application Successfully Updated: {0}"), applicationId);
            return Result.Success(application.Id);
        }

        return Result.Failed(_errorDescriber.UnableToUpdateApplication(application.Name));
    }

    public async Task<Result> DeleteApplicationAsync(Guid applicationId)
    {
        _logger.LogInformation(GetLogMessage("Deleting Application: {0}"), applicationId);

        var application = await Applications.Where(x => x.Id == applicationId).FirstAsync();
        application.IsDeleted = true;
        foreach (var phrase in application.Phrases)
        {
            phrase.IsDeleted = true;
            phrase.ObjectState = ObjectState.Modified;

            foreach (var translation in phrase.Translations)
            {
                translation.IsDeleted = true;
                translation.ObjectState = ObjectState.Modified;
            }
        }

        application.ObjectState = ObjectState.Modified;

        var records = Repository.InsertOrUpdateGraph(application, true);
        if (records > 0)
        {
            _logger.LogInformation(GetLogMessage("Application Deleted: {0}"), applicationId);

            return Result.Success(applicationId);
        }

        return Result.Failed(_errorDescriber.UnableToDeleteApplication(application.Name));
    }
}