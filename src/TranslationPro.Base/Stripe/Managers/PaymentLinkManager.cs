#region Header Info

// Copyright 2023 Rod Johnson.  All rights reserved

#endregion

using System;
using System.Threading.Tasks;
using Stripe;
using TranslationPro.Base.Stripe.Entities;
using TranslationPro.Base.Stripe.Extensions;
using TranslationPro.Shared.Common;

namespace TranslationPro.Base.Stripe.Managers;

public class PaymentLinkManager : StripeManager<StripePaymentLink>, IPaymentLinkManager
{
    protected readonly PaymentLinkService PaymentLinkService;

    public PaymentLinkManager(IServiceProvider serviceProvider, PaymentLinkService paymentLinkService) : base(serviceProvider)
    {
        PaymentLinkService = paymentLinkService;
    }

    public async Task<Result> CreatePaymentLink(int userId, PaymentLinkCreateOptions options)
    {
        options.AddUserIdToMetadata(userId);

        var paymentLink = await PaymentLinkService.CreateAsync(options);

        if (paymentLink != null)
        {
            return !StripeSettings.UseWebHooks
                ? await HandlePaymentLinkCreated(paymentLink)
                : Result.Success(paymentLink.Url);
        }

        return Result.Failed();
    }

    public async Task<Result> HandlePaymentLinkCreated(PaymentLink input)
    {
        var paymentLink = Mapper.Map<StripePaymentLink>(input);

        var userId = input.GetUserIdFromMetadata();

        Repository.Attach(paymentLink);

        var records = await Repository.InsertAsync(paymentLink, true);
        if (records > 0)
        {
            return Result.Success(paymentLink.Url);
        }
        return Result.Failed();
    }
}