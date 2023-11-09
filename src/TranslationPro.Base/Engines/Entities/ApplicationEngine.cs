#region Header Info

// Copyright 2023 Rod Johnson.  All rights reserved

#endregion

using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TranslationPro.Base.ApplicationLanguages.Entities;
using TranslationPro.Base.Applications.Entities;
using TranslationPro.Base.Common.Data.Bases;
using TranslationPro.Base.Translations.Entities;
using TranslationPro.Shared.Enums;

namespace TranslationPro.Base.Engines.Entities;

public class ApplicationEngine : BaseEntity<ApplicationEngine>
{
    public Guid ApplicationId { get; set; }
    public Application Application { get; set; }

    public TranslationEngine EngineId { get; set; }
    public Engine Engine { get; set; }

    public ICollection<ApplicationEngineLanguage> EnabledLanguages { get; set; }

    public ICollection<ApplicationTranslation> MachineTranslations { get; set; }

    public override void Configure(EntityTypeBuilder<ApplicationEngine> builder)
    {
        builder.HasKey(x => new {x.ApplicationId, x.EngineId});

        builder.HasOne(x => x.Application)
            .WithMany(x => x.Engines)
            .HasForeignKey(x => x.ApplicationId);

        builder.HasOne(x => x.Engine)
            .WithMany(x => x.Applications)
            .HasForeignKey(x => x.EngineId);
    }
}