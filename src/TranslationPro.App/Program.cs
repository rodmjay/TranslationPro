using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using TranslationPro.App.MessageHandlers;
using TranslationPro.App.Proxies;
using TranslationPro.Shared.Interfaces;
using TranslationPro.Shared.Policies;

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
            .AddTransient<TranslationProApiAuthorizationMessageHandler>();

        builder.Services.AddOidcAuthentication(options =>
        {
            builder.Configuration.Bind("OidcConfiguration", options.ProviderOptions);
            builder.Configuration.Bind("UserOptions", options.UserOptions);
        });

        builder.Services.AddHttpClient<IApplicationsController, ApplicationsProxy>(
                client => client.BaseAddress = new Uri("https://localhost:44329/"))
            .AddHttpMessageHandler<TranslationProApiAuthorizationMessageHandler>();

        builder.Services.AddHttpClient<IApplicationLanguagesController, ApplicationLanguagesProxy>(
                client => client.BaseAddress = new Uri("https://localhost:44329/"))
            .AddHttpMessageHandler<TranslationProApiAuthorizationMessageHandler>();

        builder.Services.AddHttpClient<IApplicationUsersController, ApplicationUsersProxy>(
                client => client.BaseAddress = new Uri("https://localhost:44329/"))
            .AddHttpMessageHandler<TranslationProApiAuthorizationMessageHandler>();

        builder.Services.AddHttpClient<ILanguagesController, LanguagesProxy>(
                client => client.BaseAddress = new Uri("https://localhost:44329/"))
            .AddHttpMessageHandler<TranslationProApiAuthorizationMessageHandler>();

        builder.Services.AddHttpClient<IPhrasesController, PhrasesProxy>(
                client => client.BaseAddress = new Uri("https://localhost:44329/"))
            .AddHttpMessageHandler<TranslationProApiAuthorizationMessageHandler>();

        builder.Services.AddHttpClient<ITranslationsController, TranslationsProxy>(
                client => client.BaseAddress = new Uri("https://localhost:44329/"))
            .AddHttpMessageHandler<TranslationProApiAuthorizationMessageHandler>();


        builder.Services.AddAuthorizationCore(authorizationOptions =>
        {
            authorizationOptions.AddPolicy(
                Policies.CanAccessApis,
                Policies.CanAccessApi());
        });

        await builder.Build().RunAsync();
    }
}