using System;
using System.Threading.Tasks;
using TranslationPro.Shared.Common;

namespace TranslationPro.Base.Services
{
    public interface IApplicationLanguageService
    {
        //Task<Result> AddLanguageToApplication(Guid applicationId, ApplicationLanguageOptions options);
        Task<Result> RemoveLanguageFromApplication(Guid applicationId, string languageId);

        Task<string[]> GetLanguagesForApplication(Guid applicationId);
        Task EnsureApplicationLanguages(Guid applicationId, string[] languageIds);
    }
}
