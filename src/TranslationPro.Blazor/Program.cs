using Blazorise.Bootstrap5;
using Blazorise.Icons.FontAwesome;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using TranslationPro.Blazor.Extensions;
using TranslationPro.Blazor.Services;
using TranslationPro.Shared.Policies;
using EventAggregator.Blazor;

namespace TranslationPro.Blazor;

public class Program
{
    public static async Task Main(string[] args)
    {
        var builder = WebAssemblyHostBuilder.CreateDefault(args);
        builder.RootComponents.Add<App>("#app");
        builder.RootComponents.Add<HeadOutlet>("head::after");

        builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri(builder.HostEnvironment.BaseAddress) });

        builder.Services.AddScoped<IEventAggregator, EventAggregator.Blazor.EventAggregator>();
        builder.Services.Configure<EventAggregatorOptions>(x=>x.AutoRefresh = true);
        

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
        
        AddBlazorise(builder.Services);

        await builder.Build().RunAsync();


        void AddBlazorise(IServiceCollection services)
        {
            services
                .AddBlazorise(x =>
                {
                    x.ProductToken = "C028-DAD6-D291-4193-BF53-C678-251C";
                });
            services
                .AddBootstrap5Providers()
                .AddFontAwesomeIcons();

        }

    }
}