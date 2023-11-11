#region Header Info

// Copyright 2023 Rod Johnson.  All rights reserved

#endregion

using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using Microsoft.EntityFrameworkCore;
using TranslationPro.Base.Common.Data.Bases;
using TranslationPro.Base.Common.Data.Interfaces;
using TranslationPro.Base.Engines.Entities;
using TranslationPro.Base.Phrases.Entities;
using TranslationPro.Shared.Enums;

namespace TranslationPro.Base.Translations.Entities;

public class MachineTranslation : BaseEntity<MachineTranslation>, ISoftDelete
{
    public TranslationEngine EngineId { get; set; }
    public Engine Engine { get; set; }

    public string LanguageId { get; set; }
    public EngineLanguage Language { get; set; }

    public int PhraseId { get; set; }
    public Phrase Phrase { get; set; }
    public DateTime? TranslationDate { get; set; }
    public string Text { get; set; }

    public override void Configure(EntityTypeBuilder<MachineTranslation> builder)
    {
        builder.ToTable(nameof(MachineTranslation), "TranslationPro");

        builder.HasKey(x => new { x.EngineId, x.LanguageId, x.PhraseId });

        builder.HasOne(x => x.Phrase)
            .WithMany(x => x.MachineTranslations)
            .HasForeignKey(x => x.PhraseId);

        builder.HasOne(x => x.Language)
            .WithMany(x => x.MachineTranslations)
            .HasForeignKey(x => new { x.LanguageId, x.EngineId });

        builder.HasOne(x => x.Engine)
            .WithMany(x => x.MachineTranslations)
            .HasForeignKey(x => x.EngineId)
            .OnDelete(DeleteBehavior.NoAction);

        builder.HasQueryFilter(x => !x.IsDeleted);
    }

    public bool IsDeleted { get; set; }
}