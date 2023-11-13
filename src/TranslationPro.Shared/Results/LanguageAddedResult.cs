#region Header Info

// Copyright 2023 Rod Johnson.  All rights reserved

#endregion

using System.Collections.Generic;
using TranslationPro.Shared.Common;

namespace TranslationPro.Shared.Results;

public class LanguageAddedResult
{
    public bool Succeeded { get; set; }
    public IEnumerable<Error> Errors { get; set; }
    public int TranslationsCreated { get; set; }
    public int TranslationsCopied { get; set; }
}