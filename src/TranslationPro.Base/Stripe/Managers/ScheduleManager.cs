#region Header Info

// Copyright 2023 Rod Johnson.  All rights reserved

#endregion

using System;
using Stripe;
using TranslationPro.Base.Stripe.Entities;

namespace TranslationPro.Base.Stripe.Managers;

public class ScheduleManager : StripeManager<StripeSubscriptionSchedule>, IScheduleManager
{
    protected SubscriptionScheduleService ScheduleService;
    public ScheduleManager(IServiceProvider serviceProvider, SubscriptionScheduleService scheduleService) : base(serviceProvider)
    {
        ScheduleService = scheduleService;
    }
}