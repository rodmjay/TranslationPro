#region Header

// /*

// Author: Rod Johnson, Architect, rodmjay@gmail.com
// */

#endregion

using System;
using System.Diagnostics;
using System.Diagnostics.CodeAnalysis;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Serilog;
using Serilog.Debugging;
using Serilog.Events;
using TemplateBase.Common.Extensions;
using ILogger = Serilog.ILogger;

namespace TemplateBase.Common.Middleware.Extensions
{
    [ExcludeFromCodeCoverage]
    public static class HostBuilderExtensions
    {
        public static IConfiguration Configuration { get; set; }

        public static void ConfigureLogging(WebHostBuilderContext hostingContext, ILoggingBuilder logging)
        {
            logging.AddConsole();

            if (hostingContext.HostingEnvironment.IsDevelopment())
            {
                logging.AddDebug();
                logging.SetMinimumLevel(LogLevel.Debug);
            }
            else
            {
                logging.SetMinimumLevel(LogLevel.Information);
            }

            logging.AddFilter(DbLoggerCategory.Database.Connection.Name, LogLevel.Information);
            logging.AddFilter("TemplateBase", LogLevel.Information);
            logging.AddFilter("IdentityServer4", LogLevel.Warning);
        }

        public static void Configure(HostBuilderContext hostingContext,
            IConfigurationBuilder config)
        {
            var env = hostingContext.HostingEnvironment;
            var assembly = typeof(HostBuilderExtensions).Assembly;

            config
                .AddEmbeddedJsonFile(assembly, "sharedSettings.json")
                .AddEmbeddedJsonFile(assembly, $"sharedSettings.{env.EnvironmentName}.json", true)
                .AddJsonFile("appsettings.json", true)
                .AddJsonFile($"appsettings.{env.EnvironmentName}.json", true);

            config
                .AddEnvironmentVariables()
                .Build();
        }

        public static void Configure(WebHostBuilderContext hostingContext,
            IConfigurationBuilder config)
        {
            var env = hostingContext.HostingEnvironment;
            var assembly = typeof(HostBuilderExtensions).Assembly;

            config
                .AddEmbeddedJsonFile(assembly, "sharedSettings.json")
                .AddEmbeddedJsonFile(assembly, $"sharedSettings.{env.EnvironmentName}.json", true)
                .AddJsonFile("appsettings.json", true)
                .AddJsonFile($"appsettings.{env.EnvironmentName}.json", true);

            config
                .AddEnvironmentVariables()
                .Build();
        }


        public static ILogger CreateLogger()
        {
            SelfLog.Enable(msg =>
            {
                Debug.Print(msg);
                Debugger.Break();
            });
            return new LoggerConfiguration()
                .MinimumLevel
                .Debug()
                .Enrich
                .FromLogContext()
                .WriteTo
                .Console(LogEventLevel.Debug,
                    "{Timestamp:yyyy-MM-dd HH:mm:ss.fff zzz} [{Level:u3}] {Message:lj}{NewLine}{Exception}")
                .WriteTo
                .File(@"c:\home\logfiles\application\myapp.txt",
                    outputTemplate:
                    "{Timestamp:yyyy-MM-dd HH:mm:ss.fff zzz} [{Level:u3}] {Message:lj}{NewLine}{Exception}",
                    fileSizeLimitBytes: 1_000_000,
                    rollOnFileSizeLimit: true,
                    shared: true,
                    flushToDiskInterval: TimeSpan.FromSeconds(1))
                .CreateLogger();
        }


        public static void Init(
            this IHostBuilder hostBuilder,
            string initMessage = "Starting Application",
            string exceptionMessage = "Application terminated unexpectedly"
        )
        {
            Log.Logger = CreateLogger();

            try
            {
                Log.Information(initMessage);
                hostBuilder.Build().Run();
            }
            catch (Exception ex)
            {
                Log.Fatal(ex, exceptionMessage);
            }
            finally
            {
                Log.CloseAndFlush();
            }
        }
    }
}