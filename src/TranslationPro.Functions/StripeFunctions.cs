using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Extensions.Http;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using NuGet.Protocol;
using Stripe;
using TranslationPro.Base.Stripe;
using TranslationPro.Base.Stripe.Interfaces;
using TranslationPro.Shared.Common;
using TranslationPro.Base.Stripe.Extensions;
namespace TranslationPro.Functions
{
    public class StripeFunctions
    {
        private readonly IStripePaymentIntentService _stripePaymentIntentService;
        private readonly IStripeSubscriptionService _stripeSubscriptionService;
        private readonly IStripeInvoiceService _stripeInvoiceService;
        private readonly IStripeChargeService _stripeChargeService;
        private readonly IStripePaymentMethodService _stripePaymentMethodService;
        private readonly IStripePriceService _stripePriceService;
        private readonly IStripeProductService _stripeProductService;
        private readonly IStripeDiscountService _stripeDiscountService;
        private readonly IStripeCouponService _stripeCouponService;
        private readonly IStripeCustomerService _stripeCustomerService;

        

        public StripeFunctions(
            IStripePaymentIntentService stripePaymentIntentService,
            IStripeSubscriptionService stripeSubscriptionService,
            IStripeInvoiceService stripeInvoiceService,
            IStripeChargeService stripeChargeService,
            IStripePaymentMethodService stripePaymentMethodService,
            IStripePriceService stripePriceService,
            IStripeProductService stripeProductService,
            IStripeDiscountService stripeDiscountService,
            IStripeCouponService stripeCouponService,
            IStripeCustomerService stripeCustomerService)
        {
            _stripePaymentIntentService = stripePaymentIntentService;
            _stripeSubscriptionService = stripeSubscriptionService;
            _stripeInvoiceService = stripeInvoiceService;
            _stripeChargeService = stripeChargeService;
            _stripePaymentMethodService = stripePaymentMethodService;
            _stripePriceService = stripePriceService;
            _stripeProductService = stripeProductService;
            _stripeDiscountService = stripeDiscountService;
            _stripeCouponService = stripeCouponService;
            _stripeCustomerService = stripeCustomerService;
        }

        [FunctionName("StripeWebhooks")]
        public async Task<IActionResult> WebHooks(
            [HttpTrigger(AuthorizationLevel.Function, "post", Route = null)]
            HttpRequest req,
            ILogger log)
        {
            var result = Result.Failed();
            
            string requestBody = await new StreamReader(req.Body).ReadToEndAsync();
            var evt = Event.FromJson(requestBody);

            switch (evt.Type)
            {
                case EventNames.CustomerCreated:
                    result = await _stripeCustomerService.HandleCustomerCreated(evt.Deserialize<Customer>());
                    break;

                case EventNames.CustomerUpdated:
                    result = await _stripeCustomerService.HandleCustomerUpdated(evt.Deserialize<Customer>());
                    break;

                case EventNames.CustomerDeleted:
                    result = await _stripeCustomerService.HandleCustomerDeleted(evt.Deserialize<Customer>());
                    break;

                case EventNames.ChargeCreated:
                    result = await _stripeChargeService.HandleChargeCreated(evt.Deserialize<Charge>());
                    break;

                case EventNames.ChargeSucceeded:
                    result = await _stripeChargeService.HandleChargeCreated(evt.Deserialize<Charge>());
                    break;

                case EventNames.ChargeFailed:
                    result = await _stripeChargeService.HandleChargeFailed(evt.Deserialize<Charge>());
                    break;

                case EventNames.ChargeCaptured:
                    result = await _stripeChargeService.HandleChargeCaptured(evt.Deserialize<Charge>());
                    break;

                case EventNames.ChargeDisputeClosed:
                    result = await _stripeChargeService.HandleChargeDisputeClosed(evt.Deserialize<Dispute>());
                    break;

                case EventNames.ChargeDisputeCreated:
                    result = await _stripeChargeService.HandleChargeDisputeCreated(evt.Deserialize<Dispute>());
                    break;

                case EventNames.ChargeDisputeFundsReinstated:
                    result = await _stripeChargeService.HandleChargeDisputeFundsReinstated(evt.Deserialize<Dispute>());
                    break;

                case EventNames.ChargeDisputeFundsWithdrawn:
                    result = await _stripeChargeService.HandleChargeDisputeFundsWithdrawn(evt.Deserialize<Dispute>());
                    break;

                case EventNames.ChargeDisputeUpdated:
                    result = await _stripeChargeService.HandleChargeDisputeUpdated(evt.Deserialize<Dispute>());
                    break;

                case EventNames.ChargeExpired:
                    result = await _stripeChargeService.HandleChargeExpired(evt.Deserialize<Charge>());
                    break;

                case EventNames.ChargePending:
                    result = await _stripeChargeService.HandleChargePending(evt.Deserialize<Charge>());
                    break;

                case EventNames.ChargeRefundUpdated:
                    result = await _stripeChargeService.HandleChargeRefundUpdated(evt.Deserialize<Refund>());
                    break;

                case EventNames.ChargeRefunded:
                    result = await _stripeChargeService.HandleChargeRefunded(evt.Deserialize<Refund>());
                    break;

                case EventNames.ChargeUpdated:
                    result = await _stripeChargeService.HandleChargeExpired(evt.Deserialize<Charge>());
                    break;

                case EventNames.CouponCreated:
                    result = await _stripeCouponService.HandleCouponCreated(evt.Deserialize<Coupon>());
                    break;

                case EventNames.CouponDeleted:
                    result = await _stripeCouponService.HandleCouponDeleted(evt.Deserialize<Coupon>());

                    break;

                case EventNames.CustomerDiscountCreated:
                    result = await _stripeDiscountService.HandleCustomerDiscountCreated(evt.Deserialize<Discount>());
                    break;

                case EventNames.CustomerDiscountDeleted:
                    result = await _stripeDiscountService.HandleCustomerDiscountDeleted(evt.Deserialize<Discount>());
                    break;

                case EventNames.CustomerDiscountUpdated:
                    result = await _stripeDiscountService.HandleCustomerDiscountUpdated(evt.Deserialize<Discount>());
                    break;

                case EventNames.CustomerSourceCreated:

                    break;
                case EventNames.CustomerSourceDeleted:

                    break;
                case EventNames.CustomerSourceExpiring:

                    break;
                case EventNames.CustomerSourceUpdated:

                    break;

                case EventNames.CustomerSubscriptionCreated:
                    result = await _stripeSubscriptionService.HandleSubscriptionCreated(
                        evt.Deserialize<Subscription>());
                    break;

                case EventNames.CustomerSubscriptionDeleted:
                    result = await _stripeSubscriptionService.HandleSubscriptionDeleted(
                        evt.Deserialize<Subscription>());
                    break;

                case EventNames.CustomerSubscriptionPaused:
                    result = await _stripeSubscriptionService.HandleSubscriptionPaused(
                        evt.Deserialize<Subscription>());
                    break;

                case EventNames.CustomerSubscriptionTrialWillEnd:
                    result = await _stripeSubscriptionService.HandleSubscriptionTrialWillEnd(
                        evt.Deserialize<Subscription>());
                    break;

                case EventNames.CustomerSubscriptionUpdated:
                    result = await _stripeSubscriptionService.HandleSubscriptionUpdated(
                        evt.Deserialize<Subscription>());
                    break;

                case EventNames.InvoiceCreated:
                    result = await _stripeInvoiceService.HandleInvoiceCreated(evt.Deserialize<Invoice>());
                    break;

                case EventNames.InvoiceDeleted:
                    result = await _stripeInvoiceService.HandleInvoiceDeleted(evt.Deserialize<Invoice>());
                    break;

                case EventNames.InvoiceFinalized:
                    result = await _stripeInvoiceService.HandleInvoiceFinalized(evt.Deserialize<Invoice>());
                    break;

                case EventNames.InvoiceMarkedUncollectible:
                    result = await _stripeInvoiceService.HandleInvoiceMarkedUncollectible(evt.Deserialize<Invoice>());
                    break;

                case EventNames.InvoicePaid:
                    result = await _stripeInvoiceService.HandleInvoicePaid(evt.Deserialize<Invoice>());
                    break;

                case EventNames.InvoicePaymentActionRequired:
                    result = await _stripeInvoiceService.HandleInvoicePaymentActionRequired(evt.Deserialize<Invoice>());
                    break;

                case EventNames.InvoicePaymentFailed:
                    result = await _stripeInvoiceService.HandleInvoicePaymentFailed(evt.Deserialize<Invoice>());
                    break;

                case EventNames.InvoicePaymentSucceeded:
                    result = await _stripeInvoiceService.HandleInvoicePaymentSucceeded(evt.Deserialize<Invoice>());
                    break;

                case EventNames.InvoiceSent:
                    result = await _stripeInvoiceService.HandleInvoiceSent(evt.Deserialize<Invoice>());
                    break;

                case EventNames.InvoiceUpcoming:
                    result = await _stripeInvoiceService.HandleInvoiceUpcoming(evt.Deserialize<Invoice>());
                    break;

                case EventNames.InvoiceUpdated:
                    result = await _stripeInvoiceService.HandleInvoiceUpdated(evt.Deserialize<Invoice>());
                    break;

                case EventNames.InvoiceVoided:
                    result = await _stripeInvoiceService.HandleInvoiceVoided(evt.Deserialize<Invoice>());
                    break;

                case EventNames.InvoiceItemCreated:
                    result = await _stripeInvoiceService.HandleInvoiceItemCreated(evt.Deserialize<InvoiceItem>());
                    break;

                case EventNames.InvoiceItemDeleted:
                    result = await _stripeInvoiceService.HandleInvoiceItemDeleted(evt.Deserialize<InvoiceItem>());
                    break;

                case EventNames.PaymentIntentAmountCapturableUpdated:
                    result = await _stripePaymentIntentService.HandlePaymentIntentCapturableUpdated(
                        evt.Deserialize<PaymentIntent>());
                    break;

                case EventNames.PaymentIntentCanceled:
                    result = await _stripePaymentIntentService.HandlePaymentIntentCanceled(
                        evt.Deserialize<PaymentIntent>());
                    break;

                case EventNames.PaymentIntentCreated:
                    result = await _stripePaymentIntentService.HandlePaymentIntentCreated(
                        evt.Deserialize<PaymentIntent>());
                    break;

                case EventNames.PaymentIntentPartiallyFunded:
                    result = await _stripePaymentIntentService.HandlePaymentIntentPartiallyFunded(
                        evt.Deserialize<PaymentIntent>());
                    break;

                case EventNames.PaymentIntentPaymentFailed:
                    result = await _stripePaymentIntentService.HandlePaymentIntentPaymentFailed(
                        evt.Deserialize<PaymentIntent>());
                    break;

                case EventNames.PaymentIntentProcessing:
                    result = await _stripePaymentIntentService.HandlePaymentIntentProcessing(
                        evt.Deserialize<PaymentIntent>());
                    break;

                case EventNames.PaymentIntentRequiresAction:
                    result = await _stripePaymentIntentService.HandlePaymentRequiresAction(
                        evt.Deserialize<PaymentIntent>());
                    break;

                case EventNames.PaymentIntentSucceeded:
                    result = await _stripePaymentIntentService.HandlePaymentIntentSucceeded(
                        evt.Deserialize<PaymentIntent>());
                    break;

                case EventNames.PaymentMethodAttached:
                    await _stripePaymentMethodService.HandlePaymentMethodAttached(evt.Deserialize<PaymentMethod>());
                    break;

                case EventNames.PaymentMethodAutomaticallyUpdated:
                    await _stripePaymentMethodService.HandlePaymentMethodAutomaticallyUpdated(evt.Deserialize<PaymentMethod>());
                    break;

                case EventNames.PaymentMethodDetached:
                    await _stripePaymentMethodService.HandlePaymentMethodDetached(evt.Deserialize<PaymentMethod>());
                    break;

                case EventNames.PaymentMethodUpdated:
                    await _stripePaymentMethodService.HandlePaymentMethodUpdated(evt.Deserialize<PaymentMethod>());
                    break;

                case EventNames.PayoutCreated:
                    
                    break;
                case EventNames.PayoutFailed:
                    break;
                case EventNames.PayoutPaid:
                    break;
                case EventNames.PayoutReconciliationCompleted:
                    break;

                case EventNames.ProductCreated:
                    break;
                case EventNames.ProductDeleted:
                    break;
                case EventNames.ProductUpdated:
                    break;
                case EventNames.PriceCreated:
                    result =await _stripePriceService.HandlePriceCreated(evt.Deserialize<Price>());
                    break;
                case EventNames.PriceDeleted:
                    result = await _stripePriceService.HandlePriceDeleted(evt.Deserialize<Price>());
                    break;
                case EventNames.PriceUpdated:
                    result = await _stripePriceService.HandlePriceUpdated(evt.Deserialize<Price>());
                    break;
            }

            return new OkObjectResult(result);
        }
    }
}
