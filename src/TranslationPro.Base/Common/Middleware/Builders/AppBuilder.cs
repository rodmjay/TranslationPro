#region Header

// /*

// Author: Rod Johnson, Architect, rodmjay@gmail.com
// */

#endregion

using System.Collections.Generic;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using TranslationPro.Base.Common.Settings;

namespace TranslationPro.Base.Common.Middleware.Builders
{
    public class FunctionAppBuilder
    {
        public IServiceCollection Services { get; }
        public AppSettings AppSettings { get; }
        public IConfiguration Configuration { get; }
        public string ConnectionString { get; set; }
        public List<string> AssembliesToMap { get; set; }


        public FunctionAppBuilder(IServiceCollection services, AppSettings appSettings, IConfiguration configuration)
        {
            Services = services;
            AppSettings = appSettings;
            Configuration = configuration;
            AssembliesToMap = new List<string>();
        }
    }

    public class AppBuilder
    {
        public AppBuilder(
            IServiceCollection services,
            AppSettings settings,
            IHostEnvironment environment,
            IConfiguration configuration)
        {
            Services = services;
            Configuration = configuration;
            AppSettings = settings;
            HostEnvironment = environment;
            AssembliesToMap = new List<string>();
        }

        public IHostEnvironment HostEnvironment { get; set; }
        public List<string> AssembliesToMap { get; set; }
        public IServiceCollection Services { get; }
        public IConfiguration Configuration { get; }
        public string ConnectionString { get; set; }
        public AppSettings AppSettings { get; set; }
        public string AzureStorageConnectionString { get; set; }
        public string AzureServiceBusConnectionString { get; set; }

    }
}