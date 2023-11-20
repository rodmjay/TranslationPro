#region Header Info

// Copyright 2023 Rod Johnson.  All rights reserved

#endregion

using Microsoft.Extensions.DependencyInjection.Extensions;
using TranslationPro.Base.Common.Middleware.Builders;
using TranslationPro.Base.Services;
using TranslationPro.Base.Errors;
using Google.Cloud.Translation.V2;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using TranslationPro.Base.Managers;
using TranslationPro.Shared.Proxies;
using System.Security.Policy;

namespace TranslationPro.Base.Extensions;

public static class AppBuilderExtensions
{


    public static AppBuilder AddTranslationProUserDependencies(this AppBuilder builder)
    {
        builder.Services.TryAddScoped<IApplicationUserService, ApplicationUserService>();
        builder.Services.TryAddScoped<ApplicationUsersManager>();

        return builder;
    }
    
    public static AppBuilder AddTranslationProDependencies(this AppBuilder builder)
    {
        builder.Services.AddHttpClient<TranslationsProxy>(
                client => client.BaseAddress = new Uri(builder.AppSettings.TranslationsUrl));

        builder.Services.TryAddTransient<PhraseErrorDescriber>();
        builder.Services.TryAddTransient<TranslationErrorDescriber>();
        builder.Services.TryAddTransient<ApplicationErrorDescriber>();
        builder.Services.TryAddTransient<ApplicationUserErrorDescriber>();

        builder.Services.TryAddScoped<IApplicationService, ApplicationService>();
        builder.Services.TryAddScoped<IApplicationPhraseService, ApplicationPhraseService>();
        builder.Services.TryAddScoped<IApplicationTranslationService, ApplicationTranslationService>();
        builder.Services.TryAddScoped<IApplicationLanguageService, ApplicationLanguageService>();
        builder.Services.TryAddScoped<IPermissionService, PermissionService>();

        builder.Services.TryAddScoped<ApplicationManager>();
        builder.Services.TryAddScoped<ApplicationLanguageManager>();
        builder.Services.TryAddScoped<ApplicationTranslationManager>();
        builder.Services.TryAddScoped<ApplicationPhraseManager>();

        builder.Services.TryAddSingleton(x =>
        {
            var googleTranslateApiKey = Environment.GetEnvironmentVariable("TranslationProGoogleApi");
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