using System.Collections.Generic;
using System.Linq;
using TranslationPro.Base.Phrases.Interfaces;
using TranslationPro.Base.Translations.Models;

namespace TranslationPro.Base.Phrases.Models;

public class PhraseDto : IPhrase
{
    public List<TranslationDto> Translations { get; set; }
    public int PendingTranslations => Translations.Count(t => t.Text == null);
    public int Id { get; set; }
    public string Text { get; set; }
}