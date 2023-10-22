using System;
using System.Collections.Generic;
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
        Task<List<T>> GetTranslationsForLanguageAndApplicationAsync<T>(Guid applicationId, string languageId)
            where T : TranslationDto;

    }
}
