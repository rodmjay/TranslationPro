#region Header Info

// Copyright 2023 Rod Johnson.  All rights reserved

#endregion

using System;
using Stripe;
using TranslationPro.Base.Stripe.Entities;

namespace TranslationPro.Base.Stripe.Managers;

public class PromotionCodeManager : StripeManager<StripePromotionCode>, IPromotionCodeManager
{
    protected readonly PromotionCodeService PromotionCodeService;

    public PromotionCodeManager(IServiceProvider serviceProvider, PromotionCodeService promotionCodeService) : base(serviceProvider)
    {
        PromotionCodeService = promotionCodeService;
    }
}