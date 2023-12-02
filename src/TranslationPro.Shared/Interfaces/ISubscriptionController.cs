#region Header Info

// Copyright 2023 Rod Johnson.  All rights reserved

#endregion

using System.Threading.Tasks;
using TranslationPro.Shared.Common;
using TranslationPro.Shared.Models;

namespace TranslationPro.Shared.Interfaces;

public interface ISubscriptionController
{
    Task<Stripe.Subscription> GetSubscription();
    Task<string> CreateCheckoutSession();
    Task<Result> CompleteSession( string checkoutSessionId);
}