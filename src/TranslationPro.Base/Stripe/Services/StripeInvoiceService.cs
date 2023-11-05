using System;
using System.Threading.Tasks;
using Stripe;
using TranslationPro.Base.Stripe.Entities;
using TranslationPro.Base.Stripe.Interfaces;
using TranslationPro.Shared.Common;

namespace TranslationPro.Base.Stripe.Services;

public class StripeInvoiceService : StripeService<StripeInvoice>, IStripeInvoiceService
{
    public StripeInvoiceService(IServiceProvider serviceProvider) : base(serviceProvider)
    {
    }

    public async Task<Result> HandleInvoiceDeleted(Invoice input)
    {
        throw new NotImplementedException();
    }

    public Task<Result> HandleInvoiceCreated(Invoice input)
    {
        throw new NotImplementedException();
    }

    public async Task<Result> HandleInvoiceFinalizationFailed(Invoice input)
    {
        throw new NotImplementedException();
    }

    public async Task<Result> HandleInvoiceFinalized(Invoice input)
    {
        throw new NotImplementedException();
    }

    public async Task<Result> HandleInvoiceMarkedUncollectible(Invoice input)
    {
        throw new NotImplementedException();
    }

    public async Task<Result> HandleInvoicePaid(Invoice input)
    {
        throw new NotImplementedException();
    }

    public async Task<Result> HandleInvoicePaymentActionRequired(Invoice input)
    {
        throw new NotImplementedException();
    }

    public async Task<Result> HandleInvoicePaymentFailed(Invoice input)
    {
        throw new NotImplementedException();
    }

    public async Task<Result> HandleInvoicePaymentSucceeded(Invoice input)
    {
        throw new NotImplementedException();
    }

    public async Task<Result> HandleInvoiceSent(Invoice input)
    {
        throw new NotImplementedException();
    }

    public async Task<Result> HandleInvoiceUpcoming(Invoice input)
    {
        throw new NotImplementedException();
    }

    public async Task<Result> HandleInvoiceUpdated(Invoice input)
    {
        throw new NotImplementedException();
    }

    public async Task<Result> HandleInvoiceVoided(Invoice input)
    {
        throw new NotImplementedException();
    }

    public async Task<Result> HandleInvoiceItemCreated(InvoiceItem input)
    {
        throw new NotImplementedException();
    }

    public async Task<Result> HandleInvoiceItemDeleted(InvoiceItem input)
    {
        throw new NotImplementedException();
    }
}