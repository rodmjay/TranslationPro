using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Stripe;
using System;
using System.Collections.Generic;
using TranslationPro.Base.Common.Data.Bases;
using TranslationPro.Base.Stripe.Interfaces;

namespace TranslationPro.Base.Stripe.Entities;

public class StripeSubscriptionItem : BaseEntity<StripeSubscriptionItem>, IHasId, IHasSubscription, IHasPrice, ILiveMode
{
    public override void Configure(EntityTypeBuilder<StripeSubscriptionItem> builder)
    {
        builder.ToTable(nameof(SubscriptionItem), "Stripe");
        builder.HasKey(x => x.Id);

        builder.HasOne(x => x.Subscription)
            .WithMany(x => x.Items)
            .HasForeignKey(x => x.SubscriptionId);

        builder.HasOne(x => x.Price)
            .WithMany(x => x.SubscriptionItems)
            .HasForeignKey(x => x.PriceId);
    }

    public string Id { get; set; }
    public string SubscriptionId { get; set; }
    public StripeSubscription Subscription { get; set; }
    public ICollection<StripeInvoiceLineItem> InvoiceLineItems { get; set; }

    public string PriceId { get; set; }
    public StripePrice Price { get; set; }
    public DateTime Created { get; set; }
    public bool? Deleted { get; set; }
    public long Quantity { get; set; }

    public bool LiveMode { get; set; }
}