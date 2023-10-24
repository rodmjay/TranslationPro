#region Header

// /*

// Author: Rod Johnson, Architect, rodmjay@gmail.com
// */

#endregion

using System;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;
using TranslationPro.Base.Common.Data.Contexts;
using TranslationPro.Base.Common.Middleware.Builders;
using TranslationPro.Base.Users.Entities;
using TranslationPro.Base.Users.Factories;
using TranslationPro.Base.Users.Interfaces;
using TranslationPro.Base.Users.Managers;
using TranslationPro.Base.Users.Services;
using TranslationPro.Base.Users.Validators;

namespace TranslationPro.Base.Users.Extensions;

public static class UsersAppBuilderExtensions
{
    public static AppBuilder AddIdentity(this AppBuilder builder)
    {
        builder.Services.AddIdentityCore<User>(options =>
            {
                options.SignIn.RequireConfirmedAccount = true;

                // password requirements
                options.Password.RequireDigit = false;
                options.Password.RequireLowercase = true;
                options.Password.RequireNonAlphanumeric = true;
                options.Password.RequireUppercase = true;

                options.ClaimsIdentity.EmailClaimType = "email";
                options.ClaimsIdentity.RoleClaimType = "role";
                options.ClaimsIdentity.UserIdClaimType = "sub";
                options.ClaimsIdentity.UserNameClaimType = "name";
                options.ClaimsIdentity.SecurityStampClaimType = "ss";

                options.Lockout.MaxFailedAccessAttempts = 5;
                options.Lockout.AllowedForNewUsers = true;
                options.Lockout.DefaultLockoutTimeSpan = TimeSpan.FromDays(1);

                options.Stores.ProtectPersonalData = false;

                options.User.RequireUniqueEmail = true;
            })
            .AddRoles<Role>()
            .AddRoleStore<RoleService>()
            .AddUserStore<UserService>()
            .AddEntityFrameworkStores<ApplicationContext>()
            .AddDefaultTokenProviders()
            .AddDefaultUI()
            .AddClaimsPrincipalFactory<UserRoleClaimsPrincipalFactory>()
            .AddRoleManager<RoleManager>()
            .AddUserManager<UserManager>()
            .AddSignInManager<SignInManager>();

        builder.Services.Configure<DataProtectionTokenProviderOptions>(opt =>
            opt.TokenLifespan = TimeSpan.FromHours(24));


        return builder;
    }

    public static AppBuilder AddUserDependencies(this AppBuilder builder)
    {
        builder.Services.TryAddScoped<IUserService, UserService>();
        builder.Services.TryAddScoped<IRoleService, RoleService>();

        builder.Services.TryAddScoped<IUserClaimsPrincipalFactory<User>, UserRoleClaimsPrincipalFactory>();
        builder.Services.TryAddScoped<UserRoleClaimsPrincipalFactory>();

        builder.Services.TryAddTransient<IPasswordHasher<User>, PasswordHasher<User>>();
        builder.Services.TryAddScoped<IUserConfirmation<User>, DefaultUserConfirmation<User>>();
        builder.Services.TryAddScoped<ILookupNormalizer, UpperInvariantLookupNormalizer>();

        builder.Services.TryAddScoped<IdentityErrorDescriber>();

        builder.Services.TryAddScoped<UserManager<User>, UserManager>();
        builder.Services.TryAddScoped<UserManager>();

        builder.Services.TryAddScoped<RoleManager<Role>, RoleManager>();
        builder.Services.TryAddScoped<RoleManager>();

        builder.Services.TryAddTransient<IUserValidator<User>, DuplicateEmailValidator>();
        builder.Services.TryAddTransient<IUserValidator<User>, DuplicateUserNameValidator>();

        builder.Services.TryAddScoped<IUserAccessor, UserAccessor>();

        return builder;
    }

    public static WebAppBuilder AddSigninDependencies(this WebAppBuilder builder)
    {
        builder.Services.AddHttpContextAccessor();

        builder.Services.TryAddScoped<SignInManager<User>, SignInManager>();
        builder.Services.TryAddScoped<SignInManager>();

        return builder;
    }
}