#region Header Info

// Copyright 2023 Rod Johnson.  All rights reserved

#endregion

using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using TranslationPro.Base.Common.Models;
using TranslationPro.Base.Translations.Models;

namespace TranslationPro.Api.Interfaces;

public interface ITranslationsController
{
    Task<Result> SaveTranslation(Guid applicationId, int phraseId,
        TranslationInput input);
}