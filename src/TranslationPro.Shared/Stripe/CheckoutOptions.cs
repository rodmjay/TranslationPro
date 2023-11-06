#region Header Info

// Copyright 2023 Rod Johnson.  All rights reserved

#endregion

using System.Collections.Generic;

namespace TranslationPro.Shared.Stripe;

public class CheckoutOptions
{
    public List<string> Prices { get; set; }
}