using System.Collections.Generic;

namespace TranslationPro.Shared.Models;

public class PhraseOutput
{
    public int Id { get; set; }
    public string Text { get; set; }
    public List<MachineTranslationOutput> MachineTranslations { get; set; }
}