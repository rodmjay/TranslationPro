#region Header Info

// Copyright 2023 Rod Johnson.  All rights reserved

#endregion

using System.Threading.Tasks;
using Stripe;
using TranslationPro.Base.Common.Services.Interfaces;
using TranslationPro.Base.Stripe.Entities;
using TranslationPro.Shared.Common;

namespace TranslationPro.Base.Stripe.Interfaces;

public interface IStripePaymentIntentService : IService<StripePaymentIntent>
{
    Task<Result> HandlePaymentIntentCanceled(PaymentIntent input);
    Task<Result> HandlePaymentIntentCreated(PaymentIntent input);
    Task<Result> HandlePaymentIntentPartiallyFunded(PaymentIntent input);
    Task<Result> HandlePaymentIntentPaymentFailed(PaymentIntent input);
    Task<Result> HandlePaymentIntentProcessing(PaymentIntent input);
    Task<Result> HandlePaymentIntentRequiresAction(PaymentIntent input);
    Task<Result> HandlePaymentIntentSucceeded(PaymentIntent input);
    Task<Result> HandlePaymentIntentCapturableUpdated(PaymentIntent deserialize);
    Task<Result> HandlePaymentRequiresAction(PaymentIntent deserialize);
}