using TranslationPro.Base.Languages.Interfaces;

namespace TranslationPro.Base.Languages.Models
{
    
    public class LanguageDto : ILanguage
    {
        public string Name { get; set; }
        public string Id { get; set; }
    }
}
