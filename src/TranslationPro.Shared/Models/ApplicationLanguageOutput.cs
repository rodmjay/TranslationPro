namespace TranslationPro.Shared.Models
{
    public class ApplicationLanguageOutput
    {
        public string LanguageId { get; set; }
        public string LanguageName { get; set; }
        public int TranslationCount { get; set; }
        public int PendingTranslationCount { get; set; }
    }
}
