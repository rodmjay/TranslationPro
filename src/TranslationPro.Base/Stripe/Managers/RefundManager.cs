#region Header Info

// Copyright 2023 Rod Johnson.  All rights reserved

#endregion

using System;
using Stripe;
using TranslationPro.Base.Stripe.Entities;

namespace TranslationPro.Base.Stripe.Managers;

public class RefundManager : StripeManager<StripeRefund>, IRefundManager
{
    protected readonly RefundService RefundService;

    public RefundManager(IServiceProvider serviceProvider, RefundService refundService) : base(serviceProvider)
    {
        RefundService = refundService;
    }
}