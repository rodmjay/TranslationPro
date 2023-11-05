using System;
using System.Threading.Tasks;
using Stripe;
using TranslationPro.Base.Stripe.Entities;
using TranslationPro.Base.Stripe.Interfaces;
using TranslationPro.Shared.Common;

namespace TranslationPro.Base.Stripe.Services;

public class StripeDiscountService : StripeService<StripeDiscount>, IStripeDiscountService
{
    public StripeDiscountService(IServiceProvider serviceProvider) : base(serviceProvider)
    {
    }

    public async Task<Result> HandleCustomerDiscountCreated(Discount deserialize)
    {
        throw new NotImplementedException();
    }

    public async Task<Result> HandleCustomerDiscountDeleted(Discount deserialize)
    {
        throw new NotImplementedException();
    }

    public async Task<Result> HandleCustomerDiscountUpdated(Discount deserialize)
    {
        throw new NotImplementedException();
    }
}