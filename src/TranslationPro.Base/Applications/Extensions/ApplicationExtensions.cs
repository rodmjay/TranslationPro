#region Header Info

// Copyright 2023 Rod Johnson.  All rights reserved

#endregion

using System.Collections.Generic;
using System.Linq;
using TranslationPro.Base.Applications.Entities;

namespace TranslationPro.Base.Applications.Extensions;

public static class ApplicationExtensions
{
    public static List<string> EnabledLanguages(this Application application)
    {
        return application.Languages.Select(x=>x.LanguageId).ToList();
    }
}