#region Header Info

// Copyright 2023 Rod Johnson.  All rights reserved

#endregion

using Microsoft.Extensions.DependencyInjection.Extensions;
using TranslationPro.Base.Common.Middleware.Builders;
using TranslationPro.Base.Engines.Interfaces;
using TranslationPro.Base.Engines.Services;

namespace TranslationPro.Base.Engines.Extensions;

public static class AppBuilderExtensions
{
    public static AppBuilder AddEngineDependencies(this AppBuilder builder)
    {
        builder.Services.TryAddScoped<IEngineService, EngineService>();
        return builder;
    }
}