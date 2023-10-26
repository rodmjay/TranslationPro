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

    public async Task<Result> CreateApplicationAsync(int userId, ApplicationInput input)
    {
        var application = new Application
        {
            UserId = userId,
            Name = input.Name,
            ObjectState = ObjectState.Added
        };

        // make sure the languages exist in database and remove any junk data
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

        foreach (var lang in existing.Languages)
        {
            lang.ObjectState = ObjectState.Deleted;

            if (input.Languages.Contains(lang.LanguageId))
                lang.ObjectState = ObjectState.Unchanged;
            else
                foreach (var translation in existing.Translations.Where(x => x.LanguageId == lang.LanguageId))
                    translation.ObjectState = ObjectState.Deleted;
        }


        foreach (var lang in input.Languages)
            if (!existing.Languages.Select(x => x.LanguageId).Contains(lang))
            {
                existing.Languages.Add(new ApplicationLanguage
                {
                    LanguageId = lang,
                    ApplicationId = applicationId,
                    ObjectState = ObjectState.Added
                });

                foreach (var phrase in existing.Phrases)
                    phrase.Translations.Add(new Translation
                    {
                        LanguageId = lang,
                        ObjectState = ObjectState.Added,
                        Text = null,
                        TranslationDate = null
                    });
            }

        var records = Repository.InsertOrUpdateGraph(existing, true);
        if (records > 0)
            return Result.Success(existing.Id);

        return Result.Failed();
    }

    public Task<Result> DeleteApplicationAsync(Guid applicationId)
    {
        throw new NotImplementedException();
    }
}