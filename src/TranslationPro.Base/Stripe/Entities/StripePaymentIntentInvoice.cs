using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TranslationPro.Base.Common.Data.Bases;
using TranslationPro.Base.Stripe.Interfaces;

namespace TranslationPro.Base.Stripe.Entities;

public class StripePaymentIntentInvoice : BaseEntity<StripePaymentIntentInvoice>, IHasPaymentIntent, IHasInvoice
{
    public override void Configure(EntityTypeBuilder<StripePaymentIntentInvoice> builder)
    {
        builder.ToTable("InvoicePaymentIntent", "Stripe");

        builder.HasKey(x => new {x.InvoiceId, x.PaymentIntentId});
        builder.HasOne(x => x.PaymentIntent)
            .WithOne(x => x.Invoice)
            .HasForeignKey<StripePaymentIntentInvoice>(x => x.PaymentIntentId);

        builder.HasOne(x => x.Invoice)
            .WithOne(x => x.PaymentIntent)
            .HasForeignKey<StripePaymentIntentInvoice>(x => x.InvoiceId);
    }

    public string PaymentIntentId { get; set; }
    public StripePaymentIntent PaymentIntent { get; set; }
    public string InvoiceId { get; set; }
    public StripeInvoice Invoice { get; set; }
}