#region Header Info

// Copyright 2023 Rod Johnson.  All rights reserved

#endregion

using System.Net;
using TranslationPro.Shared.Applications;

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

    public static CreateApplicationInput CreateApplication =>
        new()
        {
            Name = "Test",
            Languages = new[] {"en", "es"}
        };
}