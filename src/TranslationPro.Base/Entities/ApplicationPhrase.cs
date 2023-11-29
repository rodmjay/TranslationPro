#region Header Info

// Copyright 2023 Rod Johnson.  All rights reserved

#endregion

using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Diagnostics.CodeAnalysis;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TranslationPro.Base.Common.Data.Bases;
using TranslationPro.Base.Common.Data.Interfaces;

namespace TranslationPro.Base.Entities;

[ExcludeFromCodeCoverage]
public class ApplicationPhrase : BaseEntity<ApplicationPhrase>, ISoftDelete, ICreated
{
    public ApplicationPhrase()
    {
        Translations = new List<ApplicationTranslation>();
    }
    public Guid ApplicationId { get; set; }
    public Application Application { get; set; }
    public ICollection<ApplicationTranslation> Translations { get; set; }
    public int Id { get; set; }

    public bool IsDeleted { get; set; }
    public string Text { get; set; }


    [DatabaseGenerated(DatabaseGeneratedOption.Computed)]
    public int CharacterCount { get; set; }

    public override void Configure(EntityTypeBuilder<ApplicationPhrase> builder)
    {
        builder.ToTable(nameof(ApplicationPhrase), "TranslationPro");

        builder.HasKey(t => new {t.ApplicationId, t.Id});


        builder.HasOne(x => x.Application)
            .WithMany(x => x.Phrases)
            .HasForeignKey(x => x.ApplicationId)
            .OnDelete(DeleteBehavior.Cascade);

        builder.Property(x => x.CharacterCount).HasComputedColumnSql(@"IIF([Text] is not null, CAST(DATALENGTH([Text]) AS INT), 0)");


        builder.HasQueryFilter(x => !x.IsDeleted);
    }

    public DateTimeOffset Created { get; set; }
}