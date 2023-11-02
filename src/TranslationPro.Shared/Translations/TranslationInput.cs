#region Header Info

// Copyright 2023 Rod Johnson.  All rights reserved

#endregion

using System.ComponentModel.DataAnnotations;

namespace TranslationPro.Shared.Translations;

public class TranslationInput
{
    [Required] [MinLength(2)] public string Text { get; set; }

    [MinLength(2)] [Required] public string LanguageId { get; set; }
}