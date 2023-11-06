using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Stripe;
using TranslationPro.Base.Common.Data.Bases;
using TranslationPro.Base.Stripe.Interfaces;

namespace TranslationPro.Base.Stripe.Entities;

public class StripeCharge : BaseEntity<StripeCharge>, IHasId, ILiveMode, IHasCustomer, IHasInvoice, IAmount
{
    public override void Configure(EntityTypeBuilder<StripeCharge> builder)
    {
        builder.ToTable(nameof(Charge), "Stripe");

        builder.HasKey(x => x.Id);

        builder.HasOne(x => x.Customer)
            .WithMany(x => x.Charges)
            .HasForeignKey(x => x.CustomerId);

        builder.HasOne(x => x.Invoice)
            .WithMany(x => x.Charges)
            .HasForeignKey(x => x.InvoiceId);

        builder.OwnsOne(x => x.Outcome);
    }
    public ICollection<StripeRefund> Refunds { get; set; }
    public string Id { get; set; }
    public bool LiveMode { get; set; }
    public StripeCustomer Customer { get; set; }
    public string CustomerId { get; set; }
    public string InvoiceId { get; set; }
    public StripeInvoice Invoice { get; set; }
    
    public long Amount { get; set; }
    
    public long AmountCaptured { get; set; }
    
    public long AmountRefunded { get; set; }
    
    
    public string AuthorizationCode { get; set; }
    
    public string CalculatedStatementDescriptor { get; set; }
    
    public bool Captured { get; set; }
    
    public long Created { get; set; } 
    
    public string Currency { get; set; }
    
    public string Description { get; set; }
    
    public bool Disputed { get; set; }
    
    public string FailureCode { get; set; }
    
    public string FailureMessage { get; set; }
    
    public StripeChargeOutcome Outcome { get; set; }
    
    public bool Paid { get; set; }
    
    public string PaymentMethod { get; set; }
    
    public string ReceiptEmail { get; set; }
    
    public string ReceiptNumber { get; set; }
    
    public string ReceiptUrl { get; set; }
    
    public bool Refunded { get; set; }
    
    public string StatementDescriptor { get; set; }
    
    public string StatementDescriptorSuffix { get; set; }
    
    public string Status { get; set; }
    

}