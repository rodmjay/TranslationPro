using System;
using System.Threading.Tasks;
using Stripe;
using TranslationPro.Base.Stripe.Entities;
using TranslationPro.Shared.Common;

namespace TranslationPro.Base.Stripe.Managers;

public class CouponManager : StripeManager<StripeCoupon>, ICouponManager
{
    protected CouponService CouponService;
    public CouponManager(IServiceProvider serviceProvider, CouponService couponService) : base(serviceProvider)
    {
        CouponService = couponService;
    }

    public async Task<Result> CreateCoupon(CouponCreateOptions options)
    {
        var coupon = await CouponService.CreateAsync(options);
        if (coupon != null)
        {
            return Result.Success(coupon.Id);
        }
        return Result.Failed();
    }

    public async Task<Result> UpdateCoupon(string couponId, CouponUpdateOptions options)
    {
        var coupon = await CouponService.UpdateAsync(couponId, options);
        if (coupon != null)
        {
            return Result.Success(coupon.Id);
        }
        return Result.Failed();
    }

    public async Task<Result> DeleteCoupon(string couponId, CouponDeleteOptions options)
    {
        var coupon = await CouponService.DeleteAsync(couponId, options);
        if (coupon != null)
        {
            return Result.Success(coupon.Id);
        }
        return Result.Failed();
    }

    public Task<Result> HandleCouponCreated(Coupon coupon)
    {
        throw new NotImplementedException();
    }

    public Task<Result> HandleCouponDeleted(Coupon coupon)
    {
        throw new NotImplementedException();
    }
}