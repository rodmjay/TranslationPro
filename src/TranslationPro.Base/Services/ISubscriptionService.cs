#region Header Info

// Copyright 2023 Rod Johnson.  All rights reserved

#endregion

using System.Threading.Tasks;
using Stripe.Checkout;
using TranslationPro.Base.Common.Services.Interfaces;
using TranslationPro.Shared.Common;
using TranslationPro.Shared.Models;
using Subscription = TranslationPro.Base.Entities.Subscription;

namespace TranslationPro.Base.Services;

public interface ISubscriptionService : IService<Subscription>
{
    Task<Stripe.Subscription> GetSubscriptionAsync(int userId);
    
    Task<Result> CompleteSubscriptionCheckout(int userId, string checkoutSessionId);

    Task<Session> CreateCheckoutSession(int userId);
}