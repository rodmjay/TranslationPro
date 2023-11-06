using System.Threading.Tasks;
using Stripe;
using TranslationPro.Base.Common.Services.Interfaces;
using TranslationPro.Base.Stripe.Entities;
using TranslationPro.Shared.Common;

namespace TranslationPro.Base.Stripe.Managers;

public interface ISubscriptionManager : IService<StripeSubscription>
{
    Task<Result> CreateSubscription(int userId, SubscriptionCreateOptions options);
    Task<Result> CreateSubscription(string customerId, SubscriptionCreateOptions options);
    Task<Result> HandleSubscriptionCreated(Subscription input);
    Task<Result> HandleSubscriptionDeleted(Subscription input);
    Task<Result> HandleSubscriptionUpdated(Subscription input);
    Task<Result> HandleSubscriptionPaused(Subscription input);
    Task<Result> HandleSubscriptionPendingUpdateApplied(Subscription input);
    Task<Result> HandleSubscriptionPendingUpdateExpired(Subscription input);
    Task<Result> HandleSubscriptionResumed(Subscription input);
    Task<Result> HandleSubscriptionTrialWillEnd(Subscription input);

}