using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Authorization;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.UI;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using TranslationPro.Base.Applications.Extensions;
using TranslationPro.Base.ApplicationUsers.Extensions;
using TranslationPro.Base.Common.Data.Contexts;
using TranslationPro.Base.Common.Extensions;
using TranslationPro.Base.Common.Middleware.Extensions;
using TranslationPro.Base.Common.Services.Interfaces;
using TranslationPro.Base.Languages.Extensions;
using TranslationPro.Base.Permissions.Extensions;
using TranslationPro.Base.Phrases.Extensions;
using TranslationPro.Base.Translations.Extensions;
using TranslationPro.Base.Users.Entities;
using TranslationPro.Base.Users.Extensions;
using TranslationPro.Base.Users.Services;
using TranslationPro.Web.Areas.Identity;
using TranslationPro.Web.Data;

var builder = WebApplication.CreateBuilder(args);

var environmentName = Environment.GetEnvironmentVariable("ASPNETCORE_ENVIRONMENT");
var assembly = typeof(HostBuilderExtensions).Assembly;

var config = new ConfigurationBuilder();

config
    .AddEmbeddedJsonFile(assembly, "sharedSettings.json")
    .AddEmbeddedJsonFile(assembly, $"sharedSettings.{environmentName}.json", true)
    .AddJsonFile("appsettings.json", true)
    .AddJsonFile($"appsettings.{environmentName}.json", true);

config
    .AddEnvironmentVariables();

var appBuilder = builder.Services.ConfigureApp(config.Build())
    .AddDatabase<ApplicationContext>()
    .AddIdentity()
    .AddAutomapperProfilesFromAssemblies()
    .AddPermissionExtensions()
    .AddLanguageDependencies()
    .AddApplicationDependencies()
    .AddPhraseDependencies()
    .AddApplicationUserDependencies()
    .AddUserDependencies()
.AddTranslationDependencies();


builder.Services.AddDatabaseDeveloperPageExceptionFilter();
builder.Services.AddRazorPages();
builder.Services.AddServerSideBlazor();
builder.Services.AddScoped<AuthenticationStateProvider, RevalidatingIdentityAuthenticationStateProvider>();
builder.Services.AddSingleton<WeatherForecastService>();


builder.Services.AddDefaultIdentity<User>(options => options.SignIn.RequireConfirmedAccount = true)
    .AddEntityFrameworkStores<ApplicationContext>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseMigrationsEndPoint();
}
else
{
    app.UseExceptionHandler("/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();

app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllers();
app.MapBlazorHub();
app.MapFallbackToPage("/_Host");

app.Run();
