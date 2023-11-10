#region Header Info

// Copyright 2023 Rod Johnson.  All rights reserved

#endregion

using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TranslationPro.Base.ApplicationLanguages.Entities;
using TranslationPro.Base.ApplicationUsers.Entities;
using TranslationPro.Base.Common.Data.Bases;
using TranslationPro.Base.Common.Data.Interfaces;
using TranslationPro.Base.Phrases.Entities;
using TranslationPro.Base.Translations.Entities;
using TranslationPro.Shared.Interfaces;

namespace TranslationPro.Base.Applications.Entities;

public class Application : BaseEntity<Application>, IApplication, ISoftDelete
{
    public Application()
    {
        Phrases = new List<ApplicationPhrase>();
        Users = new List<ApplicationUser>();
        Languages = new List<ApplicationLanguage>();
    }

    public ICollection<ApplicationLanguage> Languages { get; set; }
    public ICollection<ApplicationTranslation> Translations { get; set; }
    public ICollection<ApplicationPhrase> Phrases { get; set; }
   
    public Guid Id { get; set; }
    public string Name { get; set; }
    public bool IsDeleted { get; set; }
    public ICollection<ApplicationUser> Users { get; set; }
    public ICollection<HumanTranslation> HumanTranslations { get; set; }

    public override void Configure(EntityTypeBuilder<Application> builder)
    {
        builder.ToTable(nameof(Application), "TranslationPro");

        builder.HasKey(x => x.Id);
        
        builder.HasQueryFilter(x => !x.IsDeleted);
    }
}