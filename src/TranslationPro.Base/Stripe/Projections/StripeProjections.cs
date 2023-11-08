using AutoMapper;

namespace TranslationPro.Base.Stripe.Projections
{
    internal class StripeProjections : Profile
    {
        public StripeProjections()
        {
            //CreateMap<Address, StripeAddress>()
            //    .ForMember(x => x.City, opt => opt.MapFrom(x => x.City))
            //    .ForMember(x => x.State, opt => opt.MapFrom(x => x.State))
            //    .ForMember(x => x.Country, opt => opt.MapFrom(x => x.Country))
            //    .ForMember(x => x.Line1, opt => opt.MapFrom(x => x.Line1))
            //    .ForMember(x => x.Line2, opt => opt.MapFrom(x => x.Line2))
            //    .ForMember(x => x.PostalCode, opt => opt.MapFrom(x => x.PostalCode));

            //CreateMap<Card, StripeCard>()
            //    .ForMember(x => x.AddressCity, opt => opt.MapFrom(x => x.AddressCity))
            //    .ForMember(x => x.AddressCountry, opt => opt.MapFrom(x => x.AddressCountry))
            //    .ForMember(x => x.AddressLine1, opt => opt.MapFrom(x => x.AddressLine1))
            //    .ForMember(x => x.AddressLine1Check, opt => opt.MapFrom(x => x.AddressLine1Check))
            //    .ForMember(x => x.AddressLine2, opt => opt.MapFrom(x => x.AddressLine2))
            //    .ForMember(x => x.AddressState, opt => opt.MapFrom(x => x.AddressState))
            //    .ForMember(x => x.AddressZip, opt => opt.MapFrom(x => x.AddressZip))
            //    .ForMember(x => x.AddressZipCheck, opt => opt.MapFrom(x => x.AddressZipCheck))
            //    .ForMember(x => x.Brand, opt => opt.MapFrom(x => x.Brand))
            //    .ForMember(x => x.Country, opt => opt.MapFrom(x => x.Country))
            //    .ForMember(x => x.Currency, opt => opt.MapFrom(x => x.Currency))
            //    .ForMember(x => x.CustomerId, opt => opt.MapFrom(x => x.CustomerId))
            //    .ForMember(x => x.CvcCheck, opt => opt.MapFrom(x => x.CvcCheck))
            //    .ForMember(x => x.Description, opt => opt.MapFrom(x => x.Description))
            //    .ForMember(x => x.DefaultForCurrency, opt => opt.MapFrom(x => x.DefaultForCurrency))
            //    .ForMember(x => x.Deleted, opt => opt.MapFrom(x => x.Deleted))
            //    .ForMember(x => x.DynamicLast4, opt => opt.MapFrom(x => x.DynamicLast4))
            //    .ForMember(x => x.ExpMonth, opt => opt.MapFrom(x => x.ExpMonth))
            //    .ForMember(x => x.ExpYear, opt => opt.MapFrom(x => x.ExpYear))
            //    .ForMember(x => x.Fingerprint, opt => opt.MapFrom(x => x.Fingerprint))
            //    .ForMember(x => x.Funding, opt => opt.MapFrom(x => x.Funding))
            //    .ForMember(x => x.Id, opt => opt.MapFrom(x => x.Id))
            //    .ForMember(x => x.Iin, opt => opt.MapFrom(x => x.Iin))
            //    .ForMember(x => x.Issuer, opt => opt.MapFrom(x => x.Issuer))
            //    .ForMember(x => x.Last4, opt => opt.MapFrom(x => x.Last4))
            //    .ForMember(x => x.Name, opt => opt.MapFrom(x => x.Name))
            //    .ForMember(x => x.Status, opt => opt.MapFrom(x => x.Status))
            //    .ForMember(x => x.TokenizationMethod, opt => opt.MapFrom(x => x.TokenizationMethod));

            //CreateMap<Charge, StripeCharge>()
            //    .ForMember(x => x.Amount, opt => opt.MapFrom(x => x.Amount))
            //    .ForMember(x => x.AmountCaptured, opt => opt.MapFrom(x => x.AmountCaptured))
            //    .ForMember(x => x.AmountRefunded, opt => opt.MapFrom(x => x.AmountRefunded))
            //    .ForMember(x => x.AuthorizationCode, opt => opt.MapFrom(x => x.AuthorizationCode))
            //    .ForMember(x => x.Currency, opt => opt.MapFrom(x => x.Currency))
            //    .ForMember(x => x.Customer, opt => opt.MapFrom(x => x.Customer))
            //    .ForMember(x => x.CalculatedStatementDescriptor, opt => opt.MapFrom(x => x.CalculatedStatementDescriptor))
            //    .ForMember(x => x.Captured, opt => opt.MapFrom(x => x.Captured))
            //    .ForMember(x => x.Description, opt => opt.MapFrom(x => x.Description))
            //    .ForMember(x => x.Disputed, opt => opt.MapFrom(x => x.Disputed))
            //    .ForMember(x => x.FailureCode, opt => opt.MapFrom(x => x.FailureCode))
            //    .ForMember(x => x.FailureMessage, opt => opt.MapFrom(x => x.FailureMessage))
            //    .ForMember(x => x.Id, opt => opt.MapFrom(x => x.Id))
            //    .ForMember(x => x.Invoice, opt => opt.MapFrom(x => x.Invoice))
            //    .ForMember(x => x.InvoiceId, opt => opt.MapFrom(x => x.InvoiceId))
            //    .ForMember(x => x.LiveMode, opt => opt.MapFrom(x => x.Livemode))
            //    .ForMember(x => x.Paid, opt => opt.MapFrom(x => x.Paid))
            //    .ForMember(x => x.PaymentMethod, opt => opt.MapFrom(x => x.PaymentMethod))
            //    .ForMember(x => x.ReceiptEmail, opt => opt.MapFrom(x => x.ReceiptEmail))
            //    .ForMember(x => x.ReceiptNumber, opt => opt.MapFrom(x => x.ReceiptNumber))
            //    .ForMember(x => x.ReceiptUrl, opt => opt.MapFrom(x => x.ReceiptUrl))
            //    .ForMember(x => x.Refunded, opt => opt.MapFrom(x => x.Refunded))
            //    .ForMember(x => x.Refunds, opt => opt.MapFrom(x => x.Refunds))
            //    .ForMember(x => x.Status, opt => opt.MapFrom(x => x.Status))
            //    .ForMember(x => x.StatementDescriptor, opt => opt.MapFrom(x => x.StatementDescriptor))
            //    .ForMember(x => x.StatementDescriptorSuffix, opt => opt.MapFrom(x => x.StatementDescriptorSuffix));

            //CreateMap<Coupon, StripeCoupon>()
            //    .ForMember(x => x.AmountOff, opt => opt.MapFrom(x => x.AmountOff))
            //    .ForMember(x => x.Created, opt => opt.MapFrom(x => x.Created))
            //    .ForMember(x => x.Currency, opt => opt.MapFrom(x => x.Currency))
            //    .ForMember(x => x.Deleted, opt => opt.MapFrom(x => x.Deleted))
            //    .ForMember(x => x.Duration, opt => opt.MapFrom(x => x.Duration))
            //    .ForMember(x => x.DurationInMonths, opt => opt.MapFrom(x => x.DurationInMonths))
            //    .ForMember(x => x.Id, opt => opt.MapFrom(x => x.Id))
            //    .ForMember(x => x.LiveMode, opt => opt.MapFrom(x => x.Livemode))
            //    .ForMember(x => x.MaxRedemptions, opt => opt.MapFrom(x => x.MaxRedemptions))
            //    .ForMember(x => x.Name, opt => opt.MapFrom(x => x.Name))
            //    .ForMember(x => x.PercentOff, opt => opt.MapFrom(x => x.PercentOff))
            //    .ForMember(x => x.RedeemBy, opt => opt.MapFrom(x => x.AmountOff))
            //    .ForMember(x => x.TimesRedeemed, opt => opt.MapFrom(x => x.TimesRedeemed))
            //    .ForMember(x => x.Valid, opt => opt.MapFrom(x => x.Valid));

            //CreateMap<Customer, StripeCustomer>()
            //    .ForMember(x => x.Address, opt => opt.MapFrom(x => x.Address))
            //    .ForMember(x => x.Balance, opt => opt.MapFrom(x => x.Balance))
            //    .ForMember(x => x.Created, opt => opt.MapFrom(x => x.Created))
            //    .ForMember(x => x.Currency, opt => opt.MapFrom(x => x.Currency))
            //    .ForMember(x => x.Deleted, opt => opt.MapFrom(x => x.Deleted))
            //    .ForMember(x => x.Delinquent, opt => opt.MapFrom(x => x.Delinquent))
            //    .ForMember(x => x.Description, opt => opt.MapFrom(x => x.Description))
            //    .ForMember(x => x.Email, opt => opt.MapFrom(x => x.Email))
            //    .ForMember(x => x.Id, opt => opt.MapFrom(x => x.Id))
            //    .ForMember(x => x.InvoicePrefix, opt => opt.MapFrom(x => x.InvoicePrefix))
            //    .ForMember(x => x.LiveMode, opt => opt.MapFrom(x => x.Livemode))
            //    .ForMember(x => x.Name, opt => opt.MapFrom(x => x.Name))
            //    .ForMember(x => x.NextInvoiceSequence, opt => opt.MapFrom(x => x.NextInvoiceSequence))
            //    .ForMember(x => x.Phone, opt => opt.MapFrom(x => x.Phone))
            //    .ForMember(x => x.Subscriptions, opt => opt.MapFrom(x => x.Subscriptions))
            //    .ForMember(x => x.TaxExempt, opt => opt.MapFrom(x => x.TaxExempt))
            //    .ReverseMap();

            //CreateMap<Invoice, StripeInvoice>();
            //CreateMap<InvoiceLineItem, StripeInvoiceLineItem>();
            //CreateMap<PaymentIntent, StripePaymentIntent>();
            //CreateMap<PaymentLink, StripePaymentLink>();
            //CreateMap<PaymentMethod, StripePaymentMethod>();
            //CreateMap<Payout, StripePayout>();
            //CreateMap<Price, StripePrice>();
            //CreateMap<Product, StripeProduct>();
            //CreateMap<PromotionCode, StripePromotionCode>();
            //CreateMap<PriceRecurring, StripePriceRecurring>();
            //CreateMap<Refund, StripeRefund>();
            //CreateMap<SubscriptionSchedule, StripeSubscriptionSchedule>();
            //CreateMap<Session, StripeSession>();
            ////CreateMap<Subscription, StripeSubscription>();
            //CreateMap<SubscriptionItem, StripeSubscriptionItem>();
        }
    }
}
