using TranslationPro.Shared.Enums;

namespace TranslationPro.Shared.Models
{
    public class ApplicationEngineLanguageOutput
    {
        public TranslationEngine EngineId { get; set; }
        public string EngineName { get; set; }
        public string LanguageId { get; set; }
        public string LanguageName { get; set; }
        public int TranslationCount { get; set; }
        public int PendingTranslationCount { get; set; }
    }
}
