#region Header Info

// Copyright 2023 Rod Johnson.  All rights reserved

#endregion

using System.Threading.Tasks;
using Stripe;
using TranslationPro.Base.Common.Services.Interfaces;
using TranslationPro.Base.Stripe.Entities;
using TranslationPro.Shared.Common;

namespace TranslationPro.Base.Stripe.Managers;

public interface ICardManager : IService<StripeCard>
{
    Task<Result> CreateCard(string customerId, CardCreateOptions options);
    Task<Result> UpdateCard(string customerId, string cardId, CardUpdateOptions options);
    Task<Result> Delete(string customerId, string cardId, CardDeleteOptions options);

    Task<Result> HandleCardCreated(Card input);
    Task<Result> HandleCardUpdated(Card input);
    Task<Result> HandleCardDeleted(Card input);
}