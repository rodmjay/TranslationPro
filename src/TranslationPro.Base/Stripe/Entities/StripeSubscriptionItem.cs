using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Stripe;
using TranslationPro.Base.Common.Data.Bases;
using TranslationPro.Base.Stripe.Interfaces;

namespace TranslationPro.Base.Stripe.Entities;

public class StripeSubscriptionItem : BaseEntity<StripeSubscriptionItem>, IHasId, IHasSubscription
{
    public override void Configure(EntityTypeBuilder<StripeSubscriptionItem> builder)
    {
        builder.HasKey(x => x.Id);

        builder.HasOne(x => x.Subscription)
            .WithMany(x => x.Items)
            .HasForeignKey(x => x.SubscriptionId);
    }

    public string Id { get; set; }
    public string SubscriptionId { get; set; }
    public StripeSubscription Subscription { get; set; }
    public int Price { get; set; }
}