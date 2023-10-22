using System;

namespace TranslationPro.Base.Translations.Interfaces;

public interface ITranslation
{
    int Id { get; set; }
    string Text { get; set; }
    public string LanguageId { get; set; }
    DateTime? TranslationDate { get; set; }
}