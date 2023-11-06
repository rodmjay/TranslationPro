using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Newtonsoft.Json;
using Stripe;
using Stripe.Infrastructure;
using TranslationPro.Base.Common.Data.Bases;
using TranslationPro.Base.Stripe.Interfaces;

namespace TranslationPro.Base.Stripe.Entities;

public class StripeSubscriptionSchedule : BaseEntity<StripeSubscriptionSchedule>, IHasId, IHasCustomer, ILiveMode
{
    public override void Configure(EntityTypeBuilder<StripeSubscriptionSchedule> builder)
    {
        builder.ToTable(nameof(SubscriptionSchedule), "Stripe");

        builder.HasKey(x => x.Id);

        builder.HasOne(x => x.Customer)
            .WithMany(x => x.Schedules)
            .HasForeignKey(x => x.CustomerId);
    }

    public string Id { get; set; }
    public StripeCustomer Customer { get; set; }
    public string CustomerId { get; set; }

    public ICollection<StripeSubscription> Subscriptions { get; set; }
    
    public DateTime? CanceledAt { get; set; }
    
    public DateTime? CompletedAt { get; set; }
    
    public DateTime Created { get; set; } 
    
    public string EndBehavior { get; set; }
    
    public DateTime? ReleasedAt { get; set; }
    
    public string ReleasedSubscription { get; set; }
    
    public string Status { get; set; }
    public bool LiveMode { get; set; }
}