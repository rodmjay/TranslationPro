#region Header Info

// Copyright 2023 Rod Johnson.  All rights reserved

#endregion

using TranslationPro.Base.Common.Data.Enums;
using TranslationPro.Base.Entities;

namespace TranslationPro.Base.Extensions;

public static class ApplicationLanguageExtensions
{
    public static ApplicationLanguage UnDelete(this ApplicationLanguage appLanguage)
    {
        appLanguage.IsDeleted = false;
        appLanguage.ObjectState = ObjectState.Modified;

        foreach (var translation in appLanguage.Translations)
        {
            translation.IsDeleted = false;
            translation.ObjectState = ObjectState.Modified;
        }

        return appLanguage;
    }
}