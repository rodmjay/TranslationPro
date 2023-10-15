#region Header

// /*

// Author: Rod Johnson, Architect, rodmjay@gmail.com
// */

#endregion

using Microsoft.Extensions.DependencyInjection.Extensions;
using TemplateBase.Common.Middleware.Builders;
using TemplateBase.Geography.Interfaces;
using TemplateBase.Geography.Models;
using TemplateBase.Geography.Services;

namespace TemplateBase.Geography.Extensions
{
    public static class AppBuilderExtensions
    {
        public static AppBuilder AddGeographyDependencies(this AppBuilder builder)
        {
            builder.Services.TryAddTransient<GeographyErrorDescriber>();
            builder.Services.TryAddScoped<ICountryService, CountryService>();
            builder.Services.TryAddScoped<IEnabledCountryService, EnabledCountryService>();

            return builder;
        }
    }
}