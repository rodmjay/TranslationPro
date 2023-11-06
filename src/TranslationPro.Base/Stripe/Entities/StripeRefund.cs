using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Stripe;
using TranslationPro.Base.Common.Data.Bases;
using TranslationPro.Base.Stripe.Interfaces;

namespace TranslationPro.Base.Stripe.Entities;

public class StripeRefund : BaseEntity<StripeRefund>, IHasCharge, IHasId
{
    public override void Configure(EntityTypeBuilder<StripeRefund> builder)
    {
        builder.ToTable(nameof(Refund), "Stripe");
        builder.HasKey(x => x.Id);
        builder.HasOne(x => x.Charge)
            .WithMany(x => x.Refunds)
            .HasForeignKey(x => x.ChargeId);
    }

    public string ChargeId { get; set; }
    public StripeCharge Charge { get; set; }
    public string Id { get; set; }
}