using System;
using System.Threading.Tasks;
using Stripe;
using TranslationPro.Base.Stripe.Entities;
using TranslationPro.Shared.Common;

namespace TranslationPro.Base.Stripe.Managers;

public class PaymentIntentManager : StripeManager<StripePaymentIntent>, IPaymentIntentManager
{
    private readonly PaymentIntentService PaymentIntentService;

    public PaymentIntentManager(IServiceProvider serviceProvider, PaymentIntentService paymentIntentService) : base(serviceProvider)
    {
        PaymentIntentService = paymentIntentService;
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