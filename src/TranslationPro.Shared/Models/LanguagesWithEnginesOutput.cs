using System.Collections.Generic;

namespace TranslationPro.Shared.Models;

public class LanguagesWithEnginesOutput : LanguageOutput
{
    public ICollection<EngineOutput> Engines { get; set; }
}