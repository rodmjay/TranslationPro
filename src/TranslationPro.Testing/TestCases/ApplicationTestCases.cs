#region Header Info

// Copyright 2023 Rod Johnson.  All rights reserved

#endregion

using System.Collections.Generic;
using System.Net;
using Microsoft.Extensions.ObjectPool;
using TranslationPro.Shared.Enums;
using TranslationPro.Shared.Models;

namespace TranslationPro.Testing.TestCases;

public static class ApplicationTestCases
{
    public static object[] CreateModels => new object[]
    {
        new object[]
        {
            CreateApplication
        }
    };

    public static object[] UpdateModels => new object[]
    {
        new object[]
        {
            UpdateApplication
        }
    };

    public static ApplicationOptions UpdateApplication =>
        new()
        {
            Name = "Updated"
        };

    public static ApplicationCreateOptions CreateApplication =>
        new()
        {
            Name = "Test",
            Languages = new List<string>()
            {
                "en",
                "es"
            }
        };
}