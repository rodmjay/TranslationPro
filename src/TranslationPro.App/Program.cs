using System;
using System.Net.Http;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Solutaris.InfoWARE.ProtectedBrowserStorage.Extensions;
using TranslationPro.App.MessageHandlers;
using TranslationPro.Shared.Interfaces;
using TranslationPro.Shared.Policies;
using TranslationPro.Shared.Proxies;

namespace TranslationPro.App;

public class Program
{
    public static async Task Main(string[] args)
    {

        var builder = WebAssemblyHostBuilder.CreateDefault(args);
        builder.RootComponents.Add<App>("#app");
        builder.RootComponents.Add<HeadOutlet>("head::after");

        builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri(builder.HostEnvironment.BaseAddress) });
        
        builder.Services
            .AddTransient<ApiAuthorizationMessageHandler>();

        builder.Services.AddOidcAuthentication(options =>
        {
            builder.Configuration.Bind("OidcConfiguration", options.ProviderOptions);
            builder.Configuration.Bind("UserOptions", options.UserOptions);
            builder.Configuration.Bind("AuthenticationPaths", options.AuthenticationPaths);
        });

        var url = new Uri(builder.Configuration["ApiBase"]);
        
        builder.Services.AddHttpClient<IApplicationsController, ApplicationsProxy>(
                client => client.BaseAddress = url)
            .AddHttpMessageHandler<ApiAuthorizationMessageHandler>();

        builder.Services.AddHttpClient<IApplicationLanguagesController, ApplicationLanguagesProxy>(
                client => client.BaseAddress = url)
            .AddHttpMessageHandler<ApiAuthorizationMessageHandler>();

        builder.Services.AddHttpClient<IApplicationUsersController, ApplicationUsersProxy>(
                client => client.BaseAddress = url)
            .AddHttpMessageHandler<ApiAuthorizationMessageHandler>();

        builder.Services.AddHttpClient<ILanguagesController, LanguagesProxy>(
            client => client.BaseAddress = url);

        builder.Services.AddHttpClient<IPhrasesController, PhrasesProxy>(
                client => client.BaseAddress = url)
            .AddHttpMessageHandler<ApiAuthorizationMessageHandler>();

        builder.Services.AddHttpClient<ITranslationsController, TranslationsProxy>(
                client => client.BaseAddress = url)
            .AddHttpMessageHandler<ApiAuthorizationMessageHandler>();

        builder.Services.AddHttpClient<IEnginesController, EnginesProxy>(
                client => client.BaseAddress = url)
            .AddHttpMessageHandler<ApiAuthorizationMessageHandler>();

        builder.Services.AddIWProtectedBrowserStorageAsSingleton();

        builder.Services.AddAuthorizationCore(authorizationOptions =>
        {
            authorizationOptions.AddPolicy(
                Policies.CanAccessApis,
                Policies.CanAccessApi());
        });

        await builder.Build().RunAsync();
    }
}