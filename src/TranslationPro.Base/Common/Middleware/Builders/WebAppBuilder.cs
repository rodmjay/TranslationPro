﻿#region Header Info

// Copyright 2023 Rod Johnson.  All rights reserved

#endregion

using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using AppSettings = TranslationPro.Base.Settings.AppSettings;

namespace TranslationPro.Base.Common.Middleware.Builders;

[ExcludeFromCodeCoverage]
public class WebAppBuilder
{
    public WebAppBuilder(
        AppBuilder appBuilder,
        IWebHostEnvironment environment)
    {
        Environment = environment;
        AppSettings = appBuilder.AppSettings;
        Services = appBuilder.Services;
        Configuration = appBuilder.Configuration;
        ConnectionString = appBuilder.ConnectionString;
        AssembliesToMap = appBuilder.AssembliesToMap;
    }

    public IWebHostEnvironment Environment { get; }
    public ICollection<string> AssembliesToMap { get; set; }
    public IServiceCollection Services { get; }
    public IConfiguration Configuration { get; }
    public string ConnectionString { get; set; }
    public AppSettings AppSettings { get; set; }
}