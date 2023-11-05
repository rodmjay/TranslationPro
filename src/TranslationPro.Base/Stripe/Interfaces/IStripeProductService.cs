#region Header Info

// Copyright 2023 Rod Johnson.  All rights reserved

#endregion

using System.Threading.Tasks;
using Stripe;
using TranslationPro.Base.Common.Services.Interfaces;
using TranslationPro.Base.Stripe.Entities;
using TranslationPro.Shared.Common;

namespace TranslationPro.Base.Stripe.Interfaces;

public interface IStripeProductService : IService<StripeProduct>
{
    Task<Result> CreateProduct(ProductCreateOptions  options);
    Task<Result> DeleteProduct(ProductDeleteOptions  options);
    Task<Result> UpdateProduct(ProductUpdateOptions  options);
    Task<Result> HandleProductCreated(Product input);
    Task<Result> HandleProductDeleted(Product input);
    Task<Result> HandleProductUpdated(Product input);
}