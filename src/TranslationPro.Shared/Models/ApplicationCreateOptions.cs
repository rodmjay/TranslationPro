#region Header Info

// Copyright 2023 Rod Johnson.  All rights reserved

#endregion


using System.Collections.Generic;
using TranslationPro.Shared.Enums;

namespace TranslationPro.Shared.Models;

public class ApplicationCreateOptions : ApplicationOptions
{
    private Dictionary<TranslationEngine, List<string>> _enginesWithLanguages;

    public ApplicationCreateOptions()
    {
        _enginesWithLanguages = new Dictionary<TranslationEngine, List<string>>();
    }

    public Dictionary<TranslationEngine, List<string>> EnginesWithLanguages
    {
        get => _enginesWithLanguages;
        set => _enginesWithLanguages = value;
    }
}