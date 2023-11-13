#region Header Info

// Copyright 2023 Rod Johnson.  All rights reserved

#endregion

using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TranslationPro.Base.Common.Data.Bases;
using TranslationPro.Shared.Interfaces;

namespace TranslationPro.Base.Entities;

[ExcludeFromCodeCoverage]
public class Language : BaseEntity<Language>, ILanguage
{
    public ICollection<EngineLanguage> Engines { get; set; }
    public ICollection<ApplicationLanguage> Applications { get; set; }
    public string Name { get; set; }
    public string Id { get; set; }

    public override void Configure(EntityTypeBuilder<Language> builder)
    {
        builder.ToTable(nameof(Language), "TranslationPro");

        builder.HasKey(x => x.Id);
    }
}