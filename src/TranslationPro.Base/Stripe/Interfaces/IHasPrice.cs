using TranslationPro.Base.Stripe.Entities;

namespace TranslationPro.Base.Stripe.Interfaces;

public interface IHasPrice
{
    string PriceId { get; set; }
    StripePrice Price { get; set; }
}