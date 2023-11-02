#region Header Info

// Copyright 2023 Rod Johnson.  All rights reserved

#endregion

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper.QueryableExtensions;
using Microsoft.EntityFrameworkCore;
using TranslationPro.Base.Common.Services.Bases;
using TranslationPro.Base.Languages.Entities;
using TranslationPro.Base.Languages.Interfaces;
using TranslationPro.Shared.Languages;

namespace TranslationPro.Base.Languages.Services;

public class LanguageService : BaseService<Language>, ILanguageService
{
    public LanguageService(IServiceProvider serviceProvider) : base(serviceProvider)
    {
    }

    private IQueryable<Language> Languages => Repository.Queryable();

    public Task<List<T>> GetLanguagesAsync<T>() where T : LanguageDto
    {
        return Languages.ProjectTo<T>(ProjectionMapping).ToListAsync();
    }
}