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

    Task<Result> ReplaceTranslation(Guid applicationId, int phraseId,
        TranslationReplacementOptions options);
}