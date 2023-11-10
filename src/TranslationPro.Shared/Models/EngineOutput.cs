using TranslationPro.Shared.Enums;
using TranslationPro.Shared.Interfaces;

namespace TranslationPro.Shared.Models;

public class EngineOutput : IEngine
{
    public TranslationEngine Id { get; set; }
    public string Name { get; set; }
    public bool Enabled { get; set; }

}