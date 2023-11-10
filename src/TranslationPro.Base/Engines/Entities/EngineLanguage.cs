#region Header Info

// Copyright 2023 Rod Johnson.  All rights reserved

#endregion

using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TranslationPro.Base.Common.Data.Bases;
using TranslationPro.Base.Languages.Entities;
using TranslationPro.Base.Translations.Entities;
using TranslationPro.Shared.Enums;

namespace TranslationPro.Base.Engines.Entities;

public class EngineLanguage : BaseEntity<EngineLanguage>
{
    public string LanguageId { get; set; }
    public Language Language { get; set; }

    public TranslationEngine EngineId { get; set; }
    public Engine Engine { get; set; }

    public ICollection<MachineTranslation> MachineTranslations { get; set; }

    public override void Configure(EntityTypeBuilder<EngineLanguage> builder)
    {
        builder.ToTable(nameof(EngineLanguage), "TranslationPro");

        builder.HasKey(x => new {x.LanguageId, x.EngineId});

        builder.HasOne(x => x.Language)
            .WithMany(x => x.Engines)
            .HasForeignKey(x => x.LanguageId);

        builder.HasOne(x => x.Engine)
            .WithMany(x => x.Languages)
            .HasForeignKey(x => x.EngineId);
    }
}