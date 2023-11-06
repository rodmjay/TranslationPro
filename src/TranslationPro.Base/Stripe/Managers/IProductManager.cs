#region Header Info

// Copyright 2023 Rod Johnson.  All rights reserved

#endregion

using System.Threading.Tasks;
using Stripe;
using TranslationPro.Base.Common.Services.Interfaces;
using TranslationPro.Base.Stripe.Entities;
using TranslationPro.Shared.Common;

namespace TranslationPro.Base.Stripe.Managers;

public interface IProductManager : IService<StripeProduct>
{
    Task<Result> CreateProduct(ProductCreateOptions options);
    Task<Result> DeleteProduct(string productId, ProductDeleteOptions options);
    Task<Result> UpdateProduct(string productId, ProductUpdateOptions options);
    Task<Result> HandleProductCreated(Product input);
    Task<Result> HandleProductDeleted(Product input);
    Task<Result> HandleProductUpdated(Product input);
}