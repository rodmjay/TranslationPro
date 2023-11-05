using System.Threading.Tasks;
using Stripe;
using TranslationPro.Base.Common.Services.Interfaces;
using TranslationPro.Base.Stripe.Entities;
using TranslationPro.Shared.Common;

namespace TranslationPro.Base.Stripe.Interfaces;

public interface IStripeSubscriptionService : IService<StripeSubscription>
{
    Task<Result> HandleSubscriptionCreated(Subscription input);
    Task<Result> HandleSubscriptionDeleted(Subscription input);
    Task<Result> HandleSubscriptionUpdated(Subscription input);
    Task<Result> HandleSubscriptionPaused(Subscription input);
    Task<Result> HandleSubscriptionPendingUpdateApplied(Subscription input);
    Task<Result> HandleSubscriptionPendingUpdateExpired(Subscription input);
    Task<Result> HandleSubscriptionResumed(Subscription input);
    Task<Result> HandleSubscriptionTrialWillEnd(Subscription input);

}