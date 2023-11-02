using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using TranslationPro.App;
using TranslationPro.App.MessageHandlers;
using TranslationPro.App.Services;
using TranslationPro.Shared.Policies;

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

        builder.Services.AddHttpClient<IApplicationServiceProxy, ApplicationServiceProxy>(
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

