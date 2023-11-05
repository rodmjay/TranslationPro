#region Header Info

// Copyright 2023 Rod Johnson.  All rights reserved

#endregion

using System;
using TranslationPro.Base.Stripe.Entities;
using TranslationPro.Base.Stripe.Interfaces;

namespace TranslationPro.Base.Stripe.Services;

public class StripePromotionCodeService : StripeService<StripePromotionCode>, IStripePromotionCodeService
{
    public StripePromotionCodeService(IServiceProvider serviceProvider) : base(serviceProvider)
    {
    }
}