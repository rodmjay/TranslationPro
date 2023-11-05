using Microsoft.Extensions.DependencyInjection;
using Stripe;
using TranslationPro.Base.Common.Middleware.Builders;
using TranslationPro.Base.Stripe.Factories;
using TranslationPro.Base.Stripe.Interfaces;
using TranslationPro.Base.Stripe.Managers;
using TranslationPro.Base.Stripe.Services;

namespace TranslationPro.Base.Stripe.Extensions
{
    public static class AppBuilderExtensions
    {
        public static AppBuilder AddStripeDependencies(this AppBuilder builder)
        {
            builder.Services.AddScoped<IStripeCustomerService, StripeCustomerService>();
            builder.Services.AddScoped<IStripeCouponService, StripeCouponService>();
            builder.Services.AddScoped<IStripeChargeService, StripeChargeService>();
            builder.Services.AddScoped<IStripeInvoiceService, StripeInvoiceService>();
            builder.Services.AddScoped<IStripePaymentIntentService, StripePaymentIntentService>();
            builder.Services.AddScoped<IStripePaymentMethodService, StripePaymentMethodService>();
            builder.Services.AddScoped<IStripePriceService, StripePriceService>();
            builder.Services.AddScoped<IStripeProductService, StripeProductService>();
            builder.Services.AddScoped<IStripePromotionCodeService, StripePromotionCodeService>();
            builder.Services.AddScoped<IStripeRefundService, StripeRefundService>();
            builder.Services.AddScoped<IStripeScheduleService, StripeScheduleService>();
            builder.Services.AddScoped<IStripeSubscriptionService, StripeSubscriptionService>();
            builder.Services.AddScoped<IStripeDiscountService, StripeDiscountService>();

            builder.Services.AddScoped<StripeManager>();

            builder.Services.AddSingleton<IStripeClient>(
                provider => StripeClientFactory.GetFromSettings(builder.AppSettings.Stripe));

            return builder;
        }
    }
}
