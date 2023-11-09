using System;
using System.Threading.Tasks;
using TranslationPro.Shared.Common;
using TranslationPro.Shared.Models;

namespace TranslationPro.Base.ApplicationLanguages.Interfaces
{
    public interface IApplicationEngineLanguageService
    {
        Task<Result> AddLanguageToApplication(Guid applicationId, ApplicationLanguageInput input);
        Task<Result> RemoveLanguageFromApplication(Guid applicationId, string languageId);
    }
}
