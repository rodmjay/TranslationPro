using System.Threading.Tasks;
using Stripe;
using TranslationPro.Base.Common.Services.Interfaces;
using TranslationPro.Base.Stripe.Entities;
using TranslationPro.Shared.Common;

namespace TranslationPro.Base.Stripe.Interfaces;

public interface IStripeCouponService : IService<StripeCoupon>
{
    Task<Result> HandleCouponCreated(Coupon coupon);
    Task<Result> HandleCouponDeleted(Coupon coupon);
}