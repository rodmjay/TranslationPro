using System;
using System.Collections.Generic;
using TranslationPro.Base.Translations.Interfaces;

namespace TranslationPro.Base.Translations.Models;

public class PhraseDto : IPhrase
{
    public int Id { get; set; }
    public string Text { get; set; }
    public List<TranslationDto> Translations { get; set; }
}