using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Newtonsoft.Json;
using Stripe;
using Stripe.Infrastructure;
using System.Collections.Generic;
using TranslationPro.Base.Common.Data.Bases;

namespace TranslationPro.Base.Stripe.Entities;

public class StripePaymentLink : BaseEntity<StripePaymentLink>, IHasId
{
    public override void Configure(EntityTypeBuilder<StripePaymentLink> builder)
    {
        builder.ToTable(nameof(PaymentLink), "Stripe");

        builder.HasKey(x => x.Id);
    }

    public string Id { get; set; }

    public bool Active { get; set; }
    
    // todo: public PaymentLinkAfterCompletion AfterCompletion { get; set; }
    
    public bool AllowPromotionCodes { get; set; }

    public string BillingAddressCollection { get; set; }
    
    public string Currency { get; set; }
    
    public string CustomerCreation { get; set; }
    
    //public PaymentLinkInvoiceCreation InvoiceCreation { get; set; }
    
    public StripeList<StripePaymentLinkLineItem> LineItems { get; set; }
    
    public bool Livemode { get; set; }
    
    
    public string PaymentMethodCollection { get; set; }
    
    public string SubmitType { get; set; }

    /// <summary>
    /// When creating a subscription, the specified configuration data will be used. There must
    /// be at least one line item with a recurring price to use <c>subscription_data</c>.
    /// </summary>
    
    //todo: public PaymentLinkSubscriptionData SubscriptionData { get; set; }
    
    public string Url { get; set; }
}