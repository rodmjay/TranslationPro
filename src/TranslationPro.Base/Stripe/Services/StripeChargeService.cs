#region Header Info

// Copyright 2023 Rod Johnson.  All rights reserved

#endregion

using System;
using System.Threading.Tasks;
using Stripe;
using TranslationPro.Base.Stripe.Entities;
using TranslationPro.Base.Stripe.Interfaces;
using TranslationPro.Shared.Common;

namespace TranslationPro.Base.Stripe.Services;

public class StripeChargeService : StripeService<StripeCharge>, IStripeChargeService
{
    public StripeChargeService(IServiceProvider serviceProvider) : base(serviceProvider)
    {
    }

    public Task<Result> HandleChargeCreated(Charge input)
    {
        throw new NotImplementedException();
    }

    public Task<Result> HandleChargeDisputeCreated(Dispute input)
    {
        throw new NotImplementedException();
    }

    public Task<Result> HandleChargeDisputeClosed(Dispute input)
    {
        throw new NotImplementedException();
    }

    public Task<Result> HandleChargeDisputeFundsReinstated(Dispute input)
    {
        throw new NotImplementedException();
    }

    public Task<Result> HandleChargeDisputeFundsWithdrawn(Dispute input)
    {
        throw new NotImplementedException();
    }

    public Task<Result> HandleChargeDisputeUpdated(Dispute input)
    {
        throw new NotImplementedException();
    }

    public Task<Result> HandleChargeExpired(Charge input)
    {
        throw new NotImplementedException();
    }

    public Task<Result> HandleChargeFailed(Charge input)
    {
        throw new NotImplementedException();
    }

    public Task<Result> HandleChargePending(Charge input)
    {
        throw new NotImplementedException();
    }

    public Task<Result> HandleChargeRefundUpdated(Refund input)
    {
        throw new NotImplementedException();
    }

    public Task<Result> HandleChargeRefunded(Refund input)
    {
        throw new NotImplementedException();
    }

    public Task<Result> HandleChargeSucceeded(Charge input)
    {
        throw new NotImplementedException();
    }

    public Task<Result> HandleChargeUpdated(Charge input)
    {
        throw new NotImplementedException();
    }

    public Task<Result> HandleChargeCaptured(Charge input)
    {
        throw new NotImplementedException();
    }
}