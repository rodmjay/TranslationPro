using System;

namespace TranslationPro.Base.Translations.Interfaces;

public interface IPhrase
{
    int Id { get; set; }
    string Text { get; set; }
}