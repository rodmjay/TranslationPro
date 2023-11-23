using System.Collections.Generic;

namespace TranslationPro.Shared.Models;

public class ApplicationPhraseDetails : ApplicationPhraseOutput
{
    public List<ApplicationTranslationOutput> Translations { get; set; }
}