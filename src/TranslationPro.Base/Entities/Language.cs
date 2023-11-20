#region Header Info

// Copyright 2023 Rod Johnson.  All rights reserved

#endregion

using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TranslationPro.Base.Common.Data.Bases;

namespace TranslationPro.Base.Entities;

[ExcludeFromCodeCoverage]
public class Language : BaseEntity<Language>
{
    public string Name { get; set; }
    public string Id { get; set; }

    public ICollection<ApplicationLanguage> Applications { get; set; }

    public override void Configure(EntityTypeBuilder<Language> builder)
    {
        builder.ToTable(nameof(Language), "TranslationPro");

        builder.HasKey(x => x.Id);
    }
}