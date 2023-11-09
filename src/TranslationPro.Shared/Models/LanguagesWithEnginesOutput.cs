using System.Collections.Generic;

namespace TranslationPro.Shared.Models;

public class LanguagesWithEnginesOutput : LanguageOutput
{
    public List<EngineOutput> Engines { get; set; }
}