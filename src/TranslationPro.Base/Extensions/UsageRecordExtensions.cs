using TranslationPro.Base.Entities;

namespace TranslationPro.Base.Extensions;

public static class UsageRecordExtensions
{
    public static void Sync(this UsageRecordSummary entity, Stripe.UsageRecordSummary summary)
    {
        entity.Id = summary.Id;
        entity.TotalUsage = summary.TotalUsage;
        entity.PeriodStart = summary.Period.Start;
        entity.PeriodEnd = summary.Period.End;
        entity.InvoiceId = summary.Invoice;
    }
}