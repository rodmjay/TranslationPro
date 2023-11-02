using System;
using System.Threading.Tasks;
using TranslationPro.Shared.ApplicationLanguages;
using TranslationPro.Shared.Common;

namespace TranslationPro.Base.ApplicationLanguages.Interfaces
{
    public interface IApplicationLanguageService
    {
        Task<Result> AddLanguageToApplication(Guid applicationId, ApplicationLanguageInput input);
        Task<Result> RemoveLanguageFromApplication(Guid applicationId, string languageId);
    }
}
