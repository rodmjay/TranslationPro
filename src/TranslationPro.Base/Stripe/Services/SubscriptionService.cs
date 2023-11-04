#region Header Info

// Copyright 2023 Rod Johnson.  All rights reserved

#endregion

using System;
using TranslationPro.Base.Common.Services.Bases;
using TranslationPro.Base.Stripe.Entities;
using TranslationPro.Base.Stripe.Interfaces;

namespace TranslationPro.Base.Stripe.Services;

public class SubscriptionService : BaseService<StripeSubscription>, ISubscriptionService
{
    public SubscriptionService(IServiceProvider serviceProvider) : base(serviceProvider)
    {
    }
}