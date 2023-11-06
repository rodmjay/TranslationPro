using System.Threading.Tasks;
using Stripe;
using TranslationPro.Base.Common.Services.Interfaces;
using TranslationPro.Base.Stripe.Entities;
using TranslationPro.Shared.Common;

namespace TranslationPro.Base.Stripe.Managers;

public interface IDiscountManager : IService<StripeDiscount>
{
    Task<Result> HandleCustomerDiscountCreated(Discount deserialize);
    Task<Result> HandleCustomerDiscountDeleted(Discount deserialize);
    Task<Result> HandleCustomerDiscountUpdated(Discount deserialize);
}