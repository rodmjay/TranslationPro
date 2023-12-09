using TranslationPro.Base.Entities;

namespace TranslationPro.Base.Extensions;

public static class InvoiceItemExtensions
{
    public static void Sync(this InvoiceItem entity, Stripe.InvoiceItem item, string invoiceId)
    {
        entity.Id = item.Id;
        entity.InvoiceId = item.InvoiceId;
    }
}