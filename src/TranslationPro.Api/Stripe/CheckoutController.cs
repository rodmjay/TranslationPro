#region Header Info

// Copyright 2023 Rod Johnson.  All rights reserved

#endregion

using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Stripe.Checkout;
using TranslationPro.Base.Common.Middleware.Bases;
using TranslationPro.Base.Common.Settings;
using TranslationPro.Shared.Stripe;

namespace TranslationPro.Api.Stripe;

public class CheckoutController : BaseController
{
    private readonly SessionService _sessionService;
    private readonly AppSettings _settings;

    protected CheckoutController(IServiceProvider serviceProvider, SessionService sessionService, AppSettings settings) : base(serviceProvider)
    {
        _sessionService = sessionService;
        _settings = settings;
    }

    [HttpPost]
    public ActionResult Create([FromBody]CheckoutOptions input)
    {
        var domain = _settings.AppUrl;

        var lineItems = input.Prices.Select(x => new SessionLineItemOptions()
        {
            Price = x,
            Quantity = 1
        }).ToList();

        var options = new SessionCreateOptions()
        {
            UiMode = "embedded",
            LineItems = lineItems,
            Mode = "payment",
            ReturnUrl = domain + "/return/?session_id={CHECKOUT_SESSION_ID}",
            AutomaticTax = new SessionAutomaticTaxOptions() { Enabled = true }
        };

        Session session = _sessionService.Create(options);

        return new JsonResult(new
        {
            clientSecret = session.ClientSecret
        });
    }
}