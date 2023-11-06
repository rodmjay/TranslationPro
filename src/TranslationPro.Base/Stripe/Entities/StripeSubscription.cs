using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Stripe;
using TranslationPro.Base.Common.Data.Bases;
using TranslationPro.Base.Stripe.Interfaces;

namespace TranslationPro.Base.Stripe.Entities;

public class StripeSubscription : BaseEntity<StripeSubscription>, IHasId, IHasCustomer, IHasSchedule, IHasPaymentMethod, IHasDiscount, ILiveMode
{
    public ICollection<StripeSubscriptionItem> Items { get; set; }
    public override void Configure(EntityTypeBuilder<StripeSubscription> builder)
    {
        builder.ToTable(nameof(Subscription), "Stripe");
        builder.HasKey(x => x.Id);

        builder.HasOne(x => x.Customer)
            .WithMany(x => x.Subscriptions)
            .HasForeignKey(x => x.CustomerId);

        builder.HasOne(x => x.Schedule)
            .WithMany(x => x.Subscriptions)
            .HasForeignKey(x => x.ScheduleId);

        builder.HasOne(x => x.PaymentMethod)
            .WithMany(x => x.Subscriptions)
            .HasForeignKey(x => x.PaymentMethodId);

        builder.HasOne(x => x.Discount)
            .WithMany(x => x.Subscriptions)
            .HasForeignKey(x => x.DiscountId);
    }

    public string Id { get; set; }
    public StripeCustomer Customer { get; set; }
    public string CustomerId { get; set; }

    public ICollection<StripeInvoice> Invoices { get; set; }
    public StripeSubscriptionSchedule Schedule { get; set; }
    public ICollection<StripeInvoiceLineItem> InvoiceLineItems { get; set; }
    public string ScheduleId { get; set; }
    

    public decimal? ApplicationFeePercent { get; set; }
    
    public DateTime BillingCycleAnchor { get; set; } 
    
    public DateTime? CancelAt { get; set; }
    
    public bool CancelAtPeriodEnd { get; set; }
    
    public DateTime? CanceledAt { get; set; }
    
    public string CollectionMethod { get; set; }
    
    public DateTime Created { get; set; } 
    
    public string Currency { get; set; }
    
    public DateTime CurrentPeriodEnd { get; set; }
    
    public DateTime CurrentPeriodStart { get; set; } 
    
    public long? DaysUntilDue { get; set; }
    
    public string Description { get; set; }
    
    
    public DateTime? EndedAt { get; set; }
    
    
    public DateTime? NextPendingInvoiceItemInvoice { get; set; }

    
    public DateTime StartDate { get; set; }
    
    public string Status { get; set; }
    
    public DateTime? TrialEnd { get; set; }
    
    public DateTime? TrialStart { get; set; }
    public StripePaymentMethod PaymentMethod { get; set; }
    public string PaymentMethodId { get; set; }
    public string DiscountId { get; set; }
    public StripeDiscount Discount { get; set; }
    public bool LiveMode { get; set; }
}