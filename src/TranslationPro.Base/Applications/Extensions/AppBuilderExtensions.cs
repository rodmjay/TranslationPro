using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;
using TranslationPro.Base.Applications.Interfaces;
using TranslationPro.Base.Applications.Models;
using TranslationPro.Base.Applications.Services;
using TranslationPro.Base.Common.Middleware.Builders;
using TranslationPro.Base.Common.Services.Interfaces;

namespace TranslationPro.Base.Applications.Extensions
{
    public static class AppBuilderExtensions
    {
        public static FunctionAppBuilder AddApplicationDependencies(this FunctionAppBuilder builder)
        {
            ConfigureServices(builder.Services);
            return builder;
        }

        public static AppBuilder AddApplicationDependencies(this AppBuilder builder)
        {
            ConfigureServices(builder.Services);
            return builder;
        }

        private static void ConfigureServices(IServiceCollection services)
        {
            services.TryAddTransient<ApplicationErrorDescriber>();
            services.TryAddScoped<IApplicationService, ApplicationService>();

        }
    }
}
