using System.Collections.Generic;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Stripe;
using TranslationPro.Base.Common.Data.Bases;

namespace TranslationPro.Base.Stripe.Entities;

public class StripeCoupon : BaseEntity<StripeCoupon>, IHasId
{
    public override void Configure(EntityTypeBuilder<StripeCoupon> builder)
    {
        builder.HasKey(x => x.Id);
    }

    public ICollection<StripePromotionCode> PromotionCodes { get; set; }

    public string Id { get; set; }
}