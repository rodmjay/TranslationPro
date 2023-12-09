#region Header Info

// Copyright 2023 Rod Johnson.  All rights reserved

#endregion

using System.Threading.Tasks;
using Stripe.Checkout;
using TranslationPro.Shared.Common;
using TranslationPro.Shared.Models;

namespace TranslationPro.Base.Services;

public interface IStripeService
{
    void Initialize();
    Task<T> GetSubscriptionAsync<T>(int userId) where T : SubscriptionOutput;

    Task<Result> CompleteSubscriptionCheckout(int userId, string checkoutSessionId);

    Task<Session> CreateCheckoutSession(int userId);
}