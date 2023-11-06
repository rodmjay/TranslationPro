using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TranslationPro.Base.Stripe
{
    public static class EventNames
    {
        public const string CustomerCreated = "customer.created";
        public const string CustomerUpdated = "customer.updated";
        public const string CustomerDeleted = "customer.deleted";
        public const string ChargeCreated = "charged.created";
        public const string ChargeSucceeded = "charged.succeeded";
        public const string ChargeCaptured = "charged.captured";
        public const string ChargeDisputeClosed = "charged.dispute.closed";
        public const string ChargeDisputeCreated = "charge.dispute.created";
        public const string ChargeDisputeFundsReinstated = "charge.dispute.funds_reinstated";
        public const string ChargeDisputeFundsWithdrawn = "charge.dispute.funds_withdrawn";
        public const string ChargeDisputeUpdated = "charge.dispute.updated";
        public const string ChargeExpired = "charge.expired";
        public const string ChargeFailed = "charge.failed";
        public const string ChargePending = "charge.pending";
        public const string ChargeRefundUpdated = "charge.refund.updated";
        public const string ChargeRefunded = "charge.refunded";
        public const string ChargeUpdated = "charge.updated";
        public const string CouponCreated = "coupon.created";
        public const string CouponDeleted = "coupon.deleted";
        public const string CustomerDiscountCreated = "customer.discount.created";
        public const string CustomerDiscountDeleted = "customer.discount.deleted";
        public const string CustomerDiscountUpdated = "customer.discount.updated";
        public const string CustomerSourceCreated = "customer.source.created";
        public const string CustomerSourceDeleted = "customer.source.deleted";
        public const string CustomerSourceExpiring = "customer.source.expiring";
        public const string CustomerSourceUpdated = "customer.source.updated";
        public const string CustomerSubscriptionCreated = "customer.subscription.created";
        public const string CustomerSubscriptionDeleted = "customer.subscription.deleted";
        public const string CustomerSubscriptionPaused = "customer.subscription.paused";
        public const string CustomerSubscriptionTrialWillEnd = "customer.subscription.trial_will_end";
        public const string CustomerSubscriptionUpdated = "customer.subscription.updated";
        public const string InvoiceCreated = "invoice.created";
        public const string InvoiceDeleted = "invoice.deleted";
        public const string InvoiceFinalized = "invoice.finalized";
        public const string InvoiceMarkedUncollectible = "invoice.marked_uncollectible";
        public const string InvoicePaid = "invoice.paid";
        public const string InvoicePaymentActionRequired = "invoice.payment_action_required";
        public const string InvoicePaymentFailed = "invoice.payment.failed";
        public const string InvoicePaymentSucceeded = "invoice.payment.succeeded";
        public const string InvoiceSent = "invoice.sent";
        public const string InvoiceUpcoming = "invoice.upcoming";
        public const string InvoiceUpdated = "invoice.updated";
        public const string InvoiceVoided = "invoice.voided";
        public const string InvoiceItemCreated = "invoiceitem.created";
        public const string InvoiceItemDeleted = "invoiceitem.deleted";

        public const string PaymentIntentAmountCapturableUpdated = "payment_intent.amount_capturable_updated";
        public const string PaymentIntentCanceled = "payment_intent.canceled";
        public const string PaymentIntentCreated = "payment_intent.created";
        public const string PaymentIntentPartiallyFunded = "payment_intent.partially_funded";
        public const string PaymentIntentPaymentFailed = "payment_intent.payment_failed";
        public const string PaymentIntentProcessing = "payment_intent.processing";
        public const string PaymentIntentRequiresAction = "payment_intent.requires_action";
        public const string PaymentIntentSucceeded = "payment_intent.succeeded";

        public const string PaymentMethodAttached = "payment_method.attached";
        public const string PaymentMethodAutomaticallyUpdated = "payment_method.automatically_updated";
        public const string PaymentMethodDetached = "payment_method.detached";
        public const string PaymentMethodUpdated = "payment_method.updated";

        public const string PayoutCreated = "payout.created";
        public const string PayoutFailed = "payout.failed";
        public const string PayoutPaid = "payout.paid";
        public const string PayoutReconciliationCompleted = "payout.reconciliation_completed";

        public const string PriceCreated = "price.created";
        public const string PriceDeleted = "price.deleted";
        public const string PriceUpdated = "price.updated";

        public const string ProductCreated = "product.created";
        public const string ProductDeleted = "product.deleted";
        public const string ProductUpdated = "product.updated";

        public const string CardCreated = "card.created";
        public const string CardDeleted = "card.deleted";
        public const string CardUpdated = "card.updated";

        public const string PromotionCodeCreated = "promotion_code.created";
        public const string PromotionCodeUpdated = "promotion_code.updated";

        public const string RefundCreated = "refund.created";
        public const string RefundUpdated = "refund.updated";

        public const string SubscriptionScheduleAborted = "subscription_schedule.aborted";
        public const string SubscriptionScheduleCanceled = "subscription_schedule.canceled";
        public const string SubscriptionScheduleCompleted = "subscription_schedule.completed";
        public const string SubscriptionScheduleCreated = "subscription_schedule.created";
        public const string SubscriptionScheduleExpiring = "subscription_schedule.expiring";
        public const string SubscriptionScheduleReleased = "subscription_schedule.released";
        public const string SubscriptionScheduleUpdated = "subscription_schedule.updated";

    }
}
