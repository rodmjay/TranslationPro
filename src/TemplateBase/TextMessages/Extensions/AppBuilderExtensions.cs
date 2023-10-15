#region Header

// /*

// Author: Rod Johnson, Architect, rodmjay@gmail.com
// */

#endregion

using Microsoft.Extensions.DependencyInjection.Extensions;
using TemplateBase.Common.Middleware.Builders;
using TemplateBase.TextMessages.Services;
using Twilio;

namespace TemplateBase.TextMessages.Extensions
{
    public static class AppBuilderExtensions
    {
        public static AppBuilder AddTwilio(this AppBuilder builder)
        {
            TwilioClient.Init(builder.AppSettings.Twilio.AccountSid, builder.AppSettings.Twilio.AuthToken);

            builder.Services.TryAddScoped<TwilioSmsService>();

            return builder;
        }
    }
}