#region Header Info

// Copyright 2023 Rod Johnson.  All rights reserved

#endregion

using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TranslationPro.Base.ApplicationLanguages.Entities;
using TranslationPro.Base.Applications.Entities;
using TranslationPro.Base.Common.Data.Bases;
using TranslationPro.Base.Common.Data.Interfaces;
using TranslationPro.Base.Languages.Entities;
using TranslationPro.Base.Phrases.Entities;
using TranslationPro.Shared.Enums;
using TranslationPro.Shared.Interfaces;

namespace TranslationPro.Base.Translations.Entities;

public class ApplicationTranslation : BaseEntity<ApplicationTranslation>, ITranslation, ISoftDelete
{
    public Guid ApplicationId { get; set; }
    public Application Application { get; set; }
    public int PhraseId { get; set; }
    public ApplicationPhrase ApplicationPhrase { get; set; }
    public Language Language { get; set; }
    public int Id { get; set; }
    public string LanguageId { get; set; }
    public DateTime? TranslationDate { get; set; }
    public string Text { get; set; }
    public TranslationEngine EngineId { get; set; }
    public ApplicationLanguage ApplicationLanguage { get; set; }
    public bool IsDeleted { get; set; }

    public override void Configure(EntityTypeBuilder<ApplicationTranslation> builder)
    {
        builder.ToTable(nameof(ApplicationTranslation), "TranslationPro");

        builder.HasKey(x => x.Id);
        builder.HasOne(x => x.ApplicationPhrase)
            .WithMany(x => x.MachineTranslations)
            .HasForeignKey(x => new {x.ApplicationId, x.PhraseId});

        builder.HasOne(x => x.Application)
            .WithMany(x => x.Translations)
            .HasForeignKey(x => x.ApplicationId)
            .OnDelete(DeleteBehavior.Restrict);

        builder.HasQueryFilter(x => !x.IsDeleted);
    }
}