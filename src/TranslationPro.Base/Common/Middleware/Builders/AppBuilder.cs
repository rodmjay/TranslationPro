#region Header

// /*

// Author: Rod Johnson, Architect, rodmjay@gmail.com
// */

#endregion

using System.Collections.Generic;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using TranslationPro.Base.Common.Middleware.Interfaces;
using TranslationPro.Base.Common.Settings;

namespace TranslationPro.Base.Common.Middleware.Builders
{
    public class AppBuilder 
    {
        public AppBuilder(
            IServiceCollection services,
            AppSettings settings,
            IConfiguration configuration)
        {
            Services = services;
            Configuration = configuration;
            AppSettings = settings;
            AssembliesToMap = new List<string>();
        }

        public List<string> AssembliesToMap { get; set; }
        public IServiceCollection Services { get; }
        public IConfiguration Configuration { get; }
        public string ConnectionString { get; set; }
        public AppSettings AppSettings { get; set; }

    }
}