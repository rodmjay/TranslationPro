#region Header Info

// Copyright 2023 Rod Johnson.  All rights reserved

#endregion

using TranslationPro.Base.Entities;

namespace TranslationPro.Base.Extensions;

public static class ProductExtensions
{
    public static void Sync(this Product entity, Stripe.Product product)
    {
        entity.Id = product.Id;
        entity.Description = product.Description;
        entity.Name = product.Name;
        entity.Type = product.Type;
    }
}