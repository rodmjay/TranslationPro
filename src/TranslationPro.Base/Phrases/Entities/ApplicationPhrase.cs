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

namespace TranslationPro.Base.Phrases.Entities;

public class HumanTranslation : BaseEntity<HumanTranslation>
{
    public Guid ApplicationId { get; set; }
    public Language Language { get; set; }
    public string LanguageId { get; set; }
    public Application Application { get; set; }
    public ApplicationPhrase Phrase { get; set; }
    public int PhraseId { get; set; }
    public string Text { get; set; }
    public DateTime Created { get; set; }

    public override void Configure(EntityTypeBuilder<HumanTranslation> builder)
    {
        builder.HasKey(x => new {x.ApplicationId, x.PhraseId, x.LanguageId});

        builder.HasOne(x => x.Phrase)
            .WithMany(x => x.HumanTranslations)
            .HasForeignKey(x => new {x.ApplicationId, x.PhraseId});

    }
}

public class ApplicationPhrase : BaseEntity<ApplicationPhrase>
{
    public ApplicationPhrase()
    {
        MachineTranslations = new List<ApplicationTranslation>();
    }

    public Guid ApplicationId { get; set; }
    public Application Application { get; set; }
    public ICollection<ApplicationTranslation> MachineTranslations { get; set; }
    public ICollection<HumanTranslation> HumanTranslations { get; set; }
    public int Id { get; set; }
   
    public int PhraseId { get; set; }
    public Phrase Phrase { get; set; }

    public bool IsDeleted { get; set; }

    public override void Configure(EntityTypeBuilder<ApplicationPhrase> builder)
    {
        builder.HasKey(t => new {t.ApplicationId, t.Id});


        builder.HasOne(x => x.Application)
            .WithMany(x => x.Phrases)
            .HasForeignKey(x => x.ApplicationId)
            .OnDelete(DeleteBehavior.Cascade);

        builder.HasOne(x => x.Phrase)
            .WithMany(x => x.Applications)
            .HasForeignKey(x => x.PhraseId);

        builder.HasQueryFilter(x => !x.IsDeleted);
    }
}