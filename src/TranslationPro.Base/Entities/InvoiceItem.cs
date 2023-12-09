#region Header Info

// Copyright 2023 Rod Johnson.  All rights reserved

#endregion

using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TranslationPro.Base.Common.Data.Bases;

namespace TranslationPro.Base.Entities;

public class InvoiceItem : BaseEntity<InvoiceItem>
{
    public string Id { get; set; }
    public string InvoiceId { get; set; }
    public Invoice Invoice { get; set; }
    public ICollection<UsageRecordSummary> UsageRecords { get; set; }

    public override void Configure(EntityTypeBuilder<InvoiceItem> builder)
    {
        builder.ToTable(nameof(InvoiceItem), "Stripe");
        builder.HasKey(x => x.Id);

        builder.HasOne(x => x.Invoice).WithMany(x => x.Items).HasForeignKey(x => x.InvoiceId);
    }
}