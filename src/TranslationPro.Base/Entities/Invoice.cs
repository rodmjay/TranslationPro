#region Header Info

// Copyright 2023 Rod Johnson.  All rights reserved

#endregion

using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Stripe;
using TranslationPro.Base.Common.Data.Bases;

namespace TranslationPro.Base.Entities;

public class Invoice : BaseEntity<Invoice>
{
    public int UserId { get; set; }
    public string Id { get; set; }
    public ICollection<InvoiceItem> Items { get; set; }
    public ICollection<InvoiceLine> Lines { get; set; }
    public string SubscriptionId { get; set; }
    public Subscription Subscription { get; set; }
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
    public string ChargeId { get; set; }
    public Charge Charge { get; set; }
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

    public override void Configure(EntityTypeBuilder<Invoice> builder)
    {
        builder.ToTable(nameof(Invoice), "Stripe");
        builder.HasKey(x => x.Id);

        builder.HasOne(x => x.Subscription).WithMany(x => x.Invoices).HasForeignKey(x => x.UserId);

        builder.HasOne(x => x.Charge).WithMany(x => x.Invoices).HasForeignKey(x => x.ChargeId);
    }
}