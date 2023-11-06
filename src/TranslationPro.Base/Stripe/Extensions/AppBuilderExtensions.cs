using Microsoft.Extensions.DependencyInjection;
using Stripe;
using Stripe.Checkout;
using TranslationPro.Base.Common.Middleware.Builders;
using TranslationPro.Base.Stripe.Config;
using TranslationPro.Base.Stripe.Factories;
using TranslationPro.Base.Stripe.Managers;

namespace TranslationPro.Base.Stripe.Extensions
{
    public static class AppBuilderExtensions
    {
        public static AppBuilder AddStripeDependencies(this AppBuilder builder)
        {
            builder.Services.AddTransient(x => builder.AppSettings.Stripe);

            builder.Services.AddSingleton<IStripeClient>(
                provider => StripeClientFactory.GetFromSettings(builder.AppSettings.Stripe));

            builder.Services.AddScoped(x => new ChargeService(x.GetRequiredService<IStripeClient>()));
            builder.Services.AddScoped(x => new CustomerService(x.GetRequiredService<IStripeClient>()));
            builder.Services.AddScoped(x => new DiscountService(x.GetRequiredService<IStripeClient>()));
            builder.Services.AddScoped(x => new CustomerService(x.GetRequiredService<IStripeClient>()));
            builder.Services.AddScoped(x => new InvoiceService(x.GetRequiredService<IStripeClient>()));
            builder.Services.AddScoped(x => new PaymentIntentService(x.GetRequiredService<IStripeClient>()));
            builder.Services.AddScoped(x => new PaymentLinkService(x.GetRequiredService<IStripeClient>()));
            builder.Services.AddScoped(x => new PaymentMethodService(x.GetRequiredService<IStripeClient>()));
            builder.Services.AddScoped(x => new PriceService(x.GetRequiredService<IStripeClient>()));
            builder.Services.AddScoped(x => new ProductService(x.GetRequiredService<IStripeClient>()));
            builder.Services.AddScoped(x => new PromotionCodeService(x.GetRequiredService<IStripeClient>()));
            builder.Services.AddScoped(x => new RefundService(x.GetRequiredService<IStripeClient>()));
            builder.Services.AddScoped(x => new SubscriptionScheduleService(x.GetRequiredService<IStripeClient>()));
            builder.Services.AddScoped(x => new SubscriptionService(x.GetRequiredService<IStripeClient>()));
            builder.Services.AddScoped(x => new PayoutService(x.GetRequiredService<IStripeClient>()));
            builder.Services.AddScoped(x => new WebhookEndpointService(x.GetRequiredService<IStripeClient>()));

            builder.Services.AddScoped(x => new AccountLinkService(x.GetRequiredService<IStripeClient>()));
            builder.Services.AddScoped(x => new AccountSessionService(x.GetRequiredService<IStripeClient>()));
            builder.Services.AddScoped(x => new AccountService(x.GetRequiredService<IStripeClient>()));
            builder.Services.AddScoped(x => new BalanceTransactionService(x.GetRequiredService<IStripeClient>()));
            builder.Services.AddScoped(x => new BalanceService(x.GetRequiredService<IStripeClient>()));
            builder.Services.AddScoped(x => new BankAccountService(x.GetRequiredService<IStripeClient>()));
            builder.Services.AddScoped(x => new CapabilityService(x.GetRequiredService<IStripeClient>()));
            builder.Services.AddScoped(x => new CardService(x.GetRequiredService<IStripeClient>()));
            builder.Services.AddScoped(x => new CashBalanceService(x.GetRequiredService<IStripeClient>()));
            builder.Services.AddScoped(x => new CreditNoteService(x.GetRequiredService<IStripeClient>()));
            builder.Services.AddScoped(x => new CustomerBalanceTransactionService(x.GetRequiredService<IStripeClient>()));
            builder.Services.AddScoped(x => new DisputeService(x.GetRequiredService<IStripeClient>()));
            builder.Services.AddScoped(x => new InvoiceItemService(x.GetRequiredService<IStripeClient>()));
            builder.Services.AddScoped(x => new PaymentMethodConfigurationService(x.GetRequiredService<IStripeClient>()));
            builder.Services.AddScoped(x => new SetupIntentService(x.GetRequiredService<IStripeClient>()));
            builder.Services.AddScoped(x => new TransferService(x.GetRequiredService<IStripeClient>()));
            builder.Services.AddScoped(x => new SessionService(x.GetRequiredService<IStripeClient>()));
            builder.Services.AddScoped(x => new CouponService(x.GetRequiredService<IStripeClient>()));


            builder.Services.AddScoped<ICustomerManager, CustomerManager>();
            builder.Services.AddScoped<ICouponManager, CouponManager>();
            builder.Services.AddScoped<IChargeManager, ChargeManager>();
            builder.Services.AddScoped<IInvoiceManager, InvoiceManager>();
            builder.Services.AddScoped<IPaymentIntentManager, PaymentIntentManager>();
            builder.Services.AddScoped<IPaymentMethodManager, PaymentMethodManager>();
            builder.Services.AddScoped<IPriceManager, PriceManager>();
            builder.Services.AddScoped<IProductManager, ProductManager>();
            builder.Services.AddScoped<IPromotionCodeManager, PromotionCodeManager>();
            builder.Services.AddScoped<IRefundManager, RefundManager>();
            builder.Services.AddScoped<IScheduleManager, ScheduleManager>();
            builder.Services.AddScoped<ISubscriptionManager, SubscriptionManager>();
            builder.Services.AddScoped<IDiscountManager, DiscountManager>();
            builder.Services.AddScoped<ICardManager, CardManager>();
            builder.Services.AddScoped<IPaymentLinkManager, PaymentLinkManager>();


            return builder;
        }
    }
}
