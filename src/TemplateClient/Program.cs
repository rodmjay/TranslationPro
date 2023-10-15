#region Header

// /*

// Author: Rod Johnson, Architect, rodmjay@gmail.com
// */

#endregion

using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using TranslationPro.Base.Common.Middleware.Extensions;

namespace TemplateClient
{
    public class Program
    {
        private static void Main(string[] args)
        {
            CreateHostBuilder(args).Init();
        }

        private static IHostBuilder CreateHostBuilder(string[] args)
        {
            return Host.CreateDefaultBuilder(args)
                .ConfigureAppConfiguration(HostBuilderExtensions.Configure)
                .ConfigureServices((hostBuilderContext, services) =>
                {
                    services.ConfigureApp(hostBuilderContext.Configuration, hostBuilderContext.HostingEnvironment);
                    services.AddHostedService<Worker>();
                });
        }
    }
}