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
    public Guid Id { get; set; }
    public string Name { get; set; }
    public int LanguageCount
    {
        get => Languages.Count;
        set{}
    }

    public ICollection<LanguageOutput> Languages { get; set; }
    public ICollection<ApplicationUserOutput> Users { get; set; }
}