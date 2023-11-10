using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TranslationPro.Base.Common.Data.Bases;
using TranslationPro.Base.Stripe.Interfaces;

namespace TranslationPro.Base.Stripe.Entities
{
    public class StripeProduct : BaseEntity<StripeProduct>, IActive , ILiveMode
    {
        public string Id { get; set; }
        public bool Active { get; set; }
        public string Description { get; set; }
        public string Name { get; set; }
        public bool LiveMode { get; set; }

        public ICollection<StripePrice> Prices { get; set; }
        public ICollection<StripeCouponProduct> Coupons { get; set; }
        public override void Configure(EntityTypeBuilder<StripeProduct> builder)
        {
            builder.ToTable(nameof(StripeProduct), "Stripe");
            builder.HasKey(x => x.Id);

        }
        
        public DateTime Created { get; set; }
        
        public bool? Deleted { get; set; }
        
        public ICollection<StripeProductFeature> Features { get; set; }
        
        public string StatementDescriptor { get; set; }
        
        public string Type { get; set; }
        
        public string UnitLabel { get; set; }
        
        public DateTime Updated { get; set; }
        
        public string Url { get; set; }
    }
}
