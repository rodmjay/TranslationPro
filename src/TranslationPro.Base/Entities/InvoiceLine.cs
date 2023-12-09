#region Header Info

// Copyright 2023 Rod Johnson.  All rights reserved

#endregion

using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TranslationPro.Base.Common.Data.Bases;

namespace TranslationPro.Base.Entities;

public class InvoiceLine : BaseEntity<InvoiceLine>
{
    public string Id { get; set; }
    public string InvoiceId { get; set; }
    public Invoice Invoice { get; set; }
    public long Amount { get; set; }
    public long? AmountExcludingTax { get; set; }
    public string Currency { get; set; }
    public string Description { get; set; }
    public DateTime PeriodEnd { get; set; }
    public DateTime PeriodStart { get; set; }
    public string Type { get; set; }
    public long? Quantity { get; set; }
    public decimal? UnitAmountExcludingTax { get; set; }

    public override void Configure(EntityTypeBuilder<InvoiceLine> builder)
    {
        builder.ToTable(nameof(InvoiceLine), "Stripe");
        builder.HasKey(x => x.Id);

        builder.HasOne(x => x.Invoice).WithMany(x => x.Lines).HasForeignKey(x => x.InvoiceId);

    }
}