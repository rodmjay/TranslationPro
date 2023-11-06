#region Header Info

// Copyright 2023 Rod Johnson.  All rights reserved

#endregion

using TranslationPro.Shared.Interfaces;

namespace TranslationPro.Shared.Models;

public class LanguageOutput : ILanguage
{
    public string Name { get; set; }
    public string Id { get; set; }
}