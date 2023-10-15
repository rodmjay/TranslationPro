#region Header

// /*

// Author: Rod Johnson, Architect, rodmjay@gmail.com
// */

#endregion

using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using TemplateBase.Common.Data.Contexts;
using TemplateBase.Common.Middleware.Extensions;
using TemplateBase.Email.Extensions;
using TemplateBase.IdentityServer.Extensions;
using TemplateBase.Users.Extensions;

namespace TemplateIdentityServer
{
    public class Startup
    {
        public Startup(IConfiguration configuration, IWebHostEnvironment environment)
        {
            Configuration = configuration;
            Environment = environment;
        }

        public IWebHostEnvironment Environment { get; }
        public IConfiguration Configuration { get; }

        public void ConfigureServices(IServiceCollection services)
        {
            var builder = services.ConfigureApp(Configuration, Environment)
                .AddDatabase<ApplicationContext>()
                .AddIdentity()
                .AddAutomapperProfilesFromAssemblies()
                .AddCaching()
                .AddUserDependencies();

            if (Environment.IsDevelopment())
                builder.WithNoopEmailSender();
            else
                builder.WithSendgridEmailSender();

            var webBuilder = builder.ConfigureWebApp(Environment)
                .AddAuthorization(policy => { policy.RequireAuthenticatedUser(); })
                .AddSigninDependencies();
            ;

            var idBuilder = webBuilder.ConfigureIdentityServer();

            var uiBuilder = webBuilder.ConfigureUI(options =>
                {
                    options.Conventions.AuthorizeFolder("/Account/Manage", "ApiScope");
                })
                .AddCookies()
                .AddSession()
                .AddAntiForgery()
                .AddAuthentication();
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env, ApplicationContext context)
        {
            IdentityBuilderExtensions.Configure(app, env, context);
        }
    }
}