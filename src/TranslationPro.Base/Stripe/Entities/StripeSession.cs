using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Stripe;
using TranslationPro.Base.Common.Data.Bases;

namespace TranslationPro.Base.Stripe.Entities;

public class StripeSession : BaseEntity<StripeSession>, IHasId
{
    public override void Configure(EntityTypeBuilder<StripeSession> builder)
    {
        builder.HasKey(x => x.Id);
    }

    public string Id { get; set; }
}