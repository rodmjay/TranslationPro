#region Header Info

// Copyright 2023 Rod Johnson.  All rights reserved

#endregion

using System.Collections.Generic;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TranslationPro.Base.ApplicationLanguages.Entities;
using TranslationPro.Base.Common.Data.Bases;
using TranslationPro.Base.Engines.Entities;
using TranslationPro.Base.Translations.Entities;
using TranslationPro.Shared.Interfaces;

namespace TranslationPro.Base.Languages.Entities;

public class Language : BaseEntity<Language>, ILanguage
{
    public Language()
    {
        Translations = new List<ApplicationTranslation>();
    }
    public ICollection<ApplicationEngineLanguage> Applications { get; set; }
    public ICollection<ApplicationTranslation> Translations { get; set; }
    public ICollection<EngineLanguage> Engines { get; set; }
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