#region Header Info

// Copyright 2023 Rod Johnson.  All rights reserved

#endregion

using Microsoft.Extensions.DependencyInjection.Extensions;
using TranslationPro.Base.ApplicationLanguages.Interfaces;
using TranslationPro.Base.ApplicationLanguages.Services;
using TranslationPro.Base.Common.Middleware.Builders;

namespace TranslationPro.Base.ApplicationLanguages.Extensions;

public static class AppBuilderExtensions
{
    public static AppBuilder AddApplicationLanguageDependencies(this AppBuilder builder)
    {
        builder.Services.TryAddScoped<IApplicationEngineLanguageService, ApplicationLanguageService>();
        return builder;
    }
}