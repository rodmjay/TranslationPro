using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Google.Cloud.Translation.V2;
using TranslationPro.Base.Common.Models;
using TranslationPro.Base.Common.Services.Interfaces;
using TranslationPro.Base.Translations.Entities;
using TranslationPro.Base.Translations.Models;

namespace TranslationPro.Base.Translations.Interfaces;

public interface ITranslationService : IService<Translation>
{
    Task<Result> SaveTranslation(Guid applicationId, int phraseId, TranslationInput input);

    Task<Result> DeleteTranslation(Guid applicationId, int phraseId, string languageId);

    Task<List<T>> GetTranslationsForLanguageAndApplicationAsync<T>(Guid applicationId, string languageId)
        where T : TranslationDto;

    Task<Dictionary<Guid, Dictionary<string, List<string>>>> GetMissingTranslationsByApplicationByLanguageAsync(Guid applicationId);

    Task<Result> SaveTranslationResultsAsync(Guid applicationId, List<TranslationResult> input);

    Task<List<Result>> ProcessTranslationsForApplicationAsync(Guid applicationId);
}