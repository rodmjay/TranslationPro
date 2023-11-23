#region Header Info

// Copyright 2023 Rod Johnson.  All rights reserved

#endregion

using System.Collections.Generic;

namespace TranslationPro.Shared.Models;

public class PhraseCreateOptions : ApplicationPhrasesCreateOptions
{
    public List<string> Languages { get; set; }
}