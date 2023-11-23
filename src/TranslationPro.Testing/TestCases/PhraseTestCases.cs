#region Header Info

// Copyright 2023 Rod Johnson.  All rights reserved

#endregion

using System.Collections.Generic;
using TranslationPro.Shared.Models;

namespace TranslationPro.Testing.TestCases;

public static class PhraseTestCases
{
    public static object[] PhrasesWithTranslations => new object[]
    {
        new object[]
        {
            CreatePhrase,
            new Dictionary<string, string>
            {
                {"en", "house"},
                {"es", "casa"}
            }
        }
    };

    public static ApplicationPhrasesCreateOptions CreatePhrase =>
        new()
        {
            Texts = new List<string>() {"house"}
        };

}