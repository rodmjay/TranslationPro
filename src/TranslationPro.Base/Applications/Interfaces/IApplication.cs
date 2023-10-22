using System;

namespace TranslationPro.Base.Applications.Interfaces;

public interface IApplication
{
    Guid Id { get; set; }
    string Name { get; set; }
    public string ApiKey { get; set; }

}