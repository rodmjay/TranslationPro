using System.Collections.Generic;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Stripe;
using TranslationPro.Base.Common.Data.Bases;
using TranslationPro.Base.Stripe.Interfaces;

namespace TranslationPro.Base.Stripe.Entities;

public class StripeCharge : BaseEntity<StripeCharge>, IHasId, ILiveMode, IHasCustomer, IHasInvoice, IAmount
{
    public override void Configure(EntityTypeBuilder<StripeCharge> builder)
    {
        builder.HasKey(x => x.Id);

        builder.HasOne(x => x.Customer)
            .WithMany(x => x.Charges)
            .HasForeignKey(x => x.CustomerId);

        builder.HasOne(x => x.Invoice)
            .WithMany(x => x.Charges)
            .HasForeignKey(x => x.InvoiceId);
    }
    public ICollection<StripeRefund> Refunds { get; set; }
    public string Id { get; set; }
    public bool LiveMode { get; set; }
    public StripeCustomer Customer { get; set; }
    public string CustomerId { get; set; }
    public string InvoiceId { get; set; }
    public StripeInvoice Invoice { get; set; }
    public int Amount { get; set; }
}