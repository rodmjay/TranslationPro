using System.Threading.Tasks;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using TranslationPro.App.Extensions;
using TranslationPro.App.Services;
using TranslationPro.Shared.Policies;

namespace TranslationPro.App;

public class Program
{
    public static async Task Main(string[] args)
    {

        var builder = WebAssemblyHostBuilder.CreateDefault(args);
        builder.RootComponents.Add<App>("#app");
        builder.RootComponents.Add<HeadOutlet>("head::after");

        builder.AddProxies();
        
        builder.Services.AddOidcAuthentication(options =>
        {
            builder.Configuration.Bind("OidcConfiguration", options.ProviderOptions);
            builder.Configuration.Bind("UserOptions", options.UserOptions);
            builder.Configuration.Bind("AuthenticationPaths", options.AuthenticationPaths);

        });

        builder.Services.AddAuthorizationCore(authorizationOptions =>
        {
            authorizationOptions.AddPolicy(
                Policies.CanAccessApis,
                Policies.CanAccessApi());
        });

        builder.Services.AddSingleton<SessionStorageInterop>();
        builder.Services.AddScoped<TokenExpirationService>();

        await builder.Build().RunAsync();
    }
}