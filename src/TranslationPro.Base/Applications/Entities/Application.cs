#region Header Info

// Copyright 2023 Rod Johnson.  All rights reserved

#endregion

using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TranslationPro.Base.ApplicationLanguages.Entities;
using TranslationPro.Base.ApplicationUsers.Entities;
using TranslationPro.Base.Common.Data.Bases;
using TranslationPro.Base.Engines.Entities;
using TranslationPro.Base.Phrases.Entities;
using TranslationPro.Base.Translations.Entities;
using TranslationPro.Shared.Interfaces;

namespace TranslationPro.Base.Applications.Entities;

public class Application : BaseEntity<Application>, IApplication
{
    public Application()
    {
        Languages = new List<ApplicationLanguage>();
        Phrases = new List<Phrase>();
        Translations = new List<Translation>();
        Users = new List<ApplicationUser>();
    }

    public ICollection<ApplicationLanguage> Languages { get; set; }
    public ICollection<Translation> Translations { get; set; }
    public ICollection<ApplicationEngine> Engines { get; set; }
    public List<Phrase> Phrases { get; set; }
   
    public Guid Id { get; set; }
    public string Name { get; set; }
    public bool IsDeleted { get; set; }
    public ICollection<ApplicationUser> Users { get; set; }

    public override void Configure(EntityTypeBuilder<Application> builder)
    {
        builder.HasKey(x => x.Id);
        
        builder.HasQueryFilter(x => !x.IsDeleted);
    }
}