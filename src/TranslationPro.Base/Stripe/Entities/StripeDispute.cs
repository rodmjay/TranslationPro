﻿using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Stripe;
using TranslationPro.Base.Common.Data.Bases;

namespace TranslationPro.Base.Stripe.Entities
{
    public class StripeDispute : BaseEntity<StripeDispute>, IHasId
    {
        public override void Configure(EntityTypeBuilder<StripeDispute> builder)
        {
            builder.ToTable(nameof(Dispute), "Stripe");
            builder.HasKey(x => x.Id);
        }

        public string Id { get; set; }
    }
}
