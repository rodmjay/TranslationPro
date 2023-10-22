using System;
using System.Collections.Generic;
using Newtonsoft.Json;
using TranslationPro.Base.Translations.Interfaces;

namespace TranslationPro.Base.Translations.Models
{
    public class TranslationDto : ITranslation
    {
        public int Id { get; set; }
        public string Text { get; set; }

        [JsonProperty("language")]
        public string LanguageId { get; set; }
        public string LanguageName { get; set; }
        public DateTime? TranslationDate { get; set; }
        
    }
}
