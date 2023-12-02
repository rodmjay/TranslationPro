﻿#region Header Info

// Copyright 2023 Rod Johnson.  All rights reserved

#endregion

using Microsoft.AspNetCore.Identity.UI.Services;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;
using SendGrid;
using TranslationPro.Base.Common.Middleware.Builders;
using TranslationPro.Base.Email.Services;
using AppSettings = TranslationPro.Base.Settings.AppSettings;

namespace TranslationPro.Base.Email.Extensions;

public static class AppBuilderExtensions
{
    public static AppBuilder WithNoopEmailSender(this AppBuilder builder)
    {
        builder.Services.AddScoped<IEmailSender, NoopEmailSender>();
        return builder;
    }

    public static AppBuilder WithSendgridEmailSender(this AppBuilder builder)
    {
        builder.Services.AddSingleton(sp =>
        {
            var appSettings = sp.GetRequiredService<IOptions<AppSettings>>();
            return new SendGridClient(appSettings.Value.SendGrid.ApiKey);
        });

        builder.Services.AddScoped<IEmailSender, SendgridEmailSender>();

        return builder;
    }
}