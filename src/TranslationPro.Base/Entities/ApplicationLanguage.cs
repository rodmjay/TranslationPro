#region Header Info

// Copyright 2023 Rod Johnson.  All rights reserved

#endregion

using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TranslationPro.Base.Common.Data.Bases;
using TranslationPro.Base.Common.Data.Interfaces;

namespace TranslationPro.Base.Entities;

public class ApplicationLanguage : BaseEntity<ApplicationLanguage>, ISoftDelete
{
    public Guid ApplicationId { get; set; }
    public Application Application { get; set; }

    public string LanguageId { get; set; }
    public Language Language { get; set; }
    public bool IsDeleted { get; set; }

    public ICollection<ApplicationTranslation> Translations { get; set; }

    public override void Configure(EntityTypeBuilder<ApplicationLanguage> builder)
    {
        builder.ToTable(nameof(ApplicationLanguage), "TranslationPro");

        builder.HasKey(x => new { x.ApplicationId, x.LanguageId });

        builder.HasOne(x => x.Application)
            .WithMany(x => x.Languages)
            .HasForeignKey(x => x.ApplicationId);

        builder.HasOne(x => x.Language)
            .WithMany(x => x.Applications)
            .HasForeignKey(x => x.LanguageId);

        builder.HasQueryFilter(x => !x.IsDeleted);
    }
}