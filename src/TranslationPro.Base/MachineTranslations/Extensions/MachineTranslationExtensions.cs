#region Header Info

// Copyright 2023 Rod Johnson.  All rights reserved

#endregion

using System.Collections.Generic;
using System.Linq;
using TranslationPro.Base.MachineTranslations.Entities;

namespace TranslationPro.Base.MachineTranslations.Extensions;

public static class MachineTranslationExtensions
{
    public static bool HasLanguage(this IEnumerable<MachineTranslation> translations, string language)
    {
        return translations.Any(x=>x.LanguageId == language);
    }
}