using System;
using System.Threading.Tasks;
using Stripe;
using TranslationPro.Base.Stripe.Entities;
using TranslationPro.Base.Stripe.Interfaces;
using TranslationPro.Shared.Common;

namespace TranslationPro.Base.Stripe.Services;

public class StripePaymentIntentService : StripeService<StripePaymentIntent>, IStripePaymentIntentService
{
    public StripePaymentIntentService(IServiceProvider serviceProvider) : base(serviceProvider)
    {
    }

    public async Task<Result> HandlePaymentIntentCanceled(PaymentIntent input)
    {
        throw new NotImplementedException();
    }

    public async Task<Result> HandlePaymentIntentCreated(PaymentIntent input)
    {
        throw new NotImplementedException();
    }

    public async Task<Result> HandlePaymentIntentPartiallyFunded(PaymentIntent input)
    {
        throw new NotImplementedException();
    }

    public async Task<Result> HandlePaymentIntentPaymentFailed(PaymentIntent input)
    {
        throw new NotImplementedException();
    }

    public async Task<Result> HandlePaymentIntentProcessing(PaymentIntent input)
    {
        throw new NotImplementedException();
    }

    public async Task<Result> HandlePaymentIntentRequiresAction(PaymentIntent input)
    {
        throw new NotImplementedException();
    }

    public async Task<Result> HandlePaymentIntentSucceeded(PaymentIntent input)
    {
        throw new NotImplementedException();
    }

    public async Task<Result> HandlePaymentIntentCapturableUpdated(PaymentIntent deserialize)
    {
        throw new NotImplementedException();
    }

    public async Task<Result> HandlePaymentRequiresAction(PaymentIntent deserialize)
    {
        throw new NotImplementedException();
    }
}