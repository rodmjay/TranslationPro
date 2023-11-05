using System;
using System.Threading.Tasks;
using Stripe;
using TranslationPro.Base.Common.Data.Enums;
using TranslationPro.Base.Stripe.Entities;
using TranslationPro.Base.Stripe.Extensions;
using TranslationPro.Base.Stripe.Interfaces;
using TranslationPro.Shared.Common;

namespace TranslationPro.Base.Stripe.Services
{
    public class StripeCustomerService : StripeService<StripeCustomer>, IStripeCustomerService
    {
        private const string USERID = "UserId";
        public StripeCustomerService(IServiceProvider serviceProvider) : base(serviceProvider)
        {
        }

        public async Task<Result> CreateCustomer(int userId, CustomerCreateOptions options)
        {
            options.AddUserIdToMetadata(userId);

            var service = new CustomerService(this.StripeClient);

            var apiCustomer = await service.CreateAsync(options);

            return Result.Success(apiCustomer);
        }
        
        public async Task<Customer> GetCustomer(string customerId, CustomerGetOptions options = null)
        {
            var service = new CustomerService(this.StripeClient);
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
