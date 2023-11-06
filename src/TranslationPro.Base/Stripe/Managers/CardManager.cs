#region Header Info

// Copyright 2023 Rod Johnson.  All rights reserved

#endregion

using System;
using System.Threading.Tasks;
using Stripe;
using TranslationPro.Base.Common.Data.Enums;
using TranslationPro.Base.Stripe.Entities;
using TranslationPro.Shared.Common;

namespace TranslationPro.Base.Stripe.Managers;

public class CardManager : StripeManager<StripeCard>, ICardManager
{
    protected readonly CardService CardService;

    public CardManager(IServiceProvider serviceProvider, CardService cardService) : base(serviceProvider)
    {
        CardService = cardService;
    }

    public async Task<Result> CreateCard(string customerId, CardCreateOptions options)
    {
        var card = await CardService.CreateAsync(customerId, options);
        if (card != null)
        {
            return Result.Success(card.Id);
        }

        return Result.Failed();
    }

    public async Task<Result> UpdateCard(string customerId, string cardId, CardUpdateOptions options)
    {
        var card = await CardService.UpdateAsync(customerId, cardId, options);
        if (card != null)
        {
            return Result.Success(card.Id);
        }

        return Result.Failed();
    }

    public async Task<Result> Delete(string customerId, string cardId, CardDeleteOptions options)
    {
        var card = await CardService.DeleteAsync(customerId, cardId, options);
        if (card != null)
        {
            return Result.Success(card.Id);
        }

        return Result.Failed();
    }

    public async Task<Result> HandleCardCreated(Card input)
    {
        var card = Mapper.Map<StripeCard>(input);
        card.ObjectState = ObjectState.Added;

        var records = await Repository.InsertAsync(card, true);
        if(records > 0)
            return Result.Success(card.Id);
        return Result.Failed();
    }

    public async Task<Result> HandleCardUpdated(Card input)
    {
        var card = Mapper.Map<StripeCard>(input);
        card.ObjectState = ObjectState.Added;

        var records = await Repository.InsertAsync(card, true);
        if (records > 0)
            return Result.Success(card.Id);
        return Result.Failed();
    }

    public async Task<Result> HandleCardDeleted(Card input)
    {
        var card = Mapper.Map<StripeCard>(input);
        card.ObjectState = ObjectState.Added;

        var success = await Repository.DeleteAsync(card, true);
        if (success)
            return Result.Success(card.Id);
        return Result.Failed();
    }
}