#region Header Info

// Copyright 2023 Rod Johnson.  All rights reserved

#endregion

using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TranslationPro.Base.Applications.Entities;
using TranslationPro.Base.Common.Data.Bases;
using TranslationPro.Base.Engines.Entities;
using TranslationPro.Base.Languages.Entities;
using TranslationPro.Base.Translations.Entities;
using TranslationPro.Shared.Enums;

namespace TranslationPro.Base.ApplicationLanguages.Entities;

public class ApplicationEngineLanguage : BaseEntity<ApplicationEngineLanguage>
{
    public Guid ApplicationId { get; set; }
    public Application Application { get; set; }

    public string LanguageId { get; set; }
    public TranslationEngine EngineId { get; set; }

    public ApplicationEngine ApplicationEngine { get; set; }

    public EngineLanguage EngineLanguage { get; set; }
    
    public Language Language { get; set; }

    public ICollection<ApplicationTranslation> Translations { get; set; }

    public override void Configure(EntityTypeBuilder<ApplicationEngineLanguage> builder)
    {
        builder.HasKey(x => new {x.ApplicationId, x.EngineId, x.LanguageId});

        builder.HasOne(x => x.Application)
            .WithMany(x => x.EngineLanguages)
            .HasForeignKey(x=>x.ApplicationId);

        builder.HasOne(x => x.ApplicationEngine)
            .WithMany(x => x.EnabledLanguages)
            .HasForeignKey(x => new{x.ApplicationId, x.EngineId});

        builder.HasOne(x => x.EngineLanguage)
            .WithMany(x => x.Applications)
            .HasForeignKey(x => new{x.LanguageId, x.EngineId});

        builder.HasOne(x=>x.Language)
            .WithMany(x=>x.Applications)
            .HasForeignKey(x=>x.LanguageId);
    }
}