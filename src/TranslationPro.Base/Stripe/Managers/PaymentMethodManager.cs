using System;
using System.Threading.Tasks;
using Stripe;
using TranslationPro.Base.Stripe.Entities;
using TranslationPro.Shared.Common;

namespace TranslationPro.Base.Stripe.Managers;

public class PaymentMethodManager : StripeManager<StripePaymentMethod>, IPaymentMethodManager
{
    protected readonly PaymentMethodService PaymentMethodService;

    public PaymentMethodManager(IServiceProvider serviceProvider, PaymentMethodService paymentMethodService) : base(serviceProvider)
    {
        PaymentMethodService = paymentMethodService;
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