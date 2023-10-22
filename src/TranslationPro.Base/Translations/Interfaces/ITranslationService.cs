using System;
using System.Threading.Tasks;
using TranslationPro.Base.Common.Models;
using TranslationPro.Base.Common.Services.Interfaces;
using TranslationPro.Base.Translations.Entities;
using TranslationPro.Base.Translations.Models;

namespace TranslationPro.Base.Translations.Interfaces
{
    public interface ITranslationService : IService<Translation>
    {
        Task<Result> CreateTranslationAsync(Guid applicationId, int phraseId, TranslationInput input);
        Task<Result> UpdateTranslationAsync(Guid applicationId, int translationId, TranslationInput input);

    }
}
