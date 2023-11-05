using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Stripe;
using TranslationPro.Base.Common.Data.Bases;
using TranslationPro.Base.Stripe.Interfaces;

namespace TranslationPro.Base.Stripe.Entities;

public class StripePromotionCode : BaseEntity<StripePromotionCode>, IHasId, IHasCoupon
{
    public override void Configure(EntityTypeBuilder<StripePromotionCode> builder)
    {
        builder.HasKey(x => x.Id);
        builder.HasOne(x => x.Coupon)
            .WithMany(x => x.PromotionCodes)
            .HasForeignKey(x => x.CouponId);
    }

    public string Id { get; set; }
    public StripeCoupon Coupon { get; set; }
    public string CouponId { get; set; }
}