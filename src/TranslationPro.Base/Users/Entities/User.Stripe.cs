#region Header Info

// Copyright 2023 Rod Johnson.  All rights reserved

#endregion

using TranslationPro.Base.Stripe.Entities;

namespace TranslationPro.Base.Users.Entities;

public partial class User
{
    public string CustomerId { get; set; }
    public StripeCustomer Customer { get; set; }
}