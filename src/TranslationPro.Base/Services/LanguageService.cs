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
using TranslationPro.Base.Common.Services.Bases;
using TranslationPro.Base.Entities;
using TranslationPro.Shared.Models;

namespace TranslationPro.Base.Services;

public class LanguageService : BaseService<Language>, ILanguageService
{
    private static string GetLogMessage(string message, [CallerMemberName] string callerName = null)
    {
        return $"[{nameof(LanguageService)}.{callerName}] - {message}";
    }


    public LanguageService(IServiceProvider serviceProvider) : base(serviceProvider)
    {
    }

    private IQueryable<Language> Languages => Repository.Queryable().Include(x => x.Applications);

    public async Task<List<T>> GetLanguagesAsync<T>() where T : LanguageOutput
    {
        var languages = await Languages.OrderByDescending(x => x.Applications.Count).ProjectTo<T>(ProjectionMapping).ToListAsync();

        return languages;
    }


    public Task<T> GetLanguageAsync<T>(string languageId) where T : LanguageOutput
    {
        return Languages.Where(x => x.Id == languageId).ProjectTo<T>(ProjectionMapping).FirstOrDefaultAsync();
    }
}