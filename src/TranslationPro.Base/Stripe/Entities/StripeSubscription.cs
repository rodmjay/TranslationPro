using System.Collections.Generic;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Stripe;
using TranslationPro.Base.Common.Data.Bases;
using TranslationPro.Base.Stripe.Interfaces;

namespace TranslationPro.Base.Stripe.Entities;

public class StripeSubscription : BaseEntity<StripeSubscription>, IHasId, IHasCustomer
{
    public ICollection<StripeSubscriptionItem> Items { get; set; }
    public override void Configure(EntityTypeBuilder<StripeSubscription> builder)
    {
        builder.HasKey(x => x.Id);

        builder.HasOne(x => x.Customer)
            .WithMany(x => x.Subscriptions)
            .HasForeignKey(x => x.CustomerId);
    }

    public string Id { get; set; }
    public StripeCustomer Customer { get; set; }
    public string CustomerId { get; set; }
}