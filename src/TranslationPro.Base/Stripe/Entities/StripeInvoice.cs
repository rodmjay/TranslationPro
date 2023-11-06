using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Stripe;
using TranslationPro.Base.Common.Data.Bases;
using TranslationPro.Base.Stripe.Interfaces;

namespace TranslationPro.Base.Stripe.Entities;

public class StripeInvoice : BaseEntity<StripeInvoice>, 
    IHasId, ICreatedTimestamp, ILiveMode,
    ICurrency, IHasCustomer, IHasSubscription, IHasCharge
{
    public ICollection<StripeCharge> Charges { get; set; }

    public override void Configure(EntityTypeBuilder<StripeInvoice> builder)
    {
        builder.ToTable(nameof(Invoice), "Stripe");
        builder.HasKey(t => t.Id);

        builder.HasOne(x => x.Customer)
            .WithMany(x => x.Invoices)
            .HasForeignKey(x => x.CustomerId);

        builder.HasOne(x => x.Subscription)
            .WithMany(x => x.Invoices)
            .HasForeignKey(x => x.SubscriptionId);

        builder.OwnsOne(x => x.CustomerAddress);


    }
    public ICollection<StripeInvoiceLineItem> Lines { get; set; }
    public ICollection<StripePaymentIntent> PaymentIntents { get; set; }
    public string Id { get; set; }
    public int Created { get; set; }
    public bool Captured { get; set; }
    public int AmountCaptured { get; set; }
    public bool Refunded { get; set; }
    public string Currency { get; set; }
    public StripeCustomer Customer { get; set; }
    public string CustomerId { get; set; }

    
    public string AccountCountry { get; set; }
    
    public string AccountName { get; set; }
    
    public long AmountDue { get; set; }
    
    public long AmountPaid { get; set; }
    
    public long AmountRemaining { get; set; }
    
    public long AmountShipping { get; set; }
    
    public long? ApplicationFeeAmount { get; set; }
    
    public long AttemptCount { get; set; }
    
    public bool Attempted { get; set; }
    
    public bool AutoAdvance { get; set; }
    
    public string BillingReason { get; set; }
    
    
    public string CollectionMethod { get; set; }
    
    public StripeAddress CustomerAddress { get; set; }
    
    public string CustomerEmail { get; set; }
    
    public string CustomerName { get; set; }
    
    public string CustomerPhone { get; set; }
    
    public string CustomerTaxExempt { get; set; }

    public bool? Deleted { get; set; }
    
    public string Description { get; set; }
    
    
    public DateTime? DueDate { get; set; }
    
    public DateTime? EffectiveAt { get; set; }
    
    public long? EndingBalance { get; set; }
    
    public string Footer { get; set; }
    
    public string HostedInvoiceUrl { get; set; }
    
    public string InvoicePdf { get; set; }
    
    public DateTime? NextPaymentAttempt { get; set; }
    
    public string Number { get; set; }
    
    public bool Paid { get; set; }
    
    public bool PaidOutOfBand { get; set; }

    public DateTime PeriodEnd { get; set; } 
    
    public DateTime PeriodStart { get; set; }
    
    public long PostPaymentCreditNotesAmount { get; set; }
    
    public long PrePaymentCreditNotesAmount { get; set; }
    
    public string ReceiptNumber { get; set; }
    
    public long StartingBalance { get; set; }
    
    public string StatementDescriptor { get; set; }
    
    public string Status { get; set; }
    
    // todo: public InvoiceStatusTransitions StatusTransitions { get; set; }
    
    // todo: public InvoiceSubscriptionDetails SubscriptionDetails { get; set; }
    
    public long Subtotal { get; set; }
    
    public long? SubtotalExcludingTax { get; set; }
    
    public long? Tax { get; set; }
    
    public long Total { get; set; }
    
    
    public long? TotalExcludingTax { get; set; }
    
    public DateTime? WebhooksDeliveredAt { get; set; }
    public bool LiveMode { get; set; }
    public string SubscriptionId { get; set; }
    public StripeSubscription Subscription { get; set; }
    public string PaymentIntentId { get; set; }
    public StripePaymentIntentInvoice PaymentIntent { get; set; }
    public string ChargeId { get; set; }
    public StripeCharge Charge { get; set; }
    
    public ICollection<StripeInvoiceDiscount> Discounts { get; set; }
}