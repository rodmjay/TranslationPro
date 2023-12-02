#region Header Info

// Copyright 2023 Rod Johnson.  All rights reserved

#endregion

using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TranslationPro.Base.Common.Data.Bases;
using TranslationPro.Base.Common.Data.Interfaces;
using TranslationPro.Shared.Interfaces;


namespace TranslationPro.Base.Entities;
[ExcludeFromCodeCoverage]
public class Application : BaseEntity<Application>, IApplication, ISoftDelete, ICreated
{
    public Application()
    {
        Phrases = new List<ApplicationPhrase>();
        Users = new List<ApplicationUser>();
        Languages = new List<ApplicationLanguage>();
    }

    public ICollection<ApplicationLanguage> Languages { get; set; }
    public ICollection<ApplicationPhrase> Phrases { get; set; }
   
    public Guid Id { get; set; }
    public string Name { get; set; }
    public bool IsDeleted { get; set; }
    public int CurrentPhraseId { get; set; }
    public ICollection<ApplicationUser> Users { get; set; }
    
    public int? SubscriptionId { get; set; }

    public override void Configure(EntityTypeBuilder<Application> builder)
    {
        builder.ToTable(nameof(Application), "TranslationPro");

        builder.HasKey(x => x.Id);
        
        builder.HasQueryFilter(x => !x.IsDeleted);

        builder.Property(x => x.CurrentPhraseId).HasDefaultValue(10000);
    }

    public DateTimeOffset Created { get; set; }
}