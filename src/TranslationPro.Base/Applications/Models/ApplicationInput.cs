using System.ComponentModel.DataAnnotations;

namespace TranslationPro.Base.Applications.Models;

public class ApplicationInput
{
    [Required] [MinLength(3)] public string Name { get; set; }

    public string[] Languages { get; set; }
}