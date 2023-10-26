#region Header Info

// Copyright 2023 Rod Johnson.  All rights reserved

#endregion

using System;
using Google.Cloud.Translation.V2;
using Microsoft.Extensions.DependencyInjection.Extensions;
using TranslationPro.Base.Common.Middleware.Builders;
using TranslationPro.Base.Translations.Interfaces;
using TranslationPro.Base.Translations.Models;
using TranslationPro.Base.Translations.Services;

namespace TranslationPro.Base.Translations.Extensions;

public static class AppBuilderExtensions
{
    public static AppBuilder AddTranslationDependencies(this AppBuilder builder)
    {
        builder.Services.TryAddTransient<TranslationErrorDescriber>();
        builder.Services.TryAddScoped<ITranslationService, TranslationService>();

        builder.Services.TryAddSingleton(x =>
        {
            var apiKey = Environment.GetEnvironmentVariable("TranslationProGoogleApi");
            var client = TranslationClient.CreateFromApiKey(apiKey);
            return client;
        });

        return builder;
    }
}