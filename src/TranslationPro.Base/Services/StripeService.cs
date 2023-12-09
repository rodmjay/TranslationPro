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
using TranslationPro.Base.Common.Data.Enums;
using TranslationPro.Base.Common.Data.Interfaces;
using TranslationPro.Base.Common.Services.Bases;
using TranslationPro.Base.Entities;
using TranslationPro.Base.Extensions;
using TranslationPro.Base.Settings;
using TranslationPro.Base.Users.Entities;
using TranslationPro.Shared.Common;
using TranslationPro.Shared.Models;
using ProductService = Stripe.ProductService;
using Subscription = TranslationPro.Base.Entities.Subscription;

namespace TranslationPro.Base.Services;

public class StripeService : BaseService, IStripeService
{
    private StripeSettings _settings;
    private readonly IRepositoryAsync<Subscription> _subscriptionRepository;
    private readonly IRepositoryAsync<User> _userRepository;
    private readonly IRepositoryAsync<Entities.Price> _priceRepository;
    private readonly IRepositoryAsync<Entities.Product> _productRepository;
    private readonly IRepositoryAsync<Entities.Plan> _planRepository;

    private readonly ProductService _productService;
    private readonly PriceService _priceService;
    private readonly SessionService _sessionService;
    private readonly CustomerService _customerService;
    private readonly PlanService _planService;
    private readonly InvoiceService _invoiceService;
    private readonly SubscriptionService _subscriptionService;

    public StripeService(IServiceProvider serviceProvider,
        IOptions<AppSettings> settings,
        ProductService productService,
        PriceService priceService,
        SessionService sessionService,
        CustomerService customerService,
        PlanService planService,
        InvoiceService invoiceService,
        SubscriptionService subscriptionService) : base(serviceProvider)
    {
        _productService = productService;
        _priceService = priceService;
        _sessionService = sessionService;
        _customerService = customerService;
        _planService = planService;
        _invoiceService = invoiceService;
        _subscriptionService = subscriptionService;
        _settings = settings.Value.Stripe;
        _subscriptionRepository = UnitOfWork.RepositoryAsync<Subscription>();
        _userRepository = UnitOfWork.RepositoryAsync<User>();
        _priceRepository = UnitOfWork.RepositoryAsync<Entities.Price>();
        _productRepository = UnitOfWork.RepositoryAsync<Entities.Product>();
        _planRepository = UnitOfWork.RepositoryAsync<Entities.Plan>();
    }
    private IQueryable<User> Users => _userRepository.Queryable();
    
    public void Initialize()
    {
        var internalPrice = _priceRepository.Queryable().FirstOrDefault(x => x.Id == _settings.PriceId);
        var stripePrice = _priceService.Get(_settings.PriceId);
        var productId = stripePrice.ProductId;
        var stripeProduct = _productService.Get(productId);

        

        var internalProduct = _productRepository.Queryable().FirstOrDefault(x => x.Id == productId);
        if (internalProduct != null)
        {
            internalProduct.Sync(stripeProduct);
            _productRepository.Update(internalProduct, true);
        }
        else
        {
            internalProduct = new Entities.Product();
            internalProduct.Sync(stripeProduct);
            _productRepository.Insert(internalProduct, true);
        }
        if (internalPrice != null)
        {
            internalPrice.Sync(stripePrice);
            _priceRepository.Update(internalPrice, true);
        }
        else
        {
            internalPrice = new Entities.Price();
            internalPrice.Sync(stripePrice);
            _priceRepository.Insert(internalPrice, true);
        }

        
        var plans = _planService.List(new PlanListOptions()
        {
            Product = productId
        });
        var planEntities = _planRepository.Queryable().Where(x => x.ProductId == productId).ToList();

        foreach (var plan in plans)
        {
            var existingPlan = planEntities.FirstOrDefault(x => x.Id == plan.Id);
            if (existingPlan == null)
            {
                existingPlan = new Entities.Plan();
                existingPlan.Sync(plan);
                _planRepository.Insert(existingPlan, true);
            }
            else
            {
                existingPlan.Sync(plan);
                _planRepository.Update(existingPlan, true);
            }
        }

    }

    public async Task<T> GetSubscriptionAsync<T>(int userId) where T : SubscriptionOutput
    {
        var subscription = await _subscriptionRepository
            .Queryable()
            .Include(x=>x.Items)
            .Include(x=>x.Invoices)
            .ThenInclude(x=>x.Lines)
            .Where(x => x.UserId == userId)
            .FirstAsync();

        var subId = subscription.SubscriptionId;

        var sub = await _subscriptionService.GetAsync(subId);

        subscription.Sync(sub, userId);
        subscription.ObjectState = ObjectState.Modified;

        var invoices = await _invoiceService.ListAsync(new InvoiceListOptions()
        {
            Subscription = subId
        });

        foreach (var invoice in subscription.Invoices)
        {
            invoice.ObjectState = ObjectState.Deleted;
        }

        foreach (var invoice in invoices)
        {
            var existingInvoice = subscription.Invoices.FirstOrDefault(x => x.Id == invoice.Id);

            if (existingInvoice == null)
            {
                existingInvoice = new Entities.Invoice();
                existingInvoice.Sync(invoice, userId);
                existingInvoice.ObjectState = ObjectState.Added;

                subscription.Invoices.Add(existingInvoice);
            }
            else
            {
                existingInvoice.Sync(invoice,userId);
                existingInvoice.ObjectState = ObjectState.Modified;
            }

            foreach (var existingLine in existingInvoice.Lines)
            {
                existingLine.ObjectState = ObjectState.Deleted;
            }
            foreach (var line in invoice.Lines)
            {


                var existingLine = existingInvoice.Lines.FirstOrDefault(x => x.Id == line.Id);

                if (existingLine == null)
                {
                    existingLine = new InvoiceLine();
                    existingLine.Sync(line,invoice.Id);
                    existingLine.ObjectState = ObjectState.Added;
                    existingInvoice.Lines.Add(existingLine);
                }
                else
                {
                    existingLine.Sync(line, invoice.Id);
                    existingLine.ObjectState = ObjectState.Modified;
                }
            }
        }

        _subscriptionRepository.InsertOrUpdateGraph(subscription, true);

        var output = await _subscriptionRepository
            .Queryable().Where(x=>x.UserId == userId)
            .ProjectTo<T>(ProjectionMapping).FirstAsync();

        return output;
    }

    public async Task<Result> CompleteSubscriptionCheckout(int userId, string checkoutSessionId)
    {
        var session = await _sessionService.GetAsync(checkoutSessionId);

        var stripeSubscription = await _subscriptionService.GetAsync(session.SubscriptionId);

        var subscription = new Subscription();
        subscription.Sync(stripeSubscription, userId);

        var records = _subscriptionRepository.InsertOrUpdateGraph(subscription, true);
        if (records > 0)
            return Result.Success(userId);

        return Result.Failed();
    }

    public async Task<Session> CreateCheckoutSession(int userId)
    {
        var user = await Users.Where(x => x.Id == userId).FirstAsync();

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
                new()
                {
                    Price = _settings.PriceId
                }
            },
            Customer = user.CustomerId,
            Mode = "subscription",
            ReturnUrl = _settings.PostCheckoutUrl
        };

        var session = await _sessionService.CreateAsync(options);

        return session;
    }
}
