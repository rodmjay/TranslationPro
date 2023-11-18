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
using Azure.Messaging.ServiceBus;
using TranslationPro.Base.Messaging;

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
        builder.Services.TryAddTransient<PhraseErrorDescriber>();
        builder.Services.TryAddTransient<TranslationErrorDescriber>();
        builder.Services.TryAddTransient<ApplicationErrorDescriber>();
        builder.Services.TryAddTransient<ApplicationUserErrorDescriber>();

        builder.Services.TryAddScoped<IApplicationService, ApplicationService>();
        builder.Services.TryAddScoped<IApplicationPhraseService, ApplicationPhraseService>();
        builder.Services.TryAddScoped<IApplicationTranslationService, ApplicationTranslationService>();
        builder.Services.TryAddScoped<IApplicationLanguageService, ApplicationLanguageService>();

        builder.Services.TryAddScoped<IPhraseService, PhraseService>();
        builder.Services.TryAddScoped<IPermissionService, PermissionService>();
        builder.Services.TryAddScoped<IMachineTranslationService, MachineTranslationService>();
        builder.Services.TryAddScoped<IEngineService, EngineService>();
        builder.Services.TryAddScoped<ILanguageService, LanguageService>();
        builder.Services.TryAddScoped<IJobService, JobService>();

        builder.Services.TryAddScoped<ApplicationManager>();
        builder.Services.TryAddScoped<LanguageManager>();
        builder.Services.TryAddScoped<ApplicationLanguageManager>();
        builder.Services.TryAddScoped<ApplicationTranslationManager>();
        builder.Services.TryAddScoped<PhraseManager>();
        builder.Services.TryAddScoped<EngineManager>();
        builder.Services.TryAddScoped<JobManager>();

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

        builder.Services.TryAddScoped<MicrosoftTranslationService>();
        builder.Services.TryAddScoped<GoogleTranslationService>();

        builder.Services.TryAddSingleton(x =>
            new ServiceBusClient(builder.AzureServiceBusConnectionString));
        builder.Services.TryAddSingleton<JobSender>();
        return builder;
    }
}