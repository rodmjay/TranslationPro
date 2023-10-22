using System;
using System.Collections.Generic;
using TranslationPro.Base.Applications.Interfaces;

namespace TranslationPro.Base.Applications.Models;

public class ApplicationDto : IApplication
{
    public Guid ApplicationId { get; set; }
    public Guid Id { get; set; }
    public string Name { get; set; }
    public List<string> SupportedLanguages { get; set; }
    
}