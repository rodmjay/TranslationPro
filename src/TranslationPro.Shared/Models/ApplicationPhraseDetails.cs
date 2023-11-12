using System.Collections.Generic;
using System.Linq;

namespace TranslationPro.Shared.Models;

public class ApplicationPhraseDetails : ApplicationPhraseOutput
{

    public List<ApplicationTranslationOutput> Translations { get; set; }

    public PhraseOutput Phrase { get; set; }

    
    public Dictionary<string, int> MachineTranslationCount
    {
        get
        {
            return Phrase.MachineTranslations.GroupBy(x => x.LanguageId)
                .ToDictionary(g => g.Key, g => g.Count());
        }
    }

    public Dictionary<string, List<MachineTranslationOutput>> MachineTranslations
    {
        get
        {
            return Phrase.MachineTranslations.GroupBy(x => x.LanguageId)
                .ToDictionary(x => x.Key, x => x.ToList());
        }
    }

}