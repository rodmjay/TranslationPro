using System;
using System.Threading.Tasks;
using Stripe;
using TranslationPro.Base.Stripe.Entities;
using TranslationPro.Base.Stripe.Interfaces;
using TranslationPro.Shared.Common;

namespace TranslationPro.Base.Stripe.Services;

public class StripePriceService : StripeService<StripePrice>, IStripePriceService
{
    public StripePriceService(IServiceProvider serviceProvider) : base(serviceProvider)
    {
    }

    public async Task<Result> CreatePrice(PriceCreateOptions options)
    {
        throw new NotImplementedException();
    }

    public async Task<Result> UpdatePrice(PriceUpdateOptions options)
    {
        throw new NotImplementedException();
    }

    public async Task<Result> HandlePriceCreated(Price input)
    {
        throw new NotImplementedException();
    }

    public async Task<Result> HandlePriceDeleted(Price input)
    {
        throw new NotImplementedException();
    }

    public async Task<Result> HandlePriceUpdated(Price input)
    {
        throw new NotImplementedException();
    }
}