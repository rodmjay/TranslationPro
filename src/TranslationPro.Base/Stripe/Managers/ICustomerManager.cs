#region Header Info

// Copyright 2023 Rod Johnson.  All rights reserved

#endregion

using System.Threading.Tasks;
using Stripe;
using TranslationPro.Base.Common.Services.Interfaces;
using TranslationPro.Base.Stripe.Entities;
using TranslationPro.Shared.Common;

namespace TranslationPro.Base.Stripe.Managers;

public interface ICustomerManager : IService<StripeCustomer>
{
    Task<Result> CreateCustomer(int userId, CustomerCreateOptions options);
    Task<Result> UpdateCustomer(string customerId, CustomerUpdateOptions options);
    Task<Result> DeleteCustomer(string customerId, CustomerDeleteOptions options);
    Task<Result> HandleCustomerCreated(Customer input);
    Task<Result> HandleCustomerUpdated(Customer input);
    Task<Result> HandleCustomerDeleted(Customer input);
    Task<Result> HandleCustomerDiscountCreated(Discount input);
    Task<Result> HandleCustomerDiscountDeleted(Discount input);
    Task<Result> HandleCustomerSourceCreated(Card card);

    Task<Customer> GetCustomerById(int userId);
    Task<Customer> GetCustomer(string customerId, CustomerGetOptions options = null);
}