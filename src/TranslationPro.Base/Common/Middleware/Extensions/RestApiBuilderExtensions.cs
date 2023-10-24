#region Header

// /*

// Author: Rod Johnson, Architect, rodmjay@gmail.com
// */

#endregion

using System;
using System.Diagnostics.CodeAnalysis;
using System.IO;
using System.Net.Mime;
using System.Reflection;
using System.Runtime.CompilerServices;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Logging;
using Microsoft.OpenApi.Models;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using Serilog;
using TranslationPro.Base.Common.Data.Contexts;
using TranslationPro.Base.Common.Middleware.Builders;
using TranslationPro.Base.Common.Middleware.Swagger;
using TranslationPro.Base.Common.Settings;

namespace TranslationPro.Base.Common.Middleware.Extensions;

[ExcludeFromCodeCoverage]
public static class RestApiBuilderExtensions
{
    private static bool _swaggerAdded;

    private static string GetLogMessage(string message, [CallerMemberName] string callerName = null)
    {
        return $"[{nameof(RestApiBuilderExtensions)}.{callerName}] - {message}";
    }


    public static RestApiBuilder AddSwagger(this RestApiBuilder builder,
        Assembly assembly)
    {
        Log.Logger.Debug(GetLogMessage("Adding swagger"));
        _swaggerAdded = true;
        builder.Services.AddSwaggerGen(c =>
        {
            c.SwaggerDoc("v1", new OpenApiInfo
            {
                Version = "v1",
                Title = builder.AppSettings.Name
            });


            // Set the comments path for the Swagger JSON and UI.
            var xmlFile = $"{assembly.GetName().Name}.xml";
            var xmlPath = Path.Combine(AppContext.BaseDirectory, xmlFile);
            c.IncludeXmlComments(xmlPath);
            c.SchemaFilter<SwaggerExcludeFilter>();
            c.DocumentFilter<LowercaseDocumentFilter>();
        });

        return builder;
    }

    public static RestApiBuilder ConfigureRest(this WebAppBuilder builder)
    {
        Log.Logger.Debug(GetLogMessage("ConfigureRestServices"));
        builder.Services.AddHttpContextAccessor();
        builder.Services.AddScoped<HttpContextAccessor>();


        builder.Services.AddControllers(x => { x.EnableEndpointRouting = true; })
            .AddNewtonsoftJson(o =>
            {
                o.SerializerSettings.ContractResolver = new CamelCasePropertyNamesContractResolver();
                o.SerializerSettings.Formatting = Formatting.Indented;
                o.SerializerSettings.ReferenceLoopHandling = ReferenceLoopHandling.Ignore;
                o.SerializerSettings.NullValueHandling = NullValueHandling.Include;
            })
            .ConfigureApiBehaviorOptions(o =>
            {
                o.InvalidModelStateResponseFactory = c =>
                {
                    var result = new BadRequestObjectResult(c.ModelState);
                    result.ContentTypes.Add(MediaTypeNames.Application.Json);

                    return result;
                };
            });


        return new RestApiBuilder(builder);
    }

    public static RestApiBuilder AddCors(this RestApiBuilder builder, params string[] origins)
    {
        builder.Services.AddCors(options =>
        {
            options.AddDefaultPolicy(
                opts => opts
                    .WithOrigins(origins)
                    .AllowAnyMethod()
                    .AllowAnyHeader()
            );
        });

        return builder;
    }

    public static void Configure(IApplicationBuilder app, IWebHostEnvironment env, ApplicationContext context,
        IOptions<AppSettings> settings)
    {
        var appSettings = settings.Value;

        IdentityModelEventSource.ShowPII = true;

        app.UseMiddleware<ExceptionMiddleware>();

        app.UseStaticFiles();

        if (_swaggerAdded)
        {
            app.UseSwagger();
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", appSettings.Name);
                c.DisplayRequestDuration();
                c.RoutePrefix = string.Empty;
            });
        }

        app.UseHttpsRedirection();

        app.UseRouting();

        app.UseAuthentication();
        app.UseAuthorization();
        app.UseCors();

        app.UseEndpoints(endpoints =>
        {
            endpoints.MapControllers()
                .RequireAuthorization("ApiScope");
        });
    }
}