using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Stripe;
using TranslationPro.Base.Common.Data.Bases;

namespace TranslationPro.Base.Stripe.Entities;

public class StripePaymentLink : BaseEntity<StripePaymentLink>, IHasId
{
    public override void Configure(EntityTypeBuilder<StripePaymentLink> builder)
    {
        builder.HasKey(x => x.Id);
    }

    public string Id { get; set; }
}