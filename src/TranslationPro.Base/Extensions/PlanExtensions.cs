using TranslationPro.Base.Entities;

namespace TranslationPro.Base.Extensions;

public static class PlanExtensions
{
    public static void Sync(this Plan entity, Stripe.Plan plan)
    {
        entity.Id = plan.Id;
        entity.ProductId = plan.ProductId;
        entity.Active = plan.Active;
        entity.Amount = plan.Amount;
        entity.AmountDecimal = plan.AmountDecimal;
        entity.Interval = plan.Interval;
        entity.IntervalCount = plan.IntervalCount;
    }
}