#region Header Info

// Copyright 2023 Rod Johnson.  All rights reserved

#endregion

using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TranslationPro.Base.Applications.Entities;
using TranslationPro.Base.Common.Data.Bases;
using TranslationPro.Base.Translations.Entities;
using TranslationPro.Shared.Interfaces;

namespace TranslationPro.Base.Phrases.Entities;

public class Phrase : BaseEntity<Phrase>, IPhrase
{
    public Phrase()
    {
        Translations = new List<Translation>();
    }

    public Guid ApplicationId { get; set; }
    public Application Application { get; set; }
    public ICollection<Translation> Translations { get; set; }
    public int Id { get; set; }
    public string Text { get; set; }

    public bool IsDeleted { get; set; }

    public override void Configure(EntityTypeBuilder<Phrase> builder)
    {
        builder.HasKey(t => new {t.ApplicationId, t.Id});


        builder.HasOne(x => x.Application)
            .WithMany(x => x.Phrases)
            .HasForeignKey(x => x.ApplicationId)
            .OnDelete(DeleteBehavior.Cascade);

        builder.HasQueryFilter(x => !x.IsDeleted);
    }
}