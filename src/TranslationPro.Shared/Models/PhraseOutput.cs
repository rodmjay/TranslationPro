namespace TranslationPro.Shared.Models;

public class PhraseOutput
{

    public string Text { get; set; }
    public MachineTranslationOutput[] MachineTranslations { get; set; }
}