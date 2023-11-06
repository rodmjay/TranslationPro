using TranslationPro.Base.Common.Data.Bases;

namespace TranslationPro.Base.Stripe.Entities;

public class StripeChargeOutcome : BaseObjectState
{
    public string NetworkStatus { get; set; }
    public string Reason { get; set; }
    public string RiskLevel { get; set; }
    public long RiskScore { get; set; }
    public string SellerMessage { get; set; }
    public string Type { get; set; }
}