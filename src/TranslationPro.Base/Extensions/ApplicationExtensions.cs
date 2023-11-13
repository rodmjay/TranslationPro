#region Header Info

// Copyright 2023 Rod Johnson.  All rights reserved

#endregion

using System.Collections.Generic;
using System.Linq;
using TranslationPro.Base.Entities;

namespace TranslationPro.Base.Extensions;

public static class ApplicationExtensions
{
    public static List<string> EnabledLanguages(this Application application)
    {
        return application.Languages.Select(x => x.LanguageId).ToList();
    }
}