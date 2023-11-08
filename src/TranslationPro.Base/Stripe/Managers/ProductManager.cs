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

public class ProductManager : StripeManager<StripeProduct>, IProductManager
{
    protected readonly ProductService ProductService;
    public ProductManager(IServiceProvider serviceProvider, ProductService productService) : base(serviceProvider)
    {
        ProductService = productService;
    }

    public async Task<Result> CreateProduct(ProductCreateOptions options)
    {
        var product = await ProductService.CreateAsync(options);

        if (product != null)
        {
            return Result.Success();
        }

        return Result.Failed();
    }

    public async Task<Result> DeleteProduct(string productId, ProductDeleteOptions options)
    {
        var product = await ProductService.DeleteAsync(productId, options);

        if (product != null)
        {
            return Result.Success();
        }

        return Result.Failed();
    }

    public async Task<Result> UpdateProduct(string productId, ProductUpdateOptions options)
    {
        var product = await ProductService.UpdateAsync(productId, options);

        if (product != null)
        {
            return Result.Success();
        }

        return Result.Failed();
    }

    public Task<Result> HandleProductCreated(Product input)
    {
        var product = Mapper.Map<StripeProduct>(input);

        product.ObjectState = ObjectState.Added;

        var records = Repository.InsertOrUpdateGraph(product, true);
        if (records > 0)
        {
            return Task.FromResult(Result.Success());
        }

        return Task.FromResult(Result.Failed());
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