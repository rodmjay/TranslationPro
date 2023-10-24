using System.Collections.Generic;
using System.Threading.Tasks;
using TranslationPro.Base.Common.Services.Interfaces;
using TranslationPro.Base.Languages.Entities;
using TranslationPro.Base.Languages.Models;

namespace TranslationPro.Base.Languages.Interfaces;

public interface ILanguageService : IService<Language>
{
    Task<List<T>> GetLanguagesAsync<T>() where T : LanguageDto;
}