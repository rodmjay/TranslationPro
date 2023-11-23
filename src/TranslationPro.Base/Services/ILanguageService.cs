#region Header Info

// Copyright 2023 Rod Johnson.  All rights reserved

#endregion

using System.Collections.Generic;
using System.Threading.Tasks;
using TranslationPro.Base.Common.Services.Interfaces;
using TranslationPro.Base.Entities;
using TranslationPro.Shared.Models;

namespace TranslationPro.Base.Services;

public interface ILanguageService : IService<Language>
{
    Task<List<T>> GetLanguagesAsync<T>() where T : LanguageOutput;
    Task<T> GetLanguageAsync<T>(string languageId) where T : LanguageOutput;
}