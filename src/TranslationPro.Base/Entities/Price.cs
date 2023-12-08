using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TranslationPro.Base.Common.Data.Bases;

namespace TranslationPro.Base.Entities;

public class Price : BaseEntity<Price>
{
    public Price()
    {
        Tiers = new List<PriceTier>();
    }
    public string Id { get; set; }
    public string ProductId { get; set; }
    public bool Active { get; set; }

    public ICollection<PriceTier> Tiers { get; set; }

    public override void Configure(EntityTypeBuilder<Price> builder)
    {
        builder.ToTable(nameof(Price), "Stripe");

        builder.HasKey(x => x.Id);
        builder.OwnsMany(x => x.Tiers);
    }
}