using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Stripe;
using TranslationPro.Base.Common.Data.Bases;
using TranslationPro.Base.Stripe.Interfaces;

namespace TranslationPro.Base.Stripe.Entities;

public class StripePaymentIntent : BaseEntity<StripePaymentIntent>,
    IHasId, IAmount, ICreatedTimestamp, ICurrency, IHasCustomer, ILiveMode
{
    public override void Configure(EntityTypeBuilder<StripePaymentIntent> builder)
    {
        builder.ToTable(nameof(PaymentIntent), "Stripe");
        builder.HasKey(x => x.Id);

        builder.HasOne(x => x.Customer)
            .WithMany(x => x.PaymentIntents)
            .HasForeignKey(x => x.CustomerId);
        
    }

    public string Id { get; set; }
    public long Amount { get; set; }
    public string CaptureMethod { get; set; }
    public string ConfirmationMethod { get; set; }

    public int Created { get; set; }

    public string Currency { get; set; }
    public StripeCustomer Customer { get; set; }
    public string CustomerId { get; set; }
    public string InvoiceId { get; set; }
    public StripePaymentIntentInvoice Invoice { get; set; }
    public bool LiveMode { get; set; }
}