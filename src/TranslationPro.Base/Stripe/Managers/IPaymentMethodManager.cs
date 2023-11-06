#region Header Info

// Copyright 2023 Rod Johnson.  All rights reserved

#endregion

using System.Threading.Tasks;
using Stripe;
using TranslationPro.Base.Common.Services.Interfaces;
using TranslationPro.Base.Stripe.Entities;
using TranslationPro.Shared.Common;

namespace TranslationPro.Base.Stripe.Managers;

public interface IPaymentMethodManager : IService<StripePaymentMethod>
{
    Task<Result> HandlePaymentMethodAttached(PaymentMethod input);
    Task<Result> HandlePaymentMethodAutomaticallyUpdated(PaymentMethod input);
    Task<Result> HandlePaymentMethodDetached(PaymentMethod input);
    Task<Result> HandlePaymentMethodUpdated(PaymentMethod input);
}