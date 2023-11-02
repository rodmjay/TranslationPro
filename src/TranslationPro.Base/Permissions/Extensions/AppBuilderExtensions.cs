#region Header Info

// Copyright 2023 Rod Johnson.  All rights reserved

#endregion

using Microsoft.Extensions.DependencyInjection.Extensions;
using TranslationPro.Base.Common.Middleware.Builders;
using TranslationPro.Base.Permissions.Interfaces;
using TranslationPro.Base.Permissions.Services;
using ApplicationErrorDescriber = TranslationPro.Base.Applications.ApplicationErrorDescriber;

namespace TranslationPro.Base.Permissions.Extensions;

public static class AppBuilderExtensions
{
    public static AppBuilder AddPermissionExtensions(this AppBuilder builder)
    {
        builder.Services.TryAddTransient<ApplicationErrorDescriber>();
        builder.Services.TryAddScoped<IPermissionService, PermissionService>();

        return builder;
    }
}