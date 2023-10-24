using Microsoft.Extensions.DependencyInjection.Extensions;
using TranslationPro.Base.Applications.Models;
using TranslationPro.Base.Common.Middleware.Builders;
using TranslationPro.Base.Permissions.Interfaces;
using TranslationPro.Base.Permissions.Services;

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