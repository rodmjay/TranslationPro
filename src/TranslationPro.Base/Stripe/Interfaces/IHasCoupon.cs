using TranslationPro.Base.Stripe.Entities;

namespace TranslationPro.Base.Stripe.Interfaces;

public interface IHasCoupon
{
    StripeCoupon Coupon { get; set; }
    string CouponId { get; set; }
}