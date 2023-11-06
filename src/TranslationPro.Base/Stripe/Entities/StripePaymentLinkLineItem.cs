#region Header Info

// Copyright 2023 Rod Johnson.  All rights reserved

#endregion

using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Stripe;
using TranslationPro.Base.Common.Data.Bases;
using TranslationPro.Base.Stripe.Interfaces;

namespace TranslationPro.Base.Stripe.Entities;

public class StripePaymentLinkLineItem : BaseEntity<StripePaymentLinkLineItem>, IHasId, IHasPrice, IHasPaymentLink
{
    public override void Configure(EntityTypeBuilder<StripePaymentLinkLineItem> builder)
    {
        builder.ToTable(nameof(LineItem), "Stripe");
        builder.HasKey(x => x.Id);

        builder.HasOne(x => x.Price)
            .WithMany(x => x.PaymentLinkLineItems)
            .HasForeignKey(x => x.PriceId);

        builder.HasOne(x => x.PaymentLink)
            .WithMany(x => x.LineItems)
            .HasForeignKey(x => x.PaymentLinkId);
    }

    public ICollection<StripePaymentLinkLineItem> LineItems { get; set; }

    public string Id { get; set; }
    
    public long AmountDiscount { get; set; }
    
    public long AmountSubtotal { get; set; }
    
    public long AmountTax { get; set; }
    
    public long AmountTotal { get; set; }
    
    public string Currency { get; set; }
    
    public bool? Deleted { get; set; }
    
    public string Description { get; set; }
    
    public long? Quantity { get; set; }

    public string PriceId { get; set; }
    public StripePrice Price { get; set; }
    public StripePaymentLink PaymentLink { get; set; }
    public string PaymentLinkId { get; set; }
}