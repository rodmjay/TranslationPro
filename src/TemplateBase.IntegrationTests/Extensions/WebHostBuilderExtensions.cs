#region Header

// /*

// Author: Rod Johnson, Architect, rodmjay@gmail.com
// */

#endregion

using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using TranslationPro.Base.Common.Extensions;
using TranslationPro.Base.Common.Middleware.Extensions;

namespace TemplateBase.IntegrationTests.Extensions
{
    public static class CustomWebHostBuilderExtensions
    {
        public static void Configure<TFixture>(WebHostBuilderContext hostingContext,
            IConfigurationBuilder config)
        {
            var env = hostingContext.HostingEnvironment;
            var sharedSettingsAssembly = typeof(HostBuilderExtensions).Assembly;
            var integrationTestAssembly = typeof(TFixture).Assembly;

            config
                .AddEmbeddedJsonFile(sharedSettingsAssembly, "sharedSettings.json")
                .AddEmbeddedJsonFile(sharedSettingsAssembly, $"sharedSettings.{env.EnvironmentName}.json", true)
                .AddEmbeddedJsonFile(integrationTestAssembly, "appsettings.json", true)
                .AddEmbeddedJsonFile(integrationTestAssembly, $"appsettings.{env.EnvironmentName}.json", true);

            config
                .AddEnvironmentVariables()
                .Build();
        }
    }
}