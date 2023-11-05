using System.Collections.Generic;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Stripe;
using TranslationPro.Base.Common.Data.Bases;
using TranslationPro.Base.Stripe.Interfaces;

namespace TranslationPro.Base.Stripe.Entities;

public class StripeCoupon : BaseEntity<StripeCoupon>, IHasId, ICreatedTimestamp, ILiveMode
{
    public override void Configure(EntityTypeBuilder<StripeCoupon> builder)
    {
        builder.HasKey(x => x.Id);
    }

    public ICollection<StripePromotionCode> PromotionCodes { get; set; }
    public string Id { get; set; }
    public long? AmountOff { get; set; }
    public string Currency { get; set; }
    public bool? Deleted { get; set; }
    public string Duration { get; set; }
    public long? DurationInMonths { get; set; }
    public long? MaxRedemptions { get; set; }
    public string Name { get; set; }
    public decimal? PercentOff { get; set; }
    
    public long? RedeemBy { get; set; }
    
    public long TimesRedeemed { get; set; }
    
    public bool Valid { get; set; }

    public int Created { get; set; }
    public bool LiveMode { get; set; }
}