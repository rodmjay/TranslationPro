#region Header Info

// Copyright 2023 Rod Johnson.  All rights reserved

#endregion

using Newtonsoft.Json;

namespace TranslationPro.Shared.Translations;

public class TranslationDto : ITranslation
{
    public string LanguageName { get; set; }
    public int Id { get; set; }
    public string Text { get; set; }

    [JsonProperty("language")] public string LanguageId { get; set; }

    public DateTime? TranslationDate { get; set; }
}