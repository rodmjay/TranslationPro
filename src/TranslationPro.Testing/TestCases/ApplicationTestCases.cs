#region Header Info

// Copyright 2023 Rod Johnson.  All rights reserved

#endregion

using System.Collections.Generic;
using System.Net;
using TranslationPro.Shared.Enums;
using TranslationPro.Shared.Models;

namespace TranslationPro.Testing.TestCases;

public static class ApplicationTestCases
{
    public static object[] CreateModels => new object[]
    {
        new object[]
        {
            CreateApplication,
            HttpStatusCode.OK
        }
    };

    public static ApplicationCreateOptions CreateApplication =>
        new()
        {
            Name = "Test",
            EnginesWithLanguages = new Dictionary<TranslationEngine, List<string>>()
            {
                {TranslationEngine.Google, new List<string>()
                {
                    "es",
                    "en"
                }}
            }
        };
}