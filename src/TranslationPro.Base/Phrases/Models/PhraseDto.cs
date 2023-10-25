using System.Collections.Generic;
using TranslationPro.Base.Phrases.Interfaces;
using TranslationPro.Base.Translations.Models;

namespace TranslationPro.Base.Phrases.Models;

public class PhraseDto : IPhrase
{
    public List<TranslationDto> Translations { get; set; }
    public int TranslationCount { get; set; }
    public int PendingTranslationCount { get; set; }
    public int Id { get; set; }
    public string Text { get; set; }
}