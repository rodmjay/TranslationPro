using System;
using System.Threading.Tasks;
using TranslationPro.Base.ApplicationLanguages.Models;
using TranslationPro.Base.Common.Models;

namespace TranslationPro.Base.ApplicationLanguages.Interfaces
{
    public interface IApplicationLanguageService
    {
        Task<Result> AddLanguageToApplication(Guid applicationId, ApplicationLanguageInput input);
        Task<Result> RemoveLanguageFromApplication(Guid applicationId, string languageId);
    }
}
