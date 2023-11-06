using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Stripe;
using TranslationPro.Base.Common.Data.Bases;
using TranslationPro.Base.Stripe.Interfaces;

namespace TranslationPro.Base.Stripe.Entities;

public class StripePaymentMethod : BaseEntity<StripePaymentMethod>, IHasId, IHasCustomer, IHasCard
{
    public override void Configure(EntityTypeBuilder<StripePaymentMethod> builder)
    {
        builder.ToTable(nameof(PaymentMethod), "Stripe");

        builder.HasKey(t => t.Id);

        builder.HasOne(x => x.Customer)
            .WithMany(x => x.PaymentMethods)
            .HasForeignKey(x => x.CustomerId);
    }
    
    public string Id { get; set; }
    public StripeCustomer Customer { get; set; }
    public string CustomerId { get; set; }
    public StripeCard Card { get; set; }

    public ICollection<StripeSubscription> Subscriptions { get; set; }
}