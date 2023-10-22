using System.Collections.Generic;
using TranslationPro.Base.Common.Services.Interfaces;
using TranslationPro.Base.Languages.Entities;
using TranslationPro.Base.Languages.Models;

namespace TranslationPro.Base.Languages.Interfaces
{
    public interface ILanguageService : IService<Language>
    {
        IList<T> GetLanguages<T>() where T : LanguageDto;
    }
}
