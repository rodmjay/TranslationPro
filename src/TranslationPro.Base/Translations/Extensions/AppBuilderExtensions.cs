#region Header Info

// Copyright 2023 Rod Johnson.  All rights reserved

#endregion

using System;
using Google.Cloud.Translation.V2;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;
using TranslationPro.Base.Common.Middleware.Builders;
using TranslationPro.Base.Translations.Interfaces;
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
            string googleTranslateApiKey = Environment.GetEnvironmentVariable("TranslationProGoogleApi");
            if (string.IsNullOrEmpty(googleTranslateApiKey))
            {
                googleTranslateApiKey = x.GetRequiredService<IConfiguration>()["TranslationProGoogleApi"];
            }

            var apiKey = googleTranslateApiKey;
            var client = TranslationClient.CreateFromApiKey(apiKey);
            return client;
        });

        return builder;
    }
}