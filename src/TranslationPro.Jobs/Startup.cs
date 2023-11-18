using Microsoft.AspNetCore.Hosting;
using Microsoft.Azure.Functions.Extensions.DependencyInjection;
using Microsoft.Azure.Functions.Worker;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Hosting;
using Microsoft.Extensions.Azure;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using TranslationPro.Base.Common.Data.Contexts;
using TranslationPro.Base.Common.Middleware.Extensions;
using TranslationPro.Base.Extensions;
using TranslationPro.Base.Stripe.Extensions;

namespace TranslationPro.Jobs
{

    public class Startup 
    {
        private readonly IConfiguration _configuration;
        private readonly IWebHostEnvironment _environment;

        public Startup(IConfiguration configuration, IWebHostEnvironment environment)
        {
            _configuration = configuration;
            _environment = environment;
        }

        public void ConfigureServices(IServiceCollection services)
        {

            services.AddApplicationInsightsTelemetryWorkerService();
            services.ConfigureFunctionsApplicationInsights();

            var builder = services.ConfigureApp(_configuration)
                .AddDatabase<ApplicationContext>()
                .AddAutomapperProfilesFromAssemblies()
                .AddCaching()
                .AddTranslationProDependencies()
                .AddStripeDependencies();
        }
        
        public void Configure(IServiceProvider builder)
        {
            
        }
    }
}
