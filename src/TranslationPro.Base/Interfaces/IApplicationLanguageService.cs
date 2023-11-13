using System;
using System.Threading.Tasks;
using TranslationPro.Shared.Common;
using TranslationPro.Shared.Models;

namespace TranslationPro.Base.Interfaces
{
    public interface IApplicationLanguageService
    {
        Task<Result> AddLanguageToApplication(Guid applicationId, ApplicationLanguageOptions options);
        Task<Result> RemoveLanguageFromApplication(Guid applicationId, string languageId);
    }
}
