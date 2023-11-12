using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Stripe;
using TranslationPro.Base.Common.Middleware.Bases;
using TranslationPro.Base.Stripe.Managers;
using TranslationPro.Shared.Common;
using TranslationPro.Shared.Stripe;

namespace TranslationPro.Api.Stripe
{
    public class SubscriptionsController : BaseController
    {
        private readonly ISubscriptionManager _subscriptionManager;

        protected SubscriptionsController(IServiceProvider serviceProvider,
            ISubscriptionManager subscriptionManager) : base(serviceProvider)
        {
            _subscriptionManager = subscriptionManager;
        }

        [HttpPost]
        public async Task<Result> CreateSubscription([FromBody] SimpleSubscriptionCreateOptions input)
        {
            var options = new SubscriptionCreateOptions();
            var user = await GetCurrentUser();
            var result = await _subscriptionManager.CreateSubscription(user.Id, options);

            return result;
        }
    }
}
