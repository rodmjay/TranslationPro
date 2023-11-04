using TranslationPro.Base.Stripe.Entities;

namespace TranslationPro.Base.Stripe.Interfaces;

public interface IHasInvoice
{
    string InvoiceId { get; set;}
    StripeInvoice Invoice { get; set; }
}