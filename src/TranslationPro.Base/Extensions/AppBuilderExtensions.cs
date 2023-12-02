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
using Stripe;
using Stripe.Checkout;
using TranslationPro.Base.Managers;
using TranslationPro.Shared.Proxies;
using SubscriptionService = TranslationPro.Base.Services.SubscriptionService;

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
        builder.Services.TryAddScoped<ILanguageService, LanguageService>();
        builder.Services.TryAddScoped<IApplicationConsumptionService, ApplicationConsumptionService>();
        builder.Services.TryAddScoped<ISubscriptionService, SubscriptionService>();

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

        builder.Services.AddScoped<IStripeClient>(x =>
        {
            var stripeApiKey = Environment.GetEnvironmentVariable("TranslationProStripeSecretTest");
            if (string.IsNullOrEmpty(stripeApiKey))
            {
                stripeApiKey = x.GetRequiredService<IConfiguration>()["TranslationProStripeSecretTest"];
            }
            return new StripeClient(stripeApiKey);
        });

        builder.Services.AddScoped(x =>
            new PaymentLinkService(x.GetRequiredService<IStripeClient>()));

        builder.Services.AddScoped(x => 
            new SessionService(x.GetRequiredService<IStripeClient>()));

        builder.Services.AddScoped(x =>
            new Stripe.SubscriptionService(x.GetRequiredService<IStripeClient>()));


        return builder;
    }
}