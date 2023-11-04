using TranslationPro.Base.Stripe.Entities;

namespace TranslationPro.Base.Stripe.Interfaces;

public interface IHasCard
{
    StripeCard Card { get; set; } 
}