using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TranslationPro.Base.Common.Data.Bases;

namespace TranslationPro.Base.Entities;

public class Product : BaseEntity<Product>
{
    public string Id { get; set; }
    public ICollection<Plan> Plans { get; set; }
    public string Description { get; set; }
    public string Name { get; set; }
    public string Type { get; set; }

    public override void Configure(EntityTypeBuilder<Product> builder)
    {
        builder.ToTable(nameof(Product), "Stripe");
        builder.HasKey(p => p.Id);
    }
}