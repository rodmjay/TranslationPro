using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Stripe;
using TranslationPro.Base.Common.Data.Bases;
using TranslationPro.Base.Stripe.Interfaces;

namespace TranslationPro.Base.Stripe.Entities;

public class StripeDiscount : BaseEntity<StripeDiscount>, IHasId, IHasCoupon
{
    public override void Configure(EntityTypeBuilder<StripeDiscount> builder)
    {
        builder.ToTable(nameof(Discount), "Stripe");
        builder.HasKey(x => x.Id);

        builder.HasOne(x => x.Coupon)
            .WithMany(x => x.Discounts)
            .HasForeignKey(x => x.CouponId);
    }
    
    public StripeInvoiceLineItemDiscount InvoiceLineItemDiscount { get; set; }
    public StripeInvoiceDiscount InvoiceDiscount { get; set; }
    public string Id { get; set; }
    public StripeCoupon Coupon { get; set; }
    public string CouponId { get; set; }

    public ICollection<StripeSubscription> Subscriptions { get; set; }
}