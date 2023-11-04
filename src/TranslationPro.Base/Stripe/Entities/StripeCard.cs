#region Header Info

// Copyright 2023 Rod Johnson.  All rights reserved

#endregion

using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Stripe;
using TranslationPro.Base.Common.Data.Bases;
using TranslationPro.Base.Stripe.Interfaces;

namespace TranslationPro.Base.Stripe.Entities;

public class StripeCard : BaseEntity<StripeCard>, IHasId, IHasCustomer
{
    public override void Configure(EntityTypeBuilder<StripeCard> builder)
    {
        builder.HasKey(x => x.Id);

        builder.HasOne(x => x.Customer)
            .WithMany(x => x.Cards)
            .HasForeignKey(x => x.CustomerId);
    }

    public string Id { get; set; }
    public StripeCustomer Customer { get; set; }
    public string CustomerId { get; set; }
    public string Last4 { get; set; }
    public string Name { get; set; }
    public string Brand { get; set; }
    public string CvcCheck { get; set; }
    public int ExpMonth { get; set; }
    public int ExpYear { get; set; }

}