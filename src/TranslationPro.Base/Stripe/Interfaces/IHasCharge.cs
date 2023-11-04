#region Header Info

// Copyright 2023 Rod Johnson.  All rights reserved

#endregion

using TranslationPro.Base.Stripe.Entities;

namespace TranslationPro.Base.Stripe.Interfaces;

public interface IHasCharge
{
    string ChargeId { get; set; }

    StripeCharge Charge { get; set; }
}