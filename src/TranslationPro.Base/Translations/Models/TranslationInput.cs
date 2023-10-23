using System.ComponentModel.DataAnnotations;

namespace TranslationPro.Base.Translations.Models;

public class TranslationInput
{
    [Required]
    [MinLength(2)]
    public string Text { get; set; }

    [MinLength(2)]
    [Required]
    public string LanguageId { get; set; }
}