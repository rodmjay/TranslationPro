using System;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper.QueryableExtensions;
using Microsoft.EntityFrameworkCore;
using Stripe;
using TranslationPro.Base.Common.Data.Enums;
using TranslationPro.Base.Common.Data.Interfaces;
using TranslationPro.Base.Stripe.Entities;
using TranslationPro.Base.Stripe.Extensions;
using TranslationPro.Base.Users.Entities;
using TranslationPro.Shared.Common;

namespace TranslationPro.Base.Stripe.Managers
{
    public class CustomerManager : StripeManager<StripeCustomer>, ICustomerManager
    {
        protected readonly CustomerService CustomerService;

        private IQueryable<StripeCustomer> Customers => Repository.Queryable().Include(x => x.User);

        public CustomerManager(IServiceProvider serviceProvider, CustomerService customerService) : base(serviceProvider)
        {
            CustomerService = customerService;
        }

        public async Task<Result> CreateCustomer(int userId, CustomerCreateOptions options)
        {
            options.AddUserIdToMetadata(userId);

            var customer = await CustomerService.CreateAsync(options);
            if (customer != null)
            {
                return Result.Success(customer.Id);
            }
            return Result.Failed();
        }

        public async Task<Result> UpdateCustomer(string customerId, CustomerUpdateOptions options)
        {

            var customer = await CustomerService.UpdateAsync(customerId, options);
            if (customer != null)
            {
                return Result.Success(customer.Id);
            }
            return Result.Failed();
        }

        public async Task<Result> DeleteCustomer(string customerId, CustomerDeleteOptions options)
        {
            var customer = await CustomerService.DeleteAsync(customerId, options);
            if (customer != null)
            {
                return Result.Success(customer.Id);
            }
            return Result.Failed();
        }

        public async Task<Customer> GetCustomerById(int userId)
        {
            var customer = await Customers.Where(x=>x.UserId == userId)
                .ProjectTo<Customer>(ProjectionMapping)
                .FirstOrDefaultAsync();

            return customer;
        }

        public async Task<Customer> GetCustomer(string customerId, CustomerGetOptions options = null)
        {
            var service = new CustomerService(StripeClient);
            return await service.GetAsync(customerId, options);
        }

        public Task<Result> HandleCustomerCreated(Customer input)
        {
            var customer = Mapper.Map<StripeCustomer>(input);

            var userId = input.GetUserIdFromMetadata();

            customer.UserId = userId;
            customer.ObjectState = ObjectState.Added;

            var records = Repository.InsertOrUpdateGraph(customer, true);
            if (records > 0)
            {
                return Task.FromResult(Result.Success(userId));
            }

            return Task.FromResult(Result.Failed());
        }

        public Task<Result> HandleCustomerUpdated(Customer input)
        {
            var customer = Mapper.Map<StripeCustomer>(input);

            var userId = input.GetUserIdFromMetadata();

            customer.ObjectState = ObjectState.Modified;

            var records = Repository.InsertOrUpdateGraph(customer, true);
            if (records > 0)
            {
                return Task.FromResult(Result.Success(userId));
            }

            return Task.FromResult(Result.Failed());
        }

        public async Task<Result> HandleCustomerDeleted(Customer input)
        {
            var succeeded = await Repository.DeleteAsync(x => x.Id == input.Id, true);
            if (succeeded)
            {
                return Result.Success();
            }

            return Result.Failed();
        }

        public async Task<Result> HandleCustomerDiscountCreated(Discount input)
        {
            throw new NotImplementedException();
        }

        public async Task<Result> HandleCustomerDiscountDeleted(Discount input)
        {
            throw new NotImplementedException();
        }

        public async Task<Result> HandleCustomerSourceCreated(Card card)
        {
            throw new NotImplementedException();
        }

    }
}
