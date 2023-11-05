#region Header Info

// Copyright 2023 Rod Johnson.  All rights reserved

#endregion

using System.Threading.Tasks;
using Stripe;
using TranslationPro.Base.Common.Services.Interfaces;
using TranslationPro.Base.Stripe.Entities;
using TranslationPro.Shared.Common;

namespace TranslationPro.Base.Stripe.Interfaces;

public interface IStripeChargeService : IService<StripeCharge>
{
    Task<Result> HandleChargeCreated(Charge input);
    Task<Result> HandleChargeDisputeCreated(Dispute input);
    Task<Result> HandleChargeDisputeClosed(Dispute input);
    Task<Result> HandleChargeDisputeFundsReinstated(Dispute input);
    Task<Result> HandleChargeDisputeFundsWithdrawn(Dispute input);
    Task<Result> HandleChargeDisputeUpdated(Dispute input);
    Task<Result> HandleChargeExpired(Charge input);
    Task<Result> HandleChargeFailed(Charge input);
    Task<Result> HandleChargePending(Charge input);
    Task<Result> HandleChargeRefundUpdated(Refund input);
    Task<Result> HandleChargeRefunded(Refund input);
    Task<Result> HandleChargeSucceeded(Charge input);
    Task<Result> HandleChargeUpdated(Charge input);
    Task<Result> HandleChargeCaptured(Charge input);



}