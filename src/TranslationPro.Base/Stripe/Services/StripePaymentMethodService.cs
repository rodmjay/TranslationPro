using System;
using System.Threading.Tasks;
using Stripe;
using TranslationPro.Base.Stripe.Entities;
using TranslationPro.Base.Stripe.Interfaces;
using TranslationPro.Shared.Common;

namespace TranslationPro.Base.Stripe.Services;

public class StripePaymentMethodService : StripeService<StripePaymentMethod>, IStripePaymentMethodService
{
    public StripePaymentMethodService(IServiceProvider serviceProvider) : base(serviceProvider)
    {
    }

    public async Task<Result> HandlePaymentMethodAttached(PaymentMethod input)
    {
        throw new NotImplementedException();
    }

    public async Task<Result> HandlePaymentMethodAutomaticallyUpdated(PaymentMethod input)
    {
        throw new NotImplementedException();
    }

    public async Task<Result> HandlePaymentMethodDetached(PaymentMethod input)
    {
        throw new NotImplementedException();
    }

    public async Task<Result> HandlePaymentMethodUpdated(PaymentMethod input)
    {
        throw new NotImplementedException();
    }
}