using System;
using System.Threading.Tasks;
using Stripe;
using TranslationPro.Base.Stripe.Entities;
using TranslationPro.Base.Stripe.Interfaces;
using TranslationPro.Shared.Common;

namespace TranslationPro.Base.Stripe.Services;

public class StripeCouponService : StripeService<StripeCoupon>, IStripeCouponService
{
    public StripeCouponService(IServiceProvider serviceProvider) : base(serviceProvider)
    {
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