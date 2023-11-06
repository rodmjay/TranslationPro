#region Header Info

// Copyright 2023 Rod Johnson.  All rights reserved

#endregion

using System;
using System.Threading.Tasks;
using Stripe;
using TranslationPro.Base.Stripe.Entities;
using TranslationPro.Shared.Common;

namespace TranslationPro.Base.Stripe.Managers;

public class ChargeManager : StripeManager<StripeCharge>, IChargeManager
{
    private readonly ChargeService _chargeService;

    public ChargeManager(IServiceProvider serviceProvider, ChargeService chargeService) : base(serviceProvider)
    {
        _chargeService = chargeService;
    }

    public async Task<Result> CreateCharge(ChargeCreateOptions options)
    {
        var charge = await _chargeService.CreateAsync(options);

        if (charge != null)
        {
            return Result.Success(charge.Id);
        }

        return Result.Failed();
    }

    public async Task<Result> UpdateCharge(string chargeId, ChargeUpdateOptions options)
    {
        var charge = await _chargeService.UpdateAsync(chargeId, options);

        if (charge != null)
        {
            return Result.Success(charge.Id);
        }

        return Result.Failed();
    }

    public async Task<Result> CaptureCharge(string chargeId, ChargeCaptureOptions options)
    {
        var charge = await _chargeService.CaptureAsync(chargeId, options);

        if (charge != null)
        {
            return Result.Success(charge.Id);
        }

        return Result.Failed();
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