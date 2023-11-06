using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Stripe;
using TranslationPro.Base.Common.Data.Bases;
using TranslationPro.Base.Stripe.Interfaces;

namespace TranslationPro.Base.Stripe.Entities;

public class StripePrice : BaseEntity<StripePrice>, IActive, IHasId, IHasProduct, ILiveMode
{
    public string Id { get; set; }

    public StripeProduct Product { get; set; }
    public string ProductId { get; set; }
    public bool Active { get; set; }

    public StripePriceRecurring Recurring { get; set; }

    public ICollection<StripeSubscriptionItem> SubscriptionItems { get; set; }
    public ICollection<StripeInvoiceLineItem> InvoiceLineItems { get; set; }
    public ICollection<StripePaymentLinkLineItem> PaymentLinkLineItems { get; set; }
    public override void Configure(EntityTypeBuilder<StripePrice> builder)
    {
        builder.ToTable(nameof(Price), "Stripe");

        builder.HasKey(x => x.Id);

        builder.HasOne(x => x.Product)
            .WithMany(x => x.Prices)
            .HasForeignKey(x => x.ProductId);

        builder.OwnsOne(x => x.Recurring);
        
    }

    public string BillingScheme { get; set; }
    
    public DateTime Created { get; set; }
    
    public string Currency { get; set; }
    
    // todo: public PriceCustomUnitAmount CustomUnitAmount { get; set; }
    
    public bool? Deleted { get; set; }
    
    
    public string LookupKey { get; set; }
    
    public string Nickname { get; set; }
    
    public string TaxBehavior { get; set; }
    
    public string TiersMode { get; set; }
    
    public string Type { get; set; }
    
    public long? UnitAmount { get; set; }
    
    public decimal? UnitAmountDecimal { get; set; }

    public bool LiveMode { get; set; }
}