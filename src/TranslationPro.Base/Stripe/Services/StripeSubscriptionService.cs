#region Header Info

// Copyright 2023 Rod Johnson.  All rights reserved

#endregion

using System;
using System.Threading.Tasks;
using Stripe;
using TranslationPro.Base.Stripe.Entities;
using TranslationPro.Base.Stripe.Interfaces;
using TranslationPro.Shared.Common;

namespace TranslationPro.Base.Stripe.Services;

public class StripeSubscriptionService : StripeService<StripeSubscription>, IStripeSubscriptionService
{
    
    public StripeSubscriptionService(IServiceProvider serviceProvider) : base(serviceProvider)
    {
        
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