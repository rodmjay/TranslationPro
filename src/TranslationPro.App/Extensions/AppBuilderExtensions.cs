using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Net.Http;
using TranslationPro.App.MessageHandlers;
using TranslationPro.Shared.Interfaces;
using TranslationPro.Shared.Proxies;

namespace TranslationPro.App.Extensions
{
    public static class WebAssemblyHostBuilderExtensions
    {
        public static WebAssemblyHostBuilder AddProxies(this WebAssemblyHostBuilder builder)
        {
            builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri(builder.HostEnvironment.BaseAddress) });

            builder.Services
                .AddTransient<ApiAuthorizationMessageHandler>();

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

            builder.Services.AddHttpClient<IApplicationPhrasesController, ApplicationPhrasesProxy>(
                    client => client.BaseAddress = url)
                .AddHttpMessageHandler<ApiAuthorizationMessageHandler>();

            builder.Services.AddHttpClient<IApplicationTranslationsController, ApplicationTranslationsProxy>(
                    client => client.BaseAddress = url)
                .AddHttpMessageHandler<ApiAuthorizationMessageHandler>();
            

            return builder;
        }
    }
}
