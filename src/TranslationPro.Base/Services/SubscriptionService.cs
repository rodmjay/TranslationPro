#region Header Info

// Copyright 2023 Rod Johnson.  All rights reserved

#endregion

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using Stripe;
using Stripe.Checkout;
using TranslationPro.Base.Common.Data.Interfaces;
using TranslationPro.Base.Common.Services.Bases;
using TranslationPro.Base.Settings;
using TranslationPro.Base.Users.Entities;
using TranslationPro.Shared.Common;
using Subscription = TranslationPro.Base.Entities.Subscription;

namespace TranslationPro.Base.Services;

public class SubscriptionService : BaseService<Subscription>, ISubscriptionService
{
    private readonly SessionService _sessionService;
    private readonly CustomerService _customerService;
    private readonly Stripe.SubscriptionService _subscriptionService;
    private readonly PaymentLinkService _paymentLinkService;
    private readonly IOptions<AppSettings> _settings;
    private readonly IRepositoryAsync<User> _userRepository;

    public SubscriptionService(IServiceProvider serviceProvider, 
        SessionService sessionService,
        CustomerService customerService,
        Stripe.SubscriptionService subscriptionService,
        PaymentLinkService paymentLinkService, IOptions<AppSettings> settings) : base(serviceProvider)
    {
        _sessionService = sessionService;
        _customerService = customerService;
        _subscriptionService = subscriptionService;
        _paymentLinkService = paymentLinkService;
        _settings = settings;
        _userRepository = UnitOfWork.RepositoryAsync<User>();
    }

    private IQueryable<User> Users => _userRepository.Queryable();

    public async Task<Stripe.Subscription> GetSubscriptionAsync(int userId)
    {
        var subscription = await Repository.Queryable().Where(x => x.UserId == userId)
            .FirstAsync();

        var subId = subscription.SubscriptionId;

        var sub = await _subscriptionService.GetAsync(subId);

        return sub;
    }

    public async Task<Result> CompleteSubscriptionCheckout(int userId, string checkoutSessionId)
    {
        var session = await _sessionService.GetAsync(checkoutSessionId);

        var subscription = new Subscription
        {
            UserId = userId,
            CharacterPrice = 0.01m,
            CustomerId = session.CustomerId,
            SubscriptionId = session.SubscriptionId
        };

        var records = Repository.Insert(subscription, true);
        if (records > 0)
        {
            return Result.Success(userId);
        }

        return Result.Failed();
    }

    public async Task<Session> CreateCheckoutSession(int userId)
    {
        var user = await Users.Where(x=>x.Id == userId).FirstAsync();

        if (user.CustomerId == null)
        {
            var customerOptions = new CustomerCreateOptions()
            {
                Name = user.FullName,
                Email = user.Email,
            };

            var customer = await _customerService.CreateAsync(customerOptions);

            user.CustomerId = customer.Id;

            _userRepository.Update(user, true);
        }

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
            Customer = user.CustomerId,
            Mode = "subscription",
            ReturnUrl = _settings.Value.Stripe.PostCheckoutUrl
        };

        var session = await _sessionService.CreateAsync(options);

        return session;
    }
}