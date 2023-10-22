using System;
using System.Collections.Generic;
using TranslationPro.Base.Translations.Interfaces;

namespace TranslationPro.Base.Translations.Models
{
    public class TranslationDto : ITranslation
    {
        public int Id { get; set; }
        public string Text { get; set; }
        public DateTime? TranslationDate { get; set; }
        
    }
}
