using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Azure;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using TranslationPro.Base.Common.Extensions;
using TranslationPro.Base.Common.Middleware.Extensions;

namespace TranslationPro.Jobs;

public class Program
{
    public static void Main(string[] args)
    {
        CreateHostBuilder(args).Build().Run();
    }

    public static IHostBuilder CreateHostBuilder(string[] args) => Host.CreateDefaultBuilder(args)
        .ConfigureFunctionsWorkerDefaults()
        .ConfigureAppConfiguration(x =>
        {
            var environmentName = Environment.GetEnvironmentVariable("ASPNETCORE_ENVIRONMENT");

            var assembly = typeof(HostBuilderExtensions).Assembly;

            x.AddEmbeddedJsonFile(assembly, "sharedSettings.json")
                .AddEmbeddedJsonFile(assembly, $"sharedSettings.{environmentName}.json", true)
                .AddJsonFile("appsettings.json", true)
                .AddJsonFile($"appsettings.{environmentName}.json", true)
                .AddEnvironmentVariables()
                .Build();
        })
        .ConfigureFunctionsWorkerDefaults()
        .ConfigureWebHostDefaults(x =>
        { 
            x.UseStartup<Startup>();
        });
}