using System.Collections.Generic;
using System.Linq;

namespace TranslationPro.Shared.Models;

public class ApplicationPhraseDetails : ApplicationPhraseOutput
{
    public List<ApplicationTranslationOutput> Translations { get; set; }
}