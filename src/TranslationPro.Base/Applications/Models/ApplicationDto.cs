using System;
using System.Collections.Generic;
using TranslationPro.Base.Applications.Interfaces;

namespace TranslationPro.Base.Applications.Models;

public class ApplicationDto : IApplication
{
    public List<string> SupportedLanguages { get; set; }
    public int PhraseCount { get; set; }
    public int TranslationCount { get; set; }
    public int PendingTranslationCount { get; set; }
    public Guid Id { get; set; }
    public string Name { get; set; }
}