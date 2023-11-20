using Microsoft.Azure.Functions.Worker;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using TranslationPro.Base.Common.Data.Contexts;
using TranslationPro.Base.Common.Extensions;
using TranslationPro.Base.Common.Middleware.Extensions;
using TranslationPro.Base.Extensions;
using TranslationPro.Base.Stripe.Extensions;


var host = new HostBuilder()
    .ConfigureFunctionsWorkerDefaults()
    .ConfigureAppConfiguration(configure =>
    {
        var environmentName = Environment.GetEnvironmentVariable("ASPNETCORE_ENVIRONMENT");
        var assembly = typeof(HostBuilderExtensions).Assembly;

        configure.AddEmbeddedJsonFile(assembly, "sharedSettings.json")
                        .AddEmbeddedJsonFile(assembly, $"sharedSettings.{environmentName}.json", true)
                        .AddJsonFile("appsettings.json", true).AddJsonFile($"appsettings.{environmentName}.json", true)
                        .AddEnvironmentVariables()
                        .Build();
    })
    .ConfigureServices((context,services) =>
    {
        services.AddApplicationInsightsTelemetryWorkerService();
        services.ConfigureFunctionsApplicationInsights();
        services.ConfigureApp(context.Configuration)
            .AddDatabase<ApplicationContext>()
            .AddAutomapperProfilesFromAssemblies()
            .AddCaching()
            .AddTranslationProDependencies()
            .AddStripeDependencies();
    })
    .Build();

host.Run();


//public class Program
//{
//    public static void Main(string[] args)
//    {
//        CreateHostBuilder(args).Build().Run();
//    }

//    public static IHostBuilder CreateHostBuilder(string[] args) => Host.CreateDefaultBuilder(args)
//        .ConfigureFunctionsWorkerDefaults()
//        //.ConfigureAppConfiguration(builder =>
//        //{
//        //    var environmentName = Environment.GetEnvironmentVariable("ASPNETCORE_ENVIRONMENT");

//        //    var assembly = typeof(HostBuilderExtensions).Assembly;

//        //    builder.AddEmbeddedJsonFile(assembly, "sharedSettings.json")
//        //        .AddEmbeddedJsonFile(assembly, $"sharedSettings.{environmentName}.json", true)
//        //        .AddJsonFile("appsettings.json", true).AddJsonFile($"appsettings.{environmentName}.json", true)
//        //        .AddEnvironmentVariables()
//        //        .Build();
//        //})
//        .ConfigureServices((context, services) =>
//        {
//            services.AddApplicationInsightsTelemetryWorkerService();
//            services.ConfigureFunctionsApplicationInsights();

//            //services.ConfigureApp(context.Configuration)
//            //    .AddDatabase<ApplicationContext>()
//            //    .AddAutomapperProfilesFromAssemblies()
//            //    .AddCaching()
//            //    .AddTranslationProDependencies()
//            //    .AddStripeDependencies();
//        })
//        .ConfigureFunctionsWorkerDefaults();
//}