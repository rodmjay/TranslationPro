using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Stripe;
using TranslationPro.Base.Common.Data.Bases;
using TranslationPro.Base.Stripe.Interfaces;

namespace TranslationPro.Base.Stripe.Entities;

public class StripeInvoice : BaseEntity<StripeInvoice>, IHasId, ICreatedTimestamp, ICurrency, IHasCustomer
{
    public ICollection<StripeCharge> Charges { get; set; }

    public override void Configure(EntityTypeBuilder<StripeInvoice> builder)
    {
        builder.HasKey(t => t.Id);

        builder.HasOne(x => x.Customer)
            .WithMany(x => x.Invoices)
            .HasForeignKey(x => x.CustomerId);
    }
    public ICollection<StripeInvoiceLine> Lines { get; set; }
    public ICollection<StripePaymentIntent> PaymentIntents { get; set; }
    public string Id { get; set; }
    public int Created { get; set; }
    public bool Captured { get; set; }
    public int AmountCaptured { get; set; }
    public bool Refunded { get; set; }
    public string Currency { get; set; }
    public StripeCustomer Customer { get; set; }
    public string CustomerId { get; set; }
}