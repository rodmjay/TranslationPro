using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Newtonsoft.Json;
using Stripe;
using Stripe.Infrastructure;
using TranslationPro.Base.Common.Data.Bases;
using TranslationPro.Base.Stripe.Interfaces;

namespace TranslationPro.Base.Stripe.Entities;

public class StripeInvoiceLineItem : BaseEntity<StripeInvoiceLineItem>, IHasInvoice, IHasId, ILiveMode, IHasPrice, IHasSubscription, IHasSubscriptionItem
{
    public override void Configure(EntityTypeBuilder<StripeInvoiceLineItem> builder)
    {
        builder.ToTable(nameof(InvoiceLineItem), "Stripe");

        builder.HasKey(x => x.Id);

        builder.HasOne(x => x.Invoice)
            .WithMany(x => x.Lines)
            .HasForeignKey(x => x.InvoiceId);

        builder.HasOne(x => x.Price)
            .WithMany(x => x.InvoiceLineItems)
            .HasForeignKey(x => x.PriceId);

        builder.HasOne(x => x.Subscription)
            .WithMany(x => x.InvoiceLineItems)
            .HasForeignKey(x => x.SubscriptionId);

        builder.HasOne(x => x.SubscriptionItem)
            .WithMany(x => x.InvoiceLineItems)
            .HasForeignKey(x => x.SubscriptionItemId);
    }
    public string PriceId { get; set; }
    public StripePrice Price { get; set; }
    public string SubscriptionId { get; set; }
    public StripeSubscription Subscription { get; set; }
    public string SubscriptionItemId { get; set; }
    public StripeSubscriptionItem SubscriptionItem { get; set; }
    public string InvoiceId { get; set; }
    public StripeInvoice Invoice { get; set; }
    public string Id { get; set; }
    public ICollection<StripeInvoiceLineItemDiscount> Discounts { get; set; }

    public long Amount { get; set; }
    
    public long? AmountExcludingTax { get; set; }
    
    public string Currency { get; set; }
    
    public string Description { get; set; }
    
    public bool Discountable { get; set; }
    
    public bool Proration { get; set; }
    
    public long? Quantity { get; set; }
    public string Type { get; set; }
    
    public decimal? UnitAmountExcludingTax { get; set; }
    public bool LiveMode { get; set; }
  
}