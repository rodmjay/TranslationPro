#region Header

// /*

// Author: Rod Johnson, Architect, rodmjay@gmail.com
// */

#endregion

using System.Collections.Generic;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TranslationPro.Base.Common.Data.Bases;
using TranslationPro.Base.Languages.Interfaces;
using TranslationPro.Base.Translations.Entities;

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