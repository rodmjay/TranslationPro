using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TranslationPro.Base.Common.Data.Bases;
using TranslationPro.Base.Stripe.Interfaces;

namespace TranslationPro.Base.Stripe.Entities;

public class StripeInvoiceLineItemDiscount : BaseEntity<StripeInvoiceLineItemDiscount>, IHasDiscount
{
    public override void Configure(EntityTypeBuilder<StripeInvoiceLineItemDiscount> builder)
    {
        builder.ToTable("InvoiceItemDiscount", "Stripe");

        builder.HasKey(x => new {x.InvoiceLineItemId, x.DiscountId});

        builder.HasOne(x => x.InvoiceLineItem)
            .WithMany(x => x.Discounts)
            .HasForeignKey(x => x.InvoiceLineItemId);

        builder.HasOne(x => x.Discount)
            .WithOne(x => x.InvoiceLineItemDiscount)
            .HasForeignKey<StripeInvoiceLineItemDiscount>(x => x.DiscountId);
    }

    public string DiscountId { get; set; }
    public StripeDiscount Discount { get; set; }
    public string InvoiceLineItemId { get; set; }
    public StripeInvoiceLineItem InvoiceLineItem { get; set; }
}