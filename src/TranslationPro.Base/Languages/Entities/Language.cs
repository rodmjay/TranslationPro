#region Header Info

// Copyright 2023 Rod Johnson.  All rights reserved

#endregion

using System.Collections.Generic;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TranslationPro.Base.ApplicationLanguages.Entities;
using TranslationPro.Base.Common.Data.Bases;
using TranslationPro.Base.Translations.Entities;
using TranslationPro.Shared.Interfaces;

namespace TranslationPro.Base.Languages.Entities;

public class Language : BaseEntity<Language>, ILanguage
{
    public Language()
    {
        Applications = new List<ApplicationLanguage>();
        Translations = new List<Translation>();
    }

    public ICollection<ApplicationLanguage> Applications { get; set; }
    public ICollection<Translation> Translations { get; set; }
    public string Name { get; set; }
    public string Id { get; set; }

    public override void Configure(EntityTypeBuilder<Language> builder)
    {
        builder.HasKey(x => x.Id);

        builder.HasMany(x => x.Translations)
            .WithOne(x => x.Language)
            .HasForeignKey(x => x.LanguageId);
    }
}