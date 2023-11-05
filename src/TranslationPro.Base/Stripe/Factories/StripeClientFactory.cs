using Stripe;
using TranslationPro.Base.Stripe.Config;

namespace TranslationPro.Base.Stripe.Factories
{
    public class StripeClientFactory
    {
        public static StripeClient GetFromSettings(StripeSettings config)
        {
            return new StripeClient(
                apiKey: config.ApiKey,
                clientId: config.ClientId,
                apiBase: config.ApiBase);
        }
    }
}
