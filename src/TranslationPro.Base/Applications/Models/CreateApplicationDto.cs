namespace TranslationPro.Base.Applications.Models
{
    public class CreateApplicationDto
    {
        public string Name { get; set; }
        public string[] SupportedLanguages { get; set; }
        public string ApiKey { get; set; }
    }
}
