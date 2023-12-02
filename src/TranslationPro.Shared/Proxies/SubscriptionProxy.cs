#region Header Info

// Copyright 2023 Rod Johnson.  All rights reserved

#endregion

using System;
using System.Net.Http;
using System.Threading.Tasks;
using TranslationPro.Shared.Common;
using TranslationPro.Shared.Interfaces;
using TranslationPro.Shared.Models;

namespace TranslationPro.Shared.Proxies;

public class SubscriptionProxy : BaseProxy, ISubscriptionController
{
    public SubscriptionProxy(HttpClient httpClient) : base(httpClient)
    {
    }

    public Task<Stripe.Subscription> GetSubscription()
    {
        return DoGet<Stripe.Subscription>($"v1.0/subscription");
    }

    public Task<string> CreateCheckoutSession()
    {
        return DoPut<string>("v1.0/subscription");
    }

    public Task<Result> CompleteSession(string checkoutSessionId)
    {
        return DoPatch<Result>($"v1.0/subscription?checkoutSessionId={checkoutSessionId}");
    }
}