#region Header Info

// Copyright 2023 Rod Johnson.  All rights reserved

#endregion

using System;
using System.Linq;
using TranslationPro.Base.Entities;

namespace TranslationPro.Base.Extensions;

public static class PriceExtensions
{
    public static void Sync(this Price entity, Stripe.Price price)
    {
        entity.Id = price.Id;
        entity.Active = price.Active;
        entity.ProductId = price.ProductId;

        if (price.Tiers != null && price.Tiers.Any())
        {
            foreach (var tier in price.Tiers)
            {
                var existingTier = entity.Tiers.FirstOrDefault(x => x.FlatAmount == tier.FlatAmount
                                                                    && x.FlatAmountDecimal == tier.FlatAmountDecimal
                                                                    && x.UnitAmount == tier.UnitAmount
                                                                    && x.UnitAmountDecimal == tier.UnitAmountDecimal
                                                                    && x.UpTo == tier.UpTo);

                if (existingTier == null)
                {
                    entity.Tiers.Add(new PriceTier()
                    {
                        FlatAmount = tier.FlatAmount,
                        FlatAmountDecimal = tier.FlatAmountDecimal,
                        UnitAmount = tier.UnitAmount,
                        UnitAmountDecimal = tier.UnitAmountDecimal,
                        UpTo = tier.UpTo
                    });
                }

            }
        }
        
    }
}