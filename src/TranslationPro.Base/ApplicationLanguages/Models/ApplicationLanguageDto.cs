namespace TranslationPro.Base.ApplicationLanguages.Models
{
    public class ApplicationLanguageDto
    {
        public string LanguageId { get; set; }
        public string LanguageName { get; set; }
        public int Translations { get; set; }
        public int PendingTranslations { get; set; }
    }
}
