using System;
using System.Threading.Tasks;
using Stripe;
using TranslationPro.Base.Common.Services.Bases;
using TranslationPro.Base.Stripe.Entities;
using TranslationPro.Base.Stripe.Interfaces;
using TranslationPro.Shared.Common;

namespace TranslationPro.Base.Stripe.Services
{
    public class CustomerService : BaseService<StripeCustomer>, ICustomerService
    {
        public CustomerService(IServiceProvider serviceProvider) : base(serviceProvider)
        {
        }

        public Task<Result> CreateCustomer(int userId, Address address)
        {
            throw new NotImplementedException();
        }
    }
}
