#region Header Info

// Copyright 2023 Rod Johnson.  All rights reserved

#endregion

using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using TranslationPro.Base.Common.Middleware.Bases;
using TranslationPro.Base.Services;
using TranslationPro.Shared.Common;
using TranslationPro.Shared.Interfaces;
using TranslationPro.Shared.Models;

namespace TranslationPro.Api.Controllers;

public class StripeController : BaseController, IStripeController
{
    private readonly IStripeService _stripeService;

    public StripeController(IServiceProvider serviceProvider,
        IStripeService stripeService) : base(serviceProvider)
    {
        _stripeService = stripeService;
    }

    [HttpGet("subscription")]
    public async Task<SubscriptionOutput> GetSubscription()
    {
        var user = await GetCurrentUser();

        return await _stripeService.GetSubscriptionAsync<SubscriptionOutput>(user.Id);
    }

    [HttpPut("checkout")]
    public async Task<string> CreateCheckoutSession()
    {
        var user = await GetCurrentUser();

        var session = await _stripeService.CreateCheckoutSession(user.Id);
        return session.ClientSecret;
    }

    [HttpPatch("complete-checkout")]
    public async Task<Result> CompleteSession([FromQuery] string checkoutSessionId)
    {
        var user = await GetCurrentUser();

        return await _stripeService.CompleteSubscriptionCheckout(user.Id, checkoutSessionId);
    }
}