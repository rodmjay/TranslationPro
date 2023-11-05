#region Header Info

// Copyright 2023 Rod Johnson.  All rights reserved

#endregion

using System;
using Microsoft.Extensions.DependencyInjection;
using Stripe;
using TranslationPro.Base.Common.Data.Interfaces;
using TranslationPro.Base.Common.Services.Bases;

namespace TranslationPro.Base.Stripe.Services;

public abstract class StripeService<TEntity> : BaseService<TEntity> where TEntity : class, IObjectState
{
    protected IStripeClient StripeClient;
    protected StripeService(IServiceProvider serviceProvider) : base(serviceProvider)
    {
        StripeClient = serviceProvider.GetRequiredService<IStripeClient>();
    }
}