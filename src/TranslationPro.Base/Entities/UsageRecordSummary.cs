#region Header Info

// Copyright 2023 Rod Johnson.  All rights reserved

#endregion

using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TranslationPro.Base.Common.Data.Bases;

namespace TranslationPro.Base.Entities;

public class UsageRecordSummary : BaseEntity<UsageRecordSummary>
{
    public string Id { get; set; }
    public string SubscriptionItemId { get; set; }
    public SubscriptionItem SubscriptionItem { get; set; }
    public long TotalUsage { get; set; }
    public string InvoiceId { get; set; }
    public Invoice Invoice { get; set; }
    public DateTime? PeriodEnd { get; set; }
    public DateTime? PeriodStart { get; set; }

    public override void Configure(EntityTypeBuilder<UsageRecordSummary> builder)
    {
        builder.ToTable(nameof(UsageRecordSummary), "Stripe");

        builder.HasKey(x => x.Id);
        builder.HasOne(x => x.SubscriptionItem).WithMany(x => x.UsageRecordSummaries).HasForeignKey(x => x.SubscriptionItemId);

        builder.HasOne(x => x.Invoice).WithMany(x => x.UsageRecordSummaries).HasForeignKey(x => x.InvoiceId)
            .IsRequired(false);
    }
}