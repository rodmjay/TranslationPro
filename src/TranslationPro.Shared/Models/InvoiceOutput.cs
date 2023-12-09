using System;
using System.Collections.Generic;

namespace TranslationPro.Shared.Models;

public class InvoiceOutput
{
    public InvoiceOutput()
    {
        Items = new List<InvoiceItemOutput>();
        Lines = new List<InvoiceLineOutput>();
    }
    public string Id { get; set; }
    public List<InvoiceItemOutput> Items { get; set; }
    public List<InvoiceLineOutput> Lines { get; set; }

    public long AmountDue { get; set; }
    public long AmountPaid { get; set; }
    public bool Attempted { get; set; }
    public long AmountRemaining { get; set; }
    public long AttemptCount { get; set; }
    public string BillingReason { get; set; }
    public string CollectionMethod { get; set; }
    public string Description { get; set; }
    public DateTime? DueDate { get; set; }
    public DateTime? EffectiveAt { get; set; }
    public long? EndingBalance { get; set; }
    public DateTime Created { get; set; }
    public string HostedInvoiceUrl { get; set; }
    public string InvoicePdf { get; set; }
    public string Number { get; set; }
    public DateTime? NextPaymentAttempt { get; set; }
    public DateTime PeriodStart { get; set; }
    public DateTime PeriodEnd { get; set; }
    public bool Paid { get; set; }
    public string Status { get; set; }
    public long Subtotal { get; set; }
    public long? SubtotalExcludingTax { get; set; }
    public long? Tax { get; set; }
    public string ReceiptNumber { get; set; }
    public long Total { get; set; }
    public bool AutoAdvance { get; set; }
    public string Currency { get; set; }

}