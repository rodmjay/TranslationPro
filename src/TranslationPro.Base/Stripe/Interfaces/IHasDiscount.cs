using TranslationPro.Base.Stripe.Entities;

namespace TranslationPro.Base.Stripe.Interfaces;

public interface IHasDiscount
{
    string DiscountId { get; set; }
    StripeDiscount Discount { get; set; }
}