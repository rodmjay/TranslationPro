#region Header Info

// Copyright 2023 Rod Johnson.  All rights reserved

#endregion

using TranslationPro.Shared.Common;
using TranslationPro.Shared.Translations;

namespace TranslationPro.Shared.Controllers;

public interface ITranslationsController
{
    Task<Result> SaveTranslation(Guid applicationId, int phraseId,
        TranslationInput input);
}