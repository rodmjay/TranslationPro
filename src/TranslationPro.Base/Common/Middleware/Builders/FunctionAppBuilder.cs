using System.Collections.Generic;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using TranslationPro.Base.Common.Middleware.Interfaces;
using TranslationPro.Base.Common.Settings;

namespace TranslationPro.Base.Common.Middleware.Builders;

public abstract class CoreAppBuilder : ICoreAppBuilder
{
    public IServiceCollection Services { get; }
    public AppSettings AppSettings { get; }
    public IConfiguration Configuration { get; }
    public string ConnectionString { get; set; }
    public List<string> AssembliesToMap { get; set; }


    protected CoreAppBuilder(IServiceCollection services, AppSettings appSettings, IConfiguration configuration)
    {
        Services = services;
        AppSettings = appSettings;
        Configuration = configuration;
        AssembliesToMap = new List<string>();
    }
}

public class FunctionAppBuilder : CoreAppBuilder
{
    public FunctionAppBuilder(IServiceCollection services, AppSettings appSettings, IConfiguration configuration) : base(services, appSettings, configuration)
    {
    }
}