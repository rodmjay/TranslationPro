using TranslationPro.Base.Common.Data.Bases;

namespace TranslationPro.Base.Stripe.Entities;

public class StripePriceRecurring : BaseObjectState
{
    public string AggregateUsage { get; set; }

    public string Interval { get; set; }
    
    public long IntervalCount { get; set; }
    
    public long? TrialPeriodDays { get; set; }
    
    public string UsageType { get; set; }
}