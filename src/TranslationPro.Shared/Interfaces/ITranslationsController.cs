#region Header Info

// Copyright 2023 Rod Johnson.  All rights reserved

#endregion

using System;
using System.Threading.Tasks;
using TranslationPro.Shared.Common;
using TranslationPro.Shared.Models;

namespace TranslationPro.Shared.Interfaces;

public interface ITranslationsController
{
    Task<Result> SaveTranslation(Guid applicationId, int phraseId,
        TranslationOptions input);
}