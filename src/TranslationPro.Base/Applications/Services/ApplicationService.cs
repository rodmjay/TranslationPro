#region Header Info

// Copyright 2023 Rod Johnson.  All rights reserved

#endregion

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper.QueryableExtensions;
using Microsoft.EntityFrameworkCore;
using TranslationPro.Base.ApplicationLanguages.Entities;
using TranslationPro.Base.Applications.Entities;
using TranslationPro.Base.Applications.Interfaces;
using TranslationPro.Base.Applications.Models;
using TranslationPro.Base.Common.Data.Enums;
using TranslationPro.Base.Common.Data.Interfaces;
using TranslationPro.Base.Common.Models;
using TranslationPro.Base.Common.Services.Bases;
using TranslationPro.Base.Languages.Entities;
using TranslationPro.Base.Translations.Entities;

namespace TranslationPro.Base.Applications.Services;

public class ApplicationService : BaseService<Application>, IApplicationService
{
    private readonly ApplicationErrorDescriber _errorDescriber;
    private readonly IRepositoryAsync<Language> _languageRepository;

    public ApplicationService(IServiceProvider serviceProvider, ApplicationErrorDescriber errorDescriber) : base(
        serviceProvider)
    {
        _errorDescriber = errorDescriber;
        _languageRepository = UnitOfWork.RepositoryAsync<Language>();
    }

    private IQueryable<Application> Applications => Repository.Queryable().Include(x => x.Languages)
        .Include(x => x.Phrases).Include(x => x.Translations);

    private IQueryable<Language> Languages => _languageRepository.Queryable();


    public Task<T> GetApplication<T>(Guid applicationId) where T : ApplicationDto
    {
        return Applications.Where(x => x.Id == applicationId).ProjectTo<T>(ProjectionMapping).FirstOrDefaultAsync();
    }

    public Task<List<T>> GetApplicationsAsync<T>()
    {
        return Applications.ProjectTo<T>(ProjectionMapping).ToListAsync();
    }

    public async Task<Result> CreateApplicationAsync(int userId, CreateApplicationInput input)
    {
        var application = new Application
        {
            UserId = userId,
            Name = input.Name,
            ObjectState = ObjectState.Added
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
            return Result.Success(application.Id);

        return Result.Failed();
    }

    public Task<List<T>> GetApplicationsForUserAsync<T>(int userId) where T : ApplicationDto
    {
        return Applications.Where(x => x.UserId == userId).ProjectTo<T>(ProjectionMapping).ToListAsync();
    }

    public async Task<Result> UpdateApplicationAsync(Guid applicationId, ApplicationInput input)
    {
        var existing = await Applications.Where(x => x.Id == applicationId).FirstOrDefaultAsync();

        if (existing == null)
            return Result.Failed();

        existing.Name = input.Name;
        existing.ObjectState = ObjectState.Modified;
        
        var records = Repository.InsertOrUpdateGraph(existing, true);
        if (records > 0)
            return Result.Success(existing.Id);

        return Result.Failed();
    }

    public async Task<Result> DeleteApplicationAsync(Guid applicationId)
    {
        var succeeded = await Repository.DeleteAsync(x => x.Id == applicationId);
        return succeeded ? Result.Success() : Result.Failed();
    }
}