#region Header Info

// Copyright 2023 Rod Johnson.  All rights reserved

#endregion

using TranslationPro.Base.Stripe.Config;

namespace TranslationPro.Base.Common.Settings;

public partial class AppSettings
{
    public StripeSettings Stripe { get; set; }
}