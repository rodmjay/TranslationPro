using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TranslationPro.Base.Common.Data.Bases;

namespace TranslationPro.Base.Entities;

public class Plan : BaseEntity<Plan>
{
    public string Id { get; set; }
    public string ProductId { get; set; }
    public Product Product { get; set; }
    public bool Active { get; set; }
    public long? Amount { get; set; }
    public decimal? AmountDecimal { get; set; }
    public string Interval { get; set; }
    public long IntervalCount { get; set; }

    public override void Configure(EntityTypeBuilder<Plan> builder)
    {
        builder.ToTable(nameof(Plan), "Stripe");
        builder.HasKey(p => p.Id);

        builder.HasOne(x => x.Product).WithMany(x => x.Plans).HasForeignKey(x => x.ProductId);
    }
}