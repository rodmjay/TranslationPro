#region Header Info

// Copyright 2023 Rod Johnson.  All rights reserved

#endregion

using System;
using System.Threading.Tasks;
using Stripe;
using TranslationPro.Base.Stripe.Entities;
using TranslationPro.Shared.Common;

namespace TranslationPro.Base.Stripe.Managers;

public class SubscriptionManager : StripeManager<StripeSubscription>, ISubscriptionManager
{
    protected readonly SubscriptionService SubscriptionService;

    public SubscriptionManager(IServiceProvider serviceProvider, SubscriptionService subscriptionService) : base(serviceProvider)
    {
        SubscriptionService = subscriptionService;
    }

    public Task<Result> CreateSubscription(int userId, SubscriptionCreateOptions options)
    {
        throw new NotImplementedException();
    }

    public async Task<Result> CreateSubscription(string customerId, SubscriptionCreateOptions options)
    {
        options.Customer = customerId;
        var subscription = await SubscriptionService.CreateAsync(options);

        if (subscription != null)
        {
            return Result.Success(subscription.Id);
        }

        return Result.Failed();
    }

    public Task<Result> HandleSubscriptionCreated(Subscription input)
    {
        throw new NotImplementedException();
    }

    public Task<Result> HandleSubscriptionDeleted(Subscription input)
    {
        throw new NotImplementedException();
    }

    public Task<Result> HandleSubscriptionUpdated(Subscription input)
    {
        throw new NotImplementedException();
    }

    public Task<Result> HandleSubscriptionPaused(Subscription input)
    {
        throw new NotImplementedException();
    }

    public Task<Result> HandleSubscriptionPendingUpdateApplied(Subscription input)
    {
        throw new NotImplementedException();
    }

    public Task<Result> HandleSubscriptionPendingUpdateExpired(Subscription input)
    {
        throw new NotImplementedException();
    }

    public Task<Result> HandleSubscriptionResumed(Subscription input)
    {
        throw new NotImplementedException();
    }

    public Task<Result> HandleSubscriptionTrialWillEnd(Subscription input)
    {
        throw new NotImplementedException();
    }
}