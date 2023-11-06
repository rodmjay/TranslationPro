#region Header Info

// Copyright 2023 Rod Johnson.  All rights reserved

#endregion

using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TranslationPro.Base.Common.Data.Bases;
using TranslationPro.Base.Stripe.Interfaces;

namespace TranslationPro.Base.Stripe.Entities;

public class StripeCouponProduct : BaseEntity<StripeCouponProduct>, IHasProduct, IHasCoupon
{
    public override void Configure(EntityTypeBuilder<StripeCouponProduct> builder)
    {
        builder.ToTable("CouponProduct", "Stripe");
        builder.HasKey(x => new {x.ProductId, x.CouponId});

        builder.HasOne(x => x.Product)
            .WithMany(x => x.Coupons)
            .HasForeignKey(x => x.ProductId);

        builder.HasOne(x => x.Coupon)
            .WithMany(x => x.Products)
            .HasForeignKey(x => x.CouponId);
    }

    public StripeProduct Product { get; set; }
    public string ProductId { get; set; }
    public StripeCoupon Coupon { get; set; }
    public string CouponId { get; set; }
}