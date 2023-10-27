#region Header Info

// Copyright 2023 Rod Johnson.  All rights reserved

#endregion

using System.Collections.Generic;
using System.Threading.Tasks;
using TranslationPro.Base.Languages.Models;

namespace TranslationPro.Api.Interfaces;

public interface ILanguagesController
{
    Task<List<LanguageDto>> GetLanguages();
}