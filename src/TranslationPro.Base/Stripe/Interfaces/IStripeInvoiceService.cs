using System.Threading.Tasks;
using Stripe;
using TranslationPro.Base.Common.Services.Interfaces;
using TranslationPro.Base.Stripe.Entities;
using TranslationPro.Shared.Common;

namespace TranslationPro.Base.Stripe.Interfaces;

public interface IStripeInvoiceService : IService<StripeInvoice>
{
    Task<Result> HandleInvoiceDeleted(Invoice input);
    Task<Result> HandleInvoiceCreated(Invoice input);
    Task<Result> HandleInvoiceFinalizationFailed(Invoice input);
    Task<Result> HandleInvoiceFinalized(Invoice input);
    Task<Result> HandleInvoiceMarkedUncollectible(Invoice input);
    Task<Result> HandleInvoicePaid(Invoice input);
    Task<Result> HandleInvoicePaymentActionRequired(Invoice input);
    Task<Result> HandleInvoicePaymentFailed(Invoice input);
    Task<Result> HandleInvoicePaymentSucceeded(Invoice input);
    Task<Result> HandleInvoiceSent(Invoice input);
    Task<Result> HandleInvoiceUpcoming(Invoice input);
    Task<Result> HandleInvoiceUpdated(Invoice input);
    Task<Result> HandleInvoiceVoided(Invoice input);
    Task<Result> HandleInvoiceItemCreated(InvoiceItem input);
    Task<Result> HandleInvoiceItemDeleted(InvoiceItem input);

}