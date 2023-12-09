using System.Collections.Generic;

namespace TranslationPro.Shared.Models;

public class SubscriptionItemOutput
{
    public string Id { get; set; }
    public ProductOutput Product { get; set; }
    public PlanOutput Plan { get; set; }
    public List<UsageRecordSummaryOutput> UsageRecords { get; set; }
}