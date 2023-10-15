#region Header

// /*

// Author: Rod Johnson, Architect, rodmjay@gmail.com
// */

#endregion

using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using TranslationPro.Base.Common.Middleware.Extensions;

namespace TemplateMvcClient
{
    public class Startup
    {
        public Startup(IConfiguration configuration, IWebHostEnvironment environment)
        {
            Configuration = configuration;
            Environment = environment;
        }

        public IWebHostEnvironment Environment { get; }
        public IConfiguration Configuration { get; }

        public void ConfigureServices(IServiceCollection services)
        {
            var builder = services.ConfigureApp(Configuration, Environment)
                .ConfigureWebApp(Environment)
                .ConfigureMvcClient();
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            MvcClientBuilderExtensions.Configure(app, env);
        }
    }
}