using System;

namespace TranslationPro.Base.Translations.Interfaces;

public interface ITranslation
{
    string OriginalText { get; set; }
    DateTime? TranslationDate { get; set; }
}