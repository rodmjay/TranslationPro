#region Header Info

// Copyright 2023 Rod Johnson.  All rights reserved

#endregion

using System;
using System.Threading.Tasks;
using TranslationPro.Base.ApplicationLanguages.Models;
using TranslationPro.Base.Common.Models;

namespace TranslationPro.Api.Interfaces;

public interface IApplicationLanguagesController
{
    Task<Result> AddLanguageToApplicationAsync(Guid applicationId,
        ApplicationLanguageInput input);

    Task<Result> RemoveLanguageFromApplicationAsync(Guid applicationId,
        string languageId);
}