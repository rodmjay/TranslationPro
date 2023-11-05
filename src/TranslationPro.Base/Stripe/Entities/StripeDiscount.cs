using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Stripe;
using TranslationPro.Base.Common.Data.Bases;

namespace TranslationPro.Base.Stripe.Entities;

public class StripeDiscount : BaseEntity<StripeDiscount>, IHasId
{
    public override void Configure(EntityTypeBuilder<StripeDiscount> builder)
    {
        builder.HasKey(x => x.Id);
    }

    public string Id { get; set; }
}