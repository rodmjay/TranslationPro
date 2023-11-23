#region Header Info

// Copyright 2023 Rod Johnson.  All rights reserved

#endregion

namespace TranslationPro.Shared.Stripe;

public class SimpleSubscriptionCreateOptions
{
    public string PriceId { get; set; }
    public string CouponCode { get; set; }
}