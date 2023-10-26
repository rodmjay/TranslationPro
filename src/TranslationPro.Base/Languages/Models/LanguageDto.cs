#region Header Info

// Copyright 2023 Rod Johnson.  All rights reserved

#endregion

using TranslationPro.Base.Languages.Interfaces;

namespace TranslationPro.Base.Languages.Models;

public class LanguageDto : ILanguage
{
    public string Name { get; set; }
    public string Id { get; set; }
}