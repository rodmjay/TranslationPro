using System.Linq;
using TranslationPro.Base.Common.Data.Enums;
using TranslationPro.Base.Entities;

namespace TranslationPro.Base.Extensions;

public static class SubscriptionExtensions
{
    public static void Sync(this SubscriptionItem entity, Stripe.SubscriptionItem subscriptionItem, int userId)
    {
        entity.PlanId = subscriptionItem.Plan.Id;
        entity.StripeItemId = subscriptionItem.Id;
        entity.ProductId = subscriptionItem.Plan.ProductId;
        entity.SubscriptionId = subscriptionItem.Subscription;
        entity.UserId = userId;
    }

    public static void Sync(this Subscription entity, Stripe.Subscription subscription, int userId)
    {
        entity.UserId = userId;
        entity.CustomerId = subscription.CustomerId;
        entity.SubscriptionId = subscription.Id;
        entity.StartDate = subscription.StartDate;
        entity.EndedAt = subscription.EndedAt;
        entity.DaysUntilDue = subscription.DaysUntilDue;
        entity.CurrentPeriodStart = subscription.CurrentPeriodStart;
        entity.CurrentPeriodEnd = subscription.CurrentPeriodEnd;
        entity.Created = subscription.Created;
        entity.CollectionMethod = subscription.CollectionMethod;
        entity.CancelAt = subscription.CancelAt;
        entity.CancelAtPeriodEnd = subscription.CancelAtPeriodEnd;
        entity.CanceledAt = subscription.CanceledAt;

        foreach (var item in subscription.Items.Data)
        {
            var existingItem = entity.Items.FirstOrDefault(x => x.StripeItemId == item.Id);

            if (existingItem != null)
            {
                existingItem.Sync(item, userId);
                existingItem.ObjectState = ObjectState.Modified;
            }
            else
            {
                existingItem = new SubscriptionItem();
                existingItem.Sync(item, userId);
                existingItem.ObjectState = ObjectState.Added;

                entity.Items.Add(existingItem);
            }
        }
    }
}