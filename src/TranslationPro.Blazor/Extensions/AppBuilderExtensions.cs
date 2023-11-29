using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using TranslationPro.Blazor.MessageHandlers;
using TranslationPro.Shared.Interfaces;
using TranslationPro.Shared.Proxies;

namespace TranslationPro.Blazor.Extensions
{
    public static class WebAssemblyHostBuilderExtensions
    {
        public static WebAssemblyHostBuilder AddProxies(this WebAssemblyHostBuilder builder)
        {
            builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri(builder.HostEnvironment.BaseAddress) });

            builder.Services
                .AddTransient<ApiAuthorizationMessageHandler>();

            var url = new Uri(builder.Configuration["ApiBase"]);
            var translationsUrl = new Uri(builder.Configuration["TranslationsUrl"]);

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

            builder.Services.AddHttpClient<IApplicationPhrasesController, ApplicationPhrasesProxy>(
                    client => client.BaseAddress = url)
                .AddHttpMessageHandler<ApiAuthorizationMessageHandler>();

            builder.Services.AddHttpClient<IApplicationTranslationsController, ApplicationTranslationsProxy>(
                    client => client.BaseAddress = url)
                .AddHttpMessageHandler<ApiAuthorizationMessageHandler>();

            builder.Services.AddHttpClient<IApplicationConsumptionController, ApplicationConsumptionProxy>(
                    client => client.BaseAddress = url)
                .AddHttpMessageHandler<ApiAuthorizationMessageHandler>();

            builder.Services.AddHttpClient<TranslationsProxy>(
                client => client.BaseAddress = translationsUrl);

            return builder;
        }
    }
}
