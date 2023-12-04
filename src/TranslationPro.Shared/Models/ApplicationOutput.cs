#region Header Info

// Copyright 2023 Rod Johnson.  All rights reserved

#endregion

using System;
using System.Collections.Generic;
using TranslationPro.Shared.Interfaces;

namespace TranslationPro.Shared.Models;

public class ApplicationOutput : IApplication
{
    public int PhraseCount { get; set; }
    public int TranslationCount { get; set; }
    public int BlankTranslationCount { get; set; }
    public int MissingTranslations => IdealTranslationCount - TranslationCount;
    public int PendingTranslations => BlankTranslationCount + MissingTranslations; 
    public int IdealTranslationCount => LanguageCount * PhraseCount;

    public Guid Id { get; set; }
    public string Name { get; set; }
    public int LanguageCount
    {
        get => Languages.Count;
        set{}
    }

    public List<LanguageOutput> Languages { get; set; }
    public List<ApplicationUserOutput> Users { get; set; }
}