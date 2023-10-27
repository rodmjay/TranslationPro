#region Header Info

// Copyright 2023 Rod Johnson.  All rights reserved

#endregion

using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using TranslationPro.Base.ApplicationLanguages.Models;
using TranslationPro.Base.Common.Models;

namespace TranslationPro.Api.Interfaces;

public interface IApplicationLanguagesController
{
    Task<Result> AddLanguageToApplication(Guid applicationId,
        ApplicationLanguageInput input);

    Task<Result> RemoveLanguageFromApplication(Guid applicationId,
       string languageId);
}