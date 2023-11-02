#region Header Info

// Copyright 2023 Rod Johnson.  All rights reserved

#endregion

using TranslationPro.Shared.Languages;

namespace TranslationPro.Shared.Controllers;

public interface ILanguagesController
{
    Task<List<LanguageDto>> GetLanguagesAsync();
}