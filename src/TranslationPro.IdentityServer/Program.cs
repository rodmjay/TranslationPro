#region Header Info

// Copyright 2023 Rod Johnson.  All rights reserved

#endregion

using System.Diagnostics.CodeAnalysis;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Hosting;
using Serilog;
using TranslationPro.Base.Common.Middleware.Extensions;

namespace TranslationPro.IdentityServer;

[ExcludeFromCodeCoverage]
public class Program
{
    public static void Main(string[] args)
    {
        BuildHost(args)
            .Init();
    }

    public static IHostBuilder BuildHost(string[] args)
    {
        return Host.CreateDefaultBuilder(args)
            .ConfigureAppConfiguration(HostBuilderExtensions.Configure)
            .ConfigureWebHostDefaults(builder =>
            {
                builder
                    .ConfigureLogging(HostBuilderExtensions.ConfigureLogging)
                    .UseSerilog()
                    .UseStartup<Startup>();
            });
    }
}