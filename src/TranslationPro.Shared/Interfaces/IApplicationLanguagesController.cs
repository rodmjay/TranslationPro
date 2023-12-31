﻿#region Header Info

// Copyright 2023 Rod Johnson.  All rights reserved

#endregion

using System;
using System.Threading.Tasks;
using TranslationPro.Shared.Common;
using TranslationPro.Shared.Models;
using TranslationPro.Shared.Results;

namespace TranslationPro.Shared.Interfaces;

public interface IApplicationLanguagesController
{
    Task<LanguageAddedResult> AddLanguageToApplicationAsync(Guid applicationId,
        ApplicationLanguageOptions options);

    Task<Result> RemoveLanguageFromApplicationAsync(Guid applicationId,
        string languageId);
}