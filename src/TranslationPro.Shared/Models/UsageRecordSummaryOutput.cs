using System;

namespace TranslationPro.Shared.Models;

public class UsageRecordSummaryOutput
{
    public long TotalUsage { get; set; }
    public DateTime? PeriodEnd { get; set; }
    public DateTime? PeriodStart { get; set; }
}