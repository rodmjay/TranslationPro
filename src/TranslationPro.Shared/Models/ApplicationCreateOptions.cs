#region Header Info

// Copyright 2023 Rod Johnson.  All rights reserved

#endregion


using System.Collections.Generic;
using TranslationPro.Shared.Enums;

namespace TranslationPro.Shared.Models;

public class ApplicationCreateOptions : ApplicationOptions
{
    public Dictionary<TranslationEngine, List<string>> EnginesWithLanguages { get; set; }
}