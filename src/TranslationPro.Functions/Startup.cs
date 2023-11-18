#region Header Info

// Copyright 2023 Rod Johnson.  All rights reserved

#endregion

using System;
using Microsoft.Azure.Functions.Extensions.DependencyInjection;
using Microsoft.Extensions.Configuration;
using TranslationPro.Base.Common.Data.Contexts;
using TranslationPro.Base.Common.Extensions;
using TranslationPro.Base.Common.Middleware.Extensions;
using TranslationPro.Base.Extensions;
using TranslationPro.Base.Stripe.Extensions;

namespace TranslationPro.Functions;

public class Startup : FunctionsStartup
{
    public override void ConfigureAppConfiguration(IFunctionsConfigurationBuilder builder)
    {
        var environmentName = Environment.GetEnvironmentVariable("ASPNETCORE_ENVIRONMENT");

        FunctionsHostBuilderContext context = builder.GetContext();
        var assembly = typeof(HostBuilderExtensions).Assembly;

        var settings = builder.ConfigurationBuilder
            .AddEmbeddedJsonFile(assembly, "sharedSettings.json")
            .AddEmbeddedJsonFile(assembly, $"sharedSettings.{environmentName}.json", true)
            .AddJsonFile("appsettings.json", true)
            .AddJsonFile($"appsettings.{environmentName}.json", true)
            .AddEnvironmentVariables()
            .Build();

    }

    public override void Configure(IFunctionsHostBuilder builder)
    {
        //var appBuilder = builder.Services.ConfigureApp(builder.GetContext())
        //    .AddDatabase<ApplicationContext>()
        //    .AddAutomapperProfilesFromAssemblies()
        //    .AddTranslationProDependencies()
        //    .AddStripeDependencies();
    }
}