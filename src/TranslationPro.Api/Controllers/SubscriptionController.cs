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

public class SubscriptionController : BaseController, ISubscriptionController
{
    private readonly ISubscriptionService _subscriptionService;

    public SubscriptionController(IServiceProvider serviceProvider,
        ISubscriptionService subscriptionService) : base(serviceProvider)
    {
        _subscriptionService = subscriptionService;
    }

    [HttpGet]
    public async Task<SubscriptionOutput> GetSubscription()
    {
        var user = await GetCurrentUser();

        return await _subscriptionService.GetSubscriptionAsync<SubscriptionOutput>(user.Id);
    }

    [HttpPut]
    public async Task<string> CreateCheckoutSession()
    {
        var user = await GetCurrentUser();

        var session = await _subscriptionService.CreateCheckoutSession(user.Id);
        return session.ClientSecret;
    }

    [HttpPatch]
    public async Task<Result> CompleteSession([FromQuery] string checkoutSessionId)
    {
        var user = await GetCurrentUser();

        return await _subscriptionService.CompleteSubscriptionCheckout(user.Id, checkoutSessionId);
    }
}