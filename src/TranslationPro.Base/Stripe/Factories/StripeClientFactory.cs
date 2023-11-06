using System;
using Stripe;
using TranslationPro.Base.Stripe.Config;

namespace TranslationPro.Base.Stripe.Factories
{
    public class StripeClientFactory
    {
        public static StripeClient GetFromSettings(StripeSettings config)
        {
            var apiKey = Environment.GetEnvironmentVariable(config.SecretKeyEnvironmentVariableName);

            return new StripeClient(apiKey: apiKey);
        }
    }
}
