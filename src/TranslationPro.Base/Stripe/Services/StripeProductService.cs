#region Header Info

// Copyright 2023 Rod Johnson.  All rights reserved

#endregion

using System;
using System.Threading.Tasks;
using Stripe;
using TranslationPro.Base.Stripe.Entities;
using TranslationPro.Base.Stripe.Interfaces;
using TranslationPro.Shared.Common;

namespace TranslationPro.Base.Stripe.Services;

public class StripeProductService : StripeService<StripeProduct>, IStripeProductService
{
    public StripeProductService(IServiceProvider serviceProvider) : base(serviceProvider)
    {
    }

    public Task<Result> CreateProduct(ProductCreateOptions options)
    {
        throw new NotImplementedException();
    }

    public async Task<Result> DeleteProduct(ProductDeleteOptions options)
    {
        throw new NotImplementedException();
    }

    public async Task<Result> UpdateProduct(ProductUpdateOptions options)
    {
        throw new NotImplementedException();
    }

    public async Task<Result> HandleProductCreated(Product input)
    {
        throw new NotImplementedException();
    }

    public async Task<Result> HandleProductDeleted(Product input)
    {
        throw new NotImplementedException();
    }

    public async Task<Result> HandleProductUpdated(Product input)
    {
        throw new NotImplementedException();
    }
}