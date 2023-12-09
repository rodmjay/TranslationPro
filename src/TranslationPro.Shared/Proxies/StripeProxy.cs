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

public class StripeProxy : BaseProxy, IStripeController
{
    public StripeProxy(HttpClient httpClient) : base(httpClient)
    {
    }

    public Task<SubscriptionOutput> GetSubscription()
    {
        return DoGet<SubscriptionOutput>($"v1.0/stripe/subscription");
    }

    public Task<string> CreateCheckoutSession()
    {
        return DoPut<string>("v1.0/stripe/checkout");
    }

    public Task<Result> CompleteSession(string checkoutSessionId)
    {
        return DoPatch<Result>($"v1.0/stripe/complete-checkout?checkoutSessionId={checkoutSessionId}");
    }
}