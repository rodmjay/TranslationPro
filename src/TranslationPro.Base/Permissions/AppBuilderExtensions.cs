#region Header Info

// Copyright 2023 Rod Johnson.  All rights reserved

#endregion

using Microsoft.Extensions.DependencyInjection.Extensions;
using TranslationPro.Base.Common.Middleware.Builders;

namespace TranslationPro.Base.Permissions;

public static class AppBuilderExtensions
{
    public static AppBuilder AddPermissionExtensions(this AppBuilder builder)
    {
        builder.Services.TryAddScoped<IPermissionService, PermissionService>();

        return builder;
    }
}