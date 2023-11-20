#region Header Info

// Copyright 2023 Rod Johnson.  All rights reserved

#endregion

namespace TranslationPro.Shared.Models;

public class PhraseBulkCreateOptions
{
    public string[] Texts { get; set; }
    public string[] LanguageIds { get; set; }
}