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

    public static IServiceCollection AddTranslationProServices(this IServiceCollection services)
    {
        services.TryAddTransient<PhraseErrorDescriber>();
        services.TryAddTransient<TranslationErrorDescriber>();
        services.TryAddTransient<ApplicationErrorDescriber>();
        services.TryAddTransient<ApplicationUserErrorDescriber>();

        services.TryAddScoped<IApplicationService, ApplicationService>();
        services.TryAddScoped<IApplicationPhraseService, ApplicationPhraseService>();
        services.TryAddScoped<IApplicationTranslationService, ApplicationTranslationService>();
        services.TryAddScoped<IApplicationLanguageService, ApplicationLanguageService>();

        services.TryAddScoped<IPhraseService, PhraseService>();
        services.TryAddScoped<IPermissionService, PermissionService>();
        services.TryAddScoped<IMachineTranslationService, MachineTranslationService>();
        services.TryAddScoped<IEngineService, EngineService>();
        services.TryAddScoped<ILanguageService, LanguageService>();
        services.TryAddScoped<IJobService, JobService>();

        services.TryAddScoped<ApplicationManager>();
        services.TryAddScoped<LanguageManager>();
        services.TryAddScoped<ApplicationLanguageManager>();
        services.TryAddScoped<ApplicationTranslationManager>();
        services.TryAddScoped<PhraseManager>();
        services.TryAddScoped<EngineManager>();
        services.TryAddScoped<JobManager>();

        services.TryAddSingleton(x =>
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

        services.TryAddScoped<MicrosoftTranslationService>();
        services.TryAddScoped<GoogleTranslationService>();

        services.TryAddSingleton(x =>
        {
            var configuration = x.GetRequiredService<IConfiguration>();
            return new ServiceBusClient(configuration.GetConnectionString("AzureServiceBusConnection"));
        });
        services.TryAddSingleton<JobSender>();
        return services;
    }

    public static AppBuilder AddTranslationProDependencies(this AppBuilder builder)
    {
        builder.Services.AddTranslationProServices();
        return builder;
    }
}