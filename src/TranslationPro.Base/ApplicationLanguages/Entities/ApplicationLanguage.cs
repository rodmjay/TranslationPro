#region Header Info

// Copyright 2023 Rod Johnson.  All rights reserved

#endregion

using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TranslationPro.Base.Applications.Entities;
using TranslationPro.Base.Common.Data.Bases;
using TranslationPro.Base.Languages.Entities;
using TranslationPro.Base.Translations.Entities;

namespace TranslationPro.Base.ApplicationLanguages.Entities;

public class ApplicationLanguage : BaseEntity<ApplicationLanguage>
{
    public Guid ApplicationId { get; set; }
    public Application Application { get; set; }
    public Language Language { get; set; }
    public string LanguageId { get; set; }
    public ICollection<Translation> Translations { get; set; }

    public override void Configure(EntityTypeBuilder<ApplicationLanguage> builder)
    {
        builder.HasKey(x => new {x.ApplicationId, x.LanguageId});

        builder.HasOne(x => x.Language)
            .WithMany(x => x.Applications)
            .HasForeignKey(x => x.LanguageId);

        builder.HasOne(x => x.Application)
            .WithMany(x => x.Languages)
            .HasForeignKey(x => x.ApplicationId)
            .OnDelete(DeleteBehavior.Cascade);
    }
}