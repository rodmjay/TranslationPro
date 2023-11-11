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

public interface IMachineTranslationService : IService<MachineTranslation>
{
    Task<Result> SaveTranslation(Guid applicationId, int phraseId, TranslationOptions input);
    
    
    Task<List<Result>> ProcessTranslationsForApplicationAsync(Guid applicationId);

    Task<Result> ProcessTranslationsForApplicationLanguageAsync(Guid applicationId, string languageId);
}