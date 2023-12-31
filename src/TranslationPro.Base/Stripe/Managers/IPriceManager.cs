﻿#region Header Info

// Copyright 2023 Rod Johnson.  All rights reserved

#endregion

using System.Threading.Tasks;
using Stripe;
using TranslationPro.Base.Common.Services.Interfaces;
using TranslationPro.Base.Stripe.Entities;
using TranslationPro.Shared.Common;

namespace TranslationPro.Base.Stripe.Managers;

public interface IPriceManager : IService<StripePrice>
{
    Task<Result> CreatePrice(PriceCreateOptions options);
    Task<Result> UpdatePrice(string priceId, PriceUpdateOptions options);
    Task<Result> HandlePriceCreated(Price input);
    Task<Result> HandlePriceDeleted(Price input);
    Task<Result> HandlePriceUpdated(Price input);
}