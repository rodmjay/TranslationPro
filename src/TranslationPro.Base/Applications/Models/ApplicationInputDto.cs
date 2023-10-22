using System.ComponentModel.DataAnnotations;

namespace TranslationPro.Base.Applications.Models
{
    public class ApplicationInputDto
    {
        [Required]
        public string Name { get; set; }
        public string[] Languages { get; set; }
        public string ApiKey { get; set; }
    }
}
