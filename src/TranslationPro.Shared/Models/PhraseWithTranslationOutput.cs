using System.Collections.Generic;
using System.Linq;
using Newtonsoft.Json;

namespace TranslationPro.Shared.Models;

public class PhraseWithTranslationOutput : PhraseOutput
{
    private Dictionary<string, string> _dictionary = new();

    [JsonIgnore]
    public List<HumanTranslationOutput> HumanTranslations { get; set; }

    [JsonIgnore]
    public List<MachineTranslationOutput> MachineTranslations { get; set; }

    [JsonProperty("translations")]
    public Dictionary<string, string> Translations
    {
        get
        {
            _dictionary = MachineTranslations.GroupBy(x => x.LanguageId)
                .ToDictionary(x => x.Key, x => x.First().Text);

            foreach (var kvp in _dictionary)
            {
                if (HumanTranslations.Any(x => x.LanguageId == kvp.Key))
                {
                    _dictionary[kvp.Key] = HumanTranslations.First(x=>x.LanguageId == kvp.Key).Text;
                }
            }

            return _dictionary;
        }
    }

}