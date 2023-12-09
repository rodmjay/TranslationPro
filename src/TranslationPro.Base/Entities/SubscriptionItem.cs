using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TranslationPro.Base.Common.Data.Bases;

namespace TranslationPro.Base.Entities;

public class SubscriptionItem : BaseEntity<SubscriptionItem>
{
    public SubscriptionItem()
    {
        UsageRecords = new List<UsageRecord>();
    }

    public int UserId { get; set; }
    public string SubscriptionId { get; set; }
    public Subscription Subscription { get; set; }
    public string StripeItemId { get; set; }
    public string PlanId { get; set; }
    public Plan Plan { get; set; }
    public string ProductId { get; set; }
    public Product Product { get; set; }

    public ICollection<UsageRecord> UsageRecords { get; set; }
    public ICollection<UsageRecordSummary> UsageRecordSummaries { get; set; }

    public override void Configure(EntityTypeBuilder<SubscriptionItem> builder)
    {
        builder.ToTable(nameof(SubscriptionItem), "Stripe");
        builder.HasKey(x => x.StripeItemId);

        builder.HasOne(x => x.Subscription).WithMany(x => x.Items).HasForeignKey(x => x.UserId);

        builder.HasOne(x=>x.Product)
            .WithMany(x=>x.SubscriptionItems)
            .HasForeignKey(x => x.ProductId);

        builder.HasOne(x => x.Plan)
            .WithMany(x => x.SubscriptionItems)
            .HasForeignKey(x => x.PlanId);
    }
}