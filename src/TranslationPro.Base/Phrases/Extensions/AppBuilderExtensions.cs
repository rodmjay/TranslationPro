﻿#region Header Info

// Copyright 2023 Rod Johnson.  All rights reserved

#endregion

using Microsoft.Extensions.DependencyInjection.Extensions;
using TranslationPro.Base.Common.Middleware.Builders;
using TranslationPro.Base.Phrases.Interfaces;
using TranslationPro.Base.Phrases.Services;

namespace TranslationPro.Base.Phrases.Extensions;

public static class AppBuilderExtensions
{
    public static AppBuilder AddPhraseDependencies(this AppBuilder builder)
    {
        builder.Services.TryAddTransient<PhraseErrorDescriber>();
        builder.Services.TryAddScoped<IApplicationPhraseService, ApplicationPhraseService>();
        builder.Services.TryAddScoped<IPhraseService, PhraseService>();

        return builder;
    }
}