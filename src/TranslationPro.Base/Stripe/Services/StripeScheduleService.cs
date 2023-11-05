#region Header Info

// Copyright 2023 Rod Johnson.  All rights reserved

#endregion

using System;
using TranslationPro.Base.Stripe.Entities;
using TranslationPro.Base.Stripe.Interfaces;

namespace TranslationPro.Base.Stripe.Services;

public class StripeScheduleService : StripeService<StripeSubscriptionSchedule>, IStripeScheduleService
{
    public StripeScheduleService(IServiceProvider serviceProvider) : base(serviceProvider)
    {
    }
}