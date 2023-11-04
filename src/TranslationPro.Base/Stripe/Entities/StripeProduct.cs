using System.Collections.Generic;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TranslationPro.Base.Common.Data.Bases;
using TranslationPro.Base.Stripe.Interfaces;

namespace TranslationPro.Base.Stripe.Entities
{
    public class StripeProduct : BaseEntity<StripeProduct>, IActive 
    {
        public string Id { get; set; }
        public bool Active { get; set; }
        public string Description { get; set; }
        public string Name { get; set; }
        public bool LiveMode { get; set; }

        public ICollection<StripePrice> Prices { get; set; }

        public override void Configure(EntityTypeBuilder<StripeProduct> builder)
        {
            builder.HasKey(x => x.Id);

        }
    }
}
