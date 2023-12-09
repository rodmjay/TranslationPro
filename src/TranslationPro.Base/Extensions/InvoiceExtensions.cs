using TranslationPro.Base.Entities;

namespace TranslationPro.Base.Extensions;

public static class InvoiceExtensions
{
    public static void Sync(this InvoiceLine entity, Stripe.InvoiceLineItem line, string invoiceId)
    {
        entity.Id = line.Id;
        entity.InvoiceId = invoiceId;
        entity.Amount = line.Amount;
        entity.AmountExcludingTax = line.AmountExcludingTax;
        entity.Currency = line.Currency;
        entity.Description = line.Description;
        entity.PeriodEnd = line.Period.End;
        entity.PeriodStart = line.Period.Start;
        entity.Type = line.Type;
        entity.Quantity = line.Quantity;
        entity.UnitAmountExcludingTax = line.UnitAmountExcludingTax;

    }

    public static void Sync(this Invoice entity, Stripe.Invoice invoice, int userId)
    {
        entity.Id = invoice.Id;
        entity.UserId = userId;
        entity.SubscriptionId = invoice.SubscriptionId;
        entity.AmountDue = invoice.AmountDue;
        entity.AmountPaid = invoice.AmountPaid;
        entity.Attempted = invoice.Attempted;
        entity.AmountRemaining = invoice.AmountRemaining;
        entity.AttemptCount = invoice.AttemptCount;
        entity.BillingReason = invoice.BillingReason;
        entity.CollectionMethod = invoice.CollectionMethod;
        entity.Description = invoice.Description;
        entity.DueDate = invoice.DueDate;
        entity.EffectiveAt = invoice.EffectiveAt;
        entity.EndingBalance = invoice.EndingBalance;
        entity.ChargeId = invoice.ChargeId;
        entity.Created = invoice.Created;
        entity.HostedInvoiceUrl = invoice.HostedInvoiceUrl;
        entity.InvoicePdf = invoice.InvoicePdf;
        entity.Number = invoice.Number;
        entity.NextPaymentAttempt = invoice.NextPaymentAttempt;
        entity.PeriodStart = invoice.PeriodStart;
        entity.PeriodEnd = invoice.PeriodEnd;
        entity.Paid = invoice.Paid;
        entity.Status = invoice.Status;
        entity.Subtotal = invoice.Subtotal;
        entity.SubtotalExcludingTax = invoice.SubtotalExcludingTax;
        entity.Tax = invoice.Tax;
        entity.ReceiptNumber = invoice.ReceiptNumber;
        entity.Total = invoice.Total;
        entity.AutoAdvance = invoice.AutoAdvance;
        entity.Currency = invoice.Currency;
    }
}