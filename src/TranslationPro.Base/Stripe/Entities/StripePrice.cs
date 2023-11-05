using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Stripe;
using TranslationPro.Base.Common.Data.Bases;
using TranslationPro.Base.Stripe.Interfaces;

namespace TranslationPro.Base.Stripe.Entities;

public class StripePrice : BaseEntity<StripePrice>, IActive, IHasId, IHasProduct
{
    public string Id { get; set; }

    public StripeProduct Product { get; set; }
    public string ProductId { get; set; }
    public bool Active { get; set; }

    public override void Configure(EntityTypeBuilder<StripePrice> builder)
    {
        builder.HasKey(x => x.Id);

        builder.HasOne(x => x.Product)
            .WithMany(x => x.Prices)
            .HasForeignKey(x => x.ProductId);
    }
}