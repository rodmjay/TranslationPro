using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TranslationPro.Base.Translations.Interfaces;

namespace TranslationPro.Base.Translations.Models
{
    public class TranslationDto : ITranslation
    {
        public int Id { get; set; }
        public string OriginalText { get; set; }
        public DateTime? TranslationDate { get; set; }

        public List<TranslationDto> Languages { get; set; }
    }
}
