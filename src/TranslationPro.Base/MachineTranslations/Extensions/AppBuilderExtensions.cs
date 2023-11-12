#region Header Info

// Copyright 2023 Rod Johnson.  All rights reserved

#endregion

using Google.Cloud.Translation.V2;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;
using System;
using TranslationPro.Base.Common.Middleware.Builders;
using TranslationPro.Base.MachineTranslations.Interfaces;
using TranslationPro.Base.MachineTranslations.Services;

namespace TranslationPro.Base.MachineTranslations.Extensions;

public static class AppBuilderExtensions
{
    public static AppBuilder AddMachineTranslationDependencies(this AppBuilder builder)
    {
        builder.Services.TryAddTransient<TranslationErrorDescriber>();
        builder.Services.TryAddScoped<IMachineTranslationService, MachineTranslationService>();

        builder.Services.TryAddScoped<IEngineService, EngineService>();

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

        builder.Services.AddScoped<MicrosoftTranslationService>();
        builder.Services.AddScoped<GoogleTranslationService>();
        return builder;
        return builder;
    }
}