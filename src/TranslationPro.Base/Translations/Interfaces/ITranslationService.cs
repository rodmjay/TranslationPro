#region Header Info

// Copyright 2023 Rod Johnson.  All rights reserved

#endregion

using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using TranslationPro.Base.Common.Services.Interfaces;
using TranslationPro.Base.Translations.Entities;
using TranslationPro.Shared.Common;
using TranslationPro.Shared.Models;

namespace TranslationPro.Base.Translations.Interfaces;

public interface ITranslationService : IService<Translation>
{
    Task<Result> SaveTranslation(Guid applicationId, int phraseId, TranslationOptions input);

    Task<Result> DeleteTranslation(Guid applicationId, int phraseId, string languageId);

    Task<List<T>> GetTranslationsForApplicationForLanguage<T>(Guid applicationId, string languageId)
        where T : TranslationDto;
    
    Task<List<Result>> ProcessTranslationsForApplicationAsync(Guid applicationId);

    Task<Result> ProcessTranslationsForApplicationLanguageAsync(Guid applicationId, string languageId);
}