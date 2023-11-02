#region Header Info

// Copyright 2023 Rod Johnson.  All rights reserved

#endregion

using Microsoft.Extensions.DependencyInjection.Extensions;
using TranslationPro.Base.ApplicationUsers.Interfaces;
using TranslationPro.Base.ApplicationUsers.Services;
using TranslationPro.Base.Common.Middleware.Builders;

namespace TranslationPro.Base.ApplicationUsers.Extensions;

public static class AppBuilderExtensions
{
    public static AppBuilder AddApplicationUserDependencies(this AppBuilder builder)
    {
        builder.Services.TryAddTransient<ApplicationUserErrorDescriber>();
        builder.Services.TryAddScoped<IApplicationUserService, ApplicationUserService>();   
        return builder;
    }
}