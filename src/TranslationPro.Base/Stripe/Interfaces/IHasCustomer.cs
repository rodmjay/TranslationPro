using TranslationPro.Base.Stripe.Entities;

namespace TranslationPro.Base.Stripe.Interfaces;

public interface IHasCustomer
{
    StripeCustomer Customer { get; set; }
    string CustomerId { get; set; }
}