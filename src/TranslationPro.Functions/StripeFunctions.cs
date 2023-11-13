using System.IO;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Extensions.Http;
using Microsoft.Extensions.Logging;
using Stripe;
using TranslationPro.Base.Stripe;
using TranslationPro.Shared.Common;
using TranslationPro.Base.Stripe.Extensions;
using TranslationPro.Base.Stripe.Managers;

namespace TranslationPro.Functions
{
    public class StripeFunctions
    {
        private readonly IPaymentIntentManager _paymentIntentManager;
        private readonly ISubscriptionManager _subscriptionManager;
        private readonly ICardManager _cardManager;
        private readonly IInvoiceManager _invoiceManager;
        private readonly IChargeManager _chargeManager;
        private readonly IPaymentMethodManager _paymentMethodManager;
        private readonly IPromotionCodeManager _promotionCodeManager;
        private readonly IPriceManager _priceManager;
        private readonly IProductManager _productManager;
        private readonly IDiscountManager _discountManager;
        private readonly ICouponManager _couponManager;
        private readonly ICustomerManager _customerManager;

        

        public StripeFunctions(
            IPaymentIntentManager paymentIntentManager,
            ISubscriptionManager subscriptionManager,
            ICardManager cardManager,
            IInvoiceManager invoiceManager,
            IChargeManager chargeManager,
            IPaymentMethodManager paymentMethodManager,
            IPromotionCodeManager promotionCodeManager,
            IPriceManager priceManager,
            IProductManager productManager,
            IDiscountManager discountManager,
            ICouponManager couponManager,
            ICustomerManager customerManager)
        {
            _paymentIntentManager = paymentIntentManager;
            _subscriptionManager = subscriptionManager;
            _cardManager = cardManager;
            _invoiceManager = invoiceManager;
            _chargeManager = chargeManager;
            _paymentMethodManager = paymentMethodManager;
            _promotionCodeManager = promotionCodeManager;
            _priceManager = priceManager;
            _productManager = productManager;
            _discountManager = discountManager;
            _couponManager = couponManager;
            _customerManager = customerManager;
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
                case EventNames.CardCreated:
                    result = await _cardManager.HandleCardCreated(evt.Deserialize<Card>());
                    break;
                case EventNames.CardDeleted:
                    result = await _cardManager.HandleCardDeleted(evt.Deserialize<Card>());
                    break;
                case EventNames.CardUpdated:
                    result = await _cardManager.HandleCardUpdated(evt.Deserialize<Card>());
                    break;
                case EventNames.CustomerCreated:
                    result = await _customerManager.HandleCustomerCreated(evt.Deserialize<Customer>());
                    break;

                case EventNames.CustomerUpdated:
                    result = await _customerManager.HandleCustomerUpdated(evt.Deserialize<Customer>());
                    break;

                case EventNames.CustomerDeleted:
                    result = await _customerManager.HandleCustomerDeleted(evt.Deserialize<Customer>());
                    break;

                case EventNames.ChargeCreated:
                    result = await _chargeManager.HandleChargeCreated(evt.Deserialize<Charge>());
                    break;

                case EventNames.ChargeSucceeded:
                    result = await _chargeManager.HandleChargeCreated(evt.Deserialize<Charge>());
                    break;

                case EventNames.ChargeFailed:
                    result = await _chargeManager.HandleChargeFailed(evt.Deserialize<Charge>());
                    break;

                case EventNames.ChargeCaptured:
                    result = await _chargeManager.HandleChargeCaptured(evt.Deserialize<Charge>());
                    break;

                case EventNames.ChargeDisputeClosed:
                    result = await _chargeManager.HandleChargeDisputeClosed(evt.Deserialize<Dispute>());
                    break;

                case EventNames.ChargeDisputeCreated:
                    result = await _chargeManager.HandleChargeDisputeCreated(evt.Deserialize<Dispute>());
                    break;

                case EventNames.ChargeDisputeFundsReinstated:
                    result = await _chargeManager.HandleChargeDisputeFundsReinstated(evt.Deserialize<Dispute>());
                    break;

                case EventNames.ChargeDisputeFundsWithdrawn:
                    result = await _chargeManager.HandleChargeDisputeFundsWithdrawn(evt.Deserialize<Dispute>());
                    break;

                case EventNames.ChargeDisputeUpdated:
                    result = await _chargeManager.HandleChargeDisputeUpdated(evt.Deserialize<Dispute>());
                    break;

                case EventNames.ChargeExpired:
                    result = await _chargeManager.HandleChargeExpired(evt.Deserialize<Charge>());
                    break;

                case EventNames.ChargePending:
                    result = await _chargeManager.HandleChargePending(evt.Deserialize<Charge>());
                    break;

                case EventNames.ChargeRefundUpdated:
                    result = await _chargeManager.HandleChargeRefundUpdated(evt.Deserialize<Refund>());
                    break;

                case EventNames.ChargeRefunded:
                    result = await _chargeManager.HandleChargeRefunded(evt.Deserialize<Refund>());
                    break;

                case EventNames.ChargeUpdated:
                    result = await _chargeManager.HandleChargeExpired(evt.Deserialize<Charge>());
                    break;

                case EventNames.CouponCreated:
                    result = await _couponManager.HandleCouponCreated(evt.Deserialize<Coupon>());
                    break;

                case EventNames.CouponDeleted:
                    result = await _couponManager.HandleCouponDeleted(evt.Deserialize<Coupon>());
                    break;

                case EventNames.CustomerDiscountCreated:
                    result = await _discountManager.HandleCustomerDiscountCreated(evt.Deserialize<Discount>());
                    break;

                case EventNames.CustomerDiscountDeleted:
                    result = await _discountManager.HandleCustomerDiscountDeleted(evt.Deserialize<Discount>());
                    break;

                case EventNames.CustomerDiscountUpdated:
                    result = await _discountManager.HandleCustomerDiscountUpdated(evt.Deserialize<Discount>());
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
                    result = await _subscriptionManager.HandleSubscriptionCreated(
                        evt.Deserialize<Subscription>());
                    break;

                case EventNames.CustomerSubscriptionDeleted:
                    result = await _subscriptionManager.HandleSubscriptionDeleted(
                        evt.Deserialize<Subscription>());
                    break;

                case EventNames.CustomerSubscriptionPaused:
                    result = await _subscriptionManager.HandleSubscriptionPaused(
                        evt.Deserialize<Subscription>());
                    break;

                case EventNames.CustomerSubscriptionTrialWillEnd:
                    result = await _subscriptionManager.HandleSubscriptionTrialWillEnd(
                        evt.Deserialize<Subscription>());
                    break;

                case EventNames.CustomerSubscriptionUpdated:
                    result = await _subscriptionManager.HandleSubscriptionUpdated(
                        evt.Deserialize<Subscription>());
                    break;

                case EventNames.InvoiceCreated:
                    result = await _invoiceManager.HandleInvoiceCreated(evt.Deserialize<Invoice>());
                    break;

                case EventNames.InvoiceDeleted:
                    result = await _invoiceManager.HandleInvoiceDeleted(evt.Deserialize<Invoice>());
                    break;

                case EventNames.InvoiceFinalized:
                    result = await _invoiceManager.HandleInvoiceFinalized(evt.Deserialize<Invoice>());
                    break;

                case EventNames.InvoiceMarkedUncollectible:
                    result = await _invoiceManager.HandleInvoiceMarkedUncollectible(evt.Deserialize<Invoice>());
                    break;

                case EventNames.InvoicePaid:
                    result = await _invoiceManager.HandleInvoicePaid(evt.Deserialize<Invoice>());
                    break;

                case EventNames.InvoicePaymentActionRequired:
                    result = await _invoiceManager.HandleInvoicePaymentActionRequired(evt.Deserialize<Invoice>());
                    break;

                case EventNames.InvoicePaymentFailed:
                    result = await _invoiceManager.HandleInvoicePaymentFailed(evt.Deserialize<Invoice>());
                    break;

                case EventNames.InvoicePaymentSucceeded:
                    result = await _invoiceManager.HandleInvoicePaymentSucceeded(evt.Deserialize<Invoice>());
                    break;

                case EventNames.InvoiceSent:
                    result = await _invoiceManager.HandleInvoiceSent(evt.Deserialize<Invoice>());
                    break;

                case EventNames.InvoiceUpcoming:
                    result = await _invoiceManager.HandleInvoiceUpcoming(evt.Deserialize<Invoice>());
                    break;

                case EventNames.InvoiceUpdated:
                    result = await _invoiceManager.HandleInvoiceUpdated(evt.Deserialize<Invoice>());
                    break;

                case EventNames.InvoiceVoided:
                    result = await _invoiceManager.HandleInvoiceVoided(evt.Deserialize<Invoice>());
                    break;

                case EventNames.InvoiceItemCreated:
                    result = await _invoiceManager.HandleInvoiceItemCreated(evt.Deserialize<InvoiceItem>());
                    break;

                case EventNames.InvoiceItemDeleted:
                    result = await _invoiceManager.HandleInvoiceItemDeleted(evt.Deserialize<InvoiceItem>());
                    break;

                case EventNames.PaymentIntentAmountCapturableUpdated:
                    result = await _paymentIntentManager.HandlePaymentIntentCapturableUpdated(
                        evt.Deserialize<PaymentIntent>());
                    break;

                case EventNames.PaymentIntentCanceled:
                    result = await _paymentIntentManager.HandlePaymentIntentCanceled(
                        evt.Deserialize<PaymentIntent>());
                    break;

                case EventNames.PaymentIntentCreated:
                    result = await _paymentIntentManager.HandlePaymentIntentCreated(
                        evt.Deserialize<PaymentIntent>());
                    break;

                case EventNames.PaymentIntentPartiallyFunded:
                    result = await _paymentIntentManager.HandlePaymentIntentPartiallyFunded(
                        evt.Deserialize<PaymentIntent>());
                    break;

                case EventNames.PaymentIntentPaymentFailed:
                    result = await _paymentIntentManager.HandlePaymentIntentPaymentFailed(
                        evt.Deserialize<PaymentIntent>());
                    break;

                case EventNames.PaymentIntentProcessing:
                    result = await _paymentIntentManager.HandlePaymentIntentProcessing(
                        evt.Deserialize<PaymentIntent>());
                    break;

                case EventNames.PaymentIntentRequiresAction:
                    result = await _paymentIntentManager.HandlePaymentRequiresAction(
                        evt.Deserialize<PaymentIntent>());
                    break;

                case EventNames.PaymentIntentSucceeded:
                    result = await _paymentIntentManager.HandlePaymentIntentSucceeded(
                        evt.Deserialize<PaymentIntent>());
                    break;

                case EventNames.PaymentMethodAttached:
                    await _paymentMethodManager.HandlePaymentMethodAttached(evt.Deserialize<PaymentMethod>());
                    break;

                case EventNames.PaymentMethodAutomaticallyUpdated:
                    await _paymentMethodManager.HandlePaymentMethodAutomaticallyUpdated(evt.Deserialize<PaymentMethod>());
                    break;

                case EventNames.PaymentMethodDetached:
                    await _paymentMethodManager.HandlePaymentMethodDetached(evt.Deserialize<PaymentMethod>());
                    break;

                case EventNames.PaymentMethodUpdated:
                    await _paymentMethodManager.HandlePaymentMethodUpdated(evt.Deserialize<PaymentMethod>());
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
                    result = await _productManager.HandleProductCreated(evt.Deserialize<Product>());
                    break;
                case EventNames.ProductDeleted:
                    result = await _productManager.HandleProductDeleted(evt.Deserialize<Product>());
                    break;
                case EventNames.ProductUpdated:
                    result = await _productManager.HandleProductUpdated(evt.Deserialize<Product>());
                    break;
                case EventNames.PriceCreated:
                    result =await _priceManager.HandlePriceCreated(evt.Deserialize<Price>());
                    break;
                case EventNames.PriceDeleted:
                    result = await _priceManager.HandlePriceDeleted(evt.Deserialize<Price>());
                    break;
                case EventNames.PriceUpdated:
                    result = await _priceManager.HandlePriceUpdated(evt.Deserialize<Price>());
                    break;
            }

            return new OkObjectResult(result);
        }
    }
}
