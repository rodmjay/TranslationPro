#region Header Info

// Copyright 2023 Rod Johnson.  All rights reserved

#endregion

using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Stripe;
using TranslationPro.Base.Common.Data.Bases;
using TranslationPro.Base.Stripe.Interfaces;

namespace TranslationPro.Base.Stripe.Entities;

public class StripeCard : BaseEntity<StripeCard>, IHasId, IHasCustomer
{
    public override void Configure(EntityTypeBuilder<StripeCard> builder)
    {
        builder.HasKey(x => x.Id);

        builder.HasOne(x => x.Customer)
            .WithMany(x => x.Cards)
            .HasForeignKey(x => x.CustomerId);
    }

    public string Id { get; set; }
    public StripeCustomer Customer { get; set; }
    public string CustomerId { get; set; }
    public string Last4 { get; set; }
    public string Name { get; set; }
    public string Brand { get; set; }
    public string CvcCheck { get; set; }
    public long ExpMonth { get; set; }
    public long ExpYear { get; set; }
    public bool? Deleted { get; internal set; }
    public bool? DefaultForCurrency { get; set; }
    public string Description { get; set; }
    public string Country { get; set; }
    public string Currency { get; set; }
    public string AddressZipCheck { get; set; }
    public string AddressZip { get; set; }
    public string AddressState { get; set; }
    public string AddressLine2 { get; set; }
    public string AddressLine1Check { get; set; }
    public string AddressLine1 { get; set; }
    public string AddressCountry { get; set; }
    public string AddressCity { get; set; }
    public string DynamicLast4 { get; set; }
    public string Fingerprint { get; set; }
    public string Funding { get; set; }
    public string Iin { get; set; }
    public string Issuer { get; set; }
    public string Status { get; set; }
    public string TokenizationMethod { get; set; }
}