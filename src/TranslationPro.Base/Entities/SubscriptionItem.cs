using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TranslationPro.Base.Common.Data.Bases;

namespace TranslationPro.Base.Entities;

public class SubscriptionItem : BaseEntity<SubscriptionItem>
{
    public int UserId { get; set; }
    public string SubscriptionId { get; set; }
    public Subscription Subscription { get; set; }
    public string StripeItemId { get; set; }
    public string PlanId { get; set; }
    public string ProductId { get; set; }

    public override void Configure(EntityTypeBuilder<SubscriptionItem> builder)
    {
        builder.ToTable(nameof(SubscriptionItem), "Stripe");
        builder.HasKey(x => x.StripeItemId);

        builder.HasOne(x => x.Subscription).WithMany(x => x.Items).HasForeignKey(x => x.UserId);
    }
}