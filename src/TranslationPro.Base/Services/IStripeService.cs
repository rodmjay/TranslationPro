#region Header Info

// Copyright 2023 Rod Johnson.  All rights reserved

#endregion

using System.Threading.Tasks;
using Stripe.Checkout;
using TranslationPro.Shared.Common;

namespace TranslationPro.Base.Services;

public interface IStripeService
{
    void Initialize();
    Task<Stripe.Subscription> GetSubscriptionAsync(int userId);

    Task<Result> CompleteSubscriptionCheckout(int userId, string checkoutSessionId);

    Task<Session> CreateCheckoutSession(int userId);
}