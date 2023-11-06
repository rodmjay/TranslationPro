using System.Threading.Tasks;
using Stripe;
using TranslationPro.Base.Common.Services.Interfaces;
using TranslationPro.Base.Stripe.Entities;
using TranslationPro.Shared.Common;

namespace TranslationPro.Base.Stripe.Managers;

public interface ICouponManager : IService<StripeCoupon>
{
    Task<Result> CreateCoupon(CouponCreateOptions options);
    Task<Result> UpdateCoupon(string couponId, CouponUpdateOptions options);
    Task<Result> DeleteCoupon(string couponId, CouponDeleteOptions options);
    Task<Result> HandleCouponCreated(Coupon coupon);
    Task<Result> HandleCouponDeleted(Coupon coupon);
}