using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TranslationPro.Base.Common.Data.Bases;
using TranslationPro.Base.Stripe.Interfaces;

namespace TranslationPro.Base.Stripe.Entities;

public class StripeInvoiceDiscount : BaseEntity<StripeInvoiceDiscount>, IHasInvoice, IHasDiscount
{
    public override void Configure(EntityTypeBuilder<StripeInvoiceDiscount> builder)
    {
        builder.ToTable("InvoiceDiscount", "Stripe");

        builder.HasKey(x => new {x.InvoiceId, x.DiscountId});

        builder.HasOne(x => x.Invoice)
            .WithMany(x => x.Discounts)
            .HasForeignKey(x => x.InvoiceId);

        builder.HasOne(x => x.Discount)
            .WithOne(x => x.InvoiceDiscount)
            .HasForeignKey<StripeInvoiceDiscount>(x => x.DiscountId);
    }
    public string InvoiceId { get; set; }
    public StripeInvoice Invoice { get; set; }
    public string DiscountId { get; set; }
    public StripeDiscount Discount { get; set; }
}