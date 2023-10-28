#region Header Info

// Copyright 2023 Rod Johnson.  All rights reserved

#endregion

using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TranslationPro.Base.ApplicationLanguages.Entities;
using TranslationPro.Base.Applications.Entities;
using TranslationPro.Base.Common.Data.Bases;
using TranslationPro.Base.Languages.Entities;
using TranslationPro.Base.Phrases.Entities;
using TranslationPro.Base.Translations.Interfaces;

namespace TranslationPro.Base.Translations.Entities;

public class Translation : BaseEntity<Translation>, ITranslation
{
    public Guid ApplicationId { get; set; }
    public Application Application { get; set; }
    public int PhraseId { get; set; }
    public Phrase Phrase { get; set; }
    public Language Language { get; set; }
    public int Id { get; set; }
    public string LanguageId { get; set; }
    public DateTime? TranslationDate { get; set; }
    public string Text { get; set; }

    public ApplicationLanguage ApplicationLanguage { get; set; }

    public override void Configure(EntityTypeBuilder<Translation> builder)
    {
        builder.HasKey(x => x.Id);
        builder.HasOne(x => x.Phrase)
            .WithMany(x => x.Translations)
            .HasForeignKey(x => new {x.ApplicationId, x.PhraseId});

        builder.HasOne(x => x.Application)
            .WithMany(x => x.Translations)
            .HasForeignKey(x => x.ApplicationId)
            .OnDelete(DeleteBehavior.Restrict);

        builder.HasOne(x => x.ApplicationLanguage)
            .WithMany(x => x.Translations)
            .HasForeignKey(x => new {x.ApplicationId, x.LanguageId});
    }
}