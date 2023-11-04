using System;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Stripe;
using TranslationPro.Base.Common.Data.Bases;
using TranslationPro.Base.Stripe.Interfaces;

namespace TranslationPro.Base.Stripe.Entities;

public class StripeInvoiceLine : BaseEntity<StripeInvoiceLine>, IHasInvoice, IHasId
{
    public override void Configure(EntityTypeBuilder<StripeInvoiceLine> builder)
    {
        builder.HasKey(x => x.Id);

        builder.HasOne(x => x.Invoice)
            .WithMany(x => x.Lines)
            .HasForeignKey(x => x.InvoiceId);
    }

    public string InvoiceId { get; set; }
    public StripeInvoice Invoice { get; set; }
    public string Id { get; set; }
}