#region Header Info

// Copyright 2023 Rod Johnson.  All rights reserved

#endregion

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper.QueryableExtensions;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using Stripe;
using Stripe.Checkout;
using TranslationPro.Base.Common.Services.Bases;
using TranslationPro.Base.Settings;
using TranslationPro.Shared.Common;
using TranslationPro.Shared.Models;
using Subscription = TranslationPro.Base.Entities.Subscription;

namespace TranslationPro.Base.Services;

public class SubscriptionService : BaseService<Subscription>, ISubscriptionService
{
    private readonly SessionService _sessionService;
    private readonly PaymentLinkService _paymentLinkService;
    private readonly IOptions<AppSettings> _settings;

    public SubscriptionService(IServiceProvider serviceProvider, 
        SessionService sessionService,
        PaymentLinkService paymentLinkService, IOptions<AppSettings> settings) : base(serviceProvider)
    {
        _sessionService = sessionService;
        _paymentLinkService = paymentLinkService;
        _settings = settings;
    }

    public async Task<T> GetSubscriptionAsync<T>(int userId) where T : SubscriptionOutput
    {
        var subscription = await Repository.Queryable().Where(x => x.UserId == userId).ProjectTo<T>(ProjectionMapping)
            .FirstOrDefaultAsync();

        return subscription;
    }

    public async Task<RedirectResult> CreateSubscription(int userId)
    {
        var retVal = new RedirectResult();

        var subscription = new Subscription()
        {
            UserId = userId,
            CharacterPrice = 0.0001m
        };

        var options = new PaymentLinkCreateOptions()
        {
            AfterCompletion = new PaymentLinkAfterCompletionOptions()
            {
                Redirect = new PaymentLinkAfterCompletionRedirectOptions()
                {
                    Url = _settings.Value.Stripe.PostCheckoutUrl
                },
                Type = "redirect"
            },
            LineItems = new List<PaymentLinkLineItemOptions>()
            {
                new PaymentLinkLineItemOptions()
                {
                    Price = _settings.Value.Stripe.PriceId,
                    Quantity = 1,
                }
            },
            SubscriptionData = new PaymentLinkSubscriptionDataOptions()
            {
                TrialPeriodDays = 30,
                Description = "$0.001 per translated character billed monthly"
            }
        };

        var stripeResult = await _paymentLinkService.CreateAsync(options);

        retVal.RedirectUrl = stripeResult.Url;

        subscription.PaymentLink = stripeResult.Url;

        var records = await Repository.InsertAsync(subscription, true);

        if (records > 0)
        {
            retVal.Succeeded = true;
        }

        return retVal;

    }

    public async Task<Result> CompleteSubscriptionCheckout(int userId, string checkoutSessionId)
    {
        var session = await _sessionService.GetAsync(checkoutSessionId);

        var subscription = await Repository.Queryable().Where(x => x.UserId == userId).FirstAsync();

        subscription.StripeId = session.PaymentIntentId;

        var records = Repository.Update(subscription, true);
        if (records > 0)
        {
            return Result.Success(userId);
        }

        return Result.Failed();
    }

    public async Task<Session> CreateCheckoutSession(int userId)
    {
        var options = new SessionCreateOptions()
        {
            UiMode = "embedded",
            LineItems = new List<SessionLineItemOptions>()
            {
                new SessionLineItemOptions()
                {
                    Price = _settings.Value.Stripe.PriceId
                }
            },
            Mode = "subscription",
            ReturnUrl = _settings.Value.Stripe.PostCheckoutUrl,

        };

        var session = await _sessionService.CreateAsync(options);

        return session;
    }
}