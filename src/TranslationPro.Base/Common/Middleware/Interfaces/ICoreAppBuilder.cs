using System.Collections.Generic;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using TranslationPro.Base.Common.Settings;

namespace TranslationPro.Base.Common.Middleware.Interfaces;

public interface ICoreAppBuilder
{
    IServiceCollection Services { get; }
    AppSettings AppSettings { get; }
    IConfiguration Configuration { get; }
    string ConnectionString { get; set; }
    List<string> AssembliesToMap { get; set; }
}