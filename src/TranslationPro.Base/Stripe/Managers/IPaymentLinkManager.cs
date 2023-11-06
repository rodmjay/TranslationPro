#region Header Info

// Copyright 2023 Rod Johnson.  All rights reserved

#endregion

using System.Threading.Tasks;
using Stripe;
using TranslationPro.Base.Common.Services.Interfaces;
using TranslationPro.Base.Stripe.Entities;
using TranslationPro.Shared.Common;

namespace TranslationPro.Base.Stripe.Managers;

public interface IPaymentLinkManager : IService<StripePaymentLink>
{
    Task<Result> CreatePaymentLink(int userId, PaymentLinkCreateOptions options);
    Task<Result> HandlePaymentLinkCreated(PaymentLink paymentLink);
}