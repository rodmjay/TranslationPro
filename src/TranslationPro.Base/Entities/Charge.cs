#region Header Info

// Copyright 2023 Rod Johnson.  All rights reserved

#endregion

using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TranslationPro.Base.Common.Data.Bases;

namespace TranslationPro.Base.Entities;

public class Charge : BaseEntity<Charge>
{
    public string Id { get; set; }
    public ICollection<Invoice> Invoices { get; set; }
    public override void Configure(EntityTypeBuilder<Charge> builder)
    {
        builder.ToTable(nameof(Charge), "Stripe");
        builder.HasKey(e => e.Id);
    }
}