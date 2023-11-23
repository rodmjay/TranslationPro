#region Header Info

// Copyright 2023 Rod Johnson.  All rights reserved

#endregion


using System.Collections.Generic;

namespace TranslationPro.Shared.Models;

public class ApplicationPhrasesCreateOptions
{
    public ApplicationPhrasesCreateOptions()
    {
        Texts = new List<string>();
    }
    public List<string> Texts { get; set; }
}