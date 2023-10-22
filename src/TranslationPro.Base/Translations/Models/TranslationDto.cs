using System;
using System.Collections.Generic;
using TranslationPro.Base.Languages.Models;
using TranslationPro.Base.Translations.Interfaces;

namespace TranslationPro.Base.Translations.Models
{
    public class TranslationDto : ITranslation
    {
        public int Id { get; set; }
        public string OriginalText { get; set; }
        public DateTime? TranslationDate { get; set; }
        
        public List<PhraseDto> Phrases { get; set; }
    }
}
