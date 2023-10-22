using System;
using System.Collections.Generic;

namespace TranslationPro.Base.Applications.Models;

public class ApplicationDto
{
    public Guid ApplicationId { get; set; }
    public string Name { get; set; }
    public List<string> SupportedLanguages { get; set; }
    
}