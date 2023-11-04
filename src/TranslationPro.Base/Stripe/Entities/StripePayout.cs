#region Header Info

// Copyright 2023 Rod Johnson.  All rights reserved

#endregion

using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Stripe;
using TranslationPro.Base.Common.Data.Bases;

namespace TranslationPro.Base.Stripe.Entities;

public class StripePayout : BaseEntity<StripePayout>, IHasId
{
    public override void Configure(EntityTypeBuilder<StripePayout> builder)
    {
        builder.HasKey(x => x.Id);
    }

    public string Id { get; set; }
}