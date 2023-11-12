#region Header Info

// Copyright 2023 Rod Johnson.  All rights reserved

#endregion

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
        builder.Services.TryAddScoped<IMachineTranslationService, MachineTranslationService>();


        return builder;
    }
}