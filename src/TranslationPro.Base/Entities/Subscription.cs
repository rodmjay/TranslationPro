﻿#region Header Info

// Copyright 2023 Rod Johnson.  All rights reserved

#endregion

using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TranslationPro.Base.Common.Data.Bases;
using TranslationPro.Base.Users.Entities;

namespace TranslationPro.Base.Entities;

public class Subscription : BaseEntity<Subscription>
{
    public int UserId { get; set; }

    public User User { get; set; }

    public ICollection<Application> Applications { get; set; }

    public decimal CharacterPrice { get; set; }

    public string CustomerId { get; set; }
    public string SubscriptionId { get; set; }

    public override void Configure(EntityTypeBuilder<Subscription> builder)
    {
        builder.ToTable(nameof(Subscription), "TranslationPro");

        builder.HasKey(x => x.UserId);

        builder.HasOne(x=>x.User)
            .WithOne(x=>x.Subscription)
            .HasForeignKey<Subscription>(x=>x.UserId);

        builder.Property(x => x.CharacterPrice).HasColumnType("money").HasPrecision(19, 4);
    }
}