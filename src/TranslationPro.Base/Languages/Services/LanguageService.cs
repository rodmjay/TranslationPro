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
using TranslationPro.Base.Common.Data.Interfaces;
using TranslationPro.Base.Common.Services.Bases;
using TranslationPro.Base.Engines.Entities;
using TranslationPro.Base.Languages.Entities;
using TranslationPro.Base.Languages.Interfaces;
using TranslationPro.Shared.Models;

namespace TranslationPro.Base.Languages.Services;

public class LanguageService : BaseService<Language>, ILanguageService
{
    private static string GetLogMessage(string message, [CallerMemberName] string callerName = null)
    {
        return $"[{nameof(LanguageService)}.{callerName}] - {message}";
    }
    private readonly IRepositoryAsync<Engine> _engineRepository;
    

    public LanguageService(IServiceProvider serviceProvider) : base(serviceProvider)
    {
        _engineRepository = UnitOfWork.RepositoryAsync<Engine>();
    }
    
    private IQueryable<Engine> Engines =>
        _engineRepository.Queryable().Include(x => x.Languages).ThenInclude(x => x.Language);

    public async Task<List<T>> GetLanguagesAsync<T>() where T : LanguageOutput
    {
        var langs = await Engines.Where(x=>x.Enabled).SelectMany(x=>x.Languages).Select(x=>x.Language).Distinct()
            .ProjectTo<T>(ProjectionMapping)
            .ToListAsync();

        return langs;
    }
}