#region Header Info

// Copyright 2023 Rod Johnson.  All rights reserved

#endregion

using System;
using Newtonsoft.Json;
using TranslationPro.Base.Translations.Interfaces;

namespace TranslationPro.Base.Translations.Models;

public class TranslationDto : ITranslation
{
    public string LanguageName { get; set; }
    public int Id { get; set; }
    public string Text { get; set; }

    [JsonProperty("language")] public string LanguageId { get; set; }

    public DateTime? TranslationDate { get; set; }
}