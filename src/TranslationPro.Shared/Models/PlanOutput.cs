namespace TranslationPro.Shared.Models;

public class PlanOutput
{
    public string Id { get; set; }
    public bool Active { get; set; }
    public long? Amount { get; set; }
    public decimal? AmountDecimal { get; set; }
    public string Interval { get; set; }
    public long IntervalCount { get; set; }
}