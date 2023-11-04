using TranslationPro.Base.Stripe.Entities;

namespace TranslationPro.Base.Stripe.Interfaces;

public interface IHasSubscription
{
    string SubscriptionId { get; set; }
    StripeSubscription Subscription { get; set; }
}