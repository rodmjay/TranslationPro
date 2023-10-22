using System;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TranslationPro.Base.Common.Data.Bases;
using TranslationPro.Base.Languages.Entities;

namespace TranslationPro.Base.Translations.Entities;

public class Phrase : BaseEntity<Phrase>
{
    public int Id { get; set; }
    public int TranslationId { get; set; }
    public Translation Translation { get; set; }
    public string LanguageId { get; set; }
    public Language Language { get; set; }
    public DateTime? TranslationDate { get; set; }

    public string TranslatedText { get; set; }
    public override void Configure(EntityTypeBuilder<Phrase> builder)
    {
        builder.HasKey(x => x.Id);
        builder.HasOne(x => x.Translation)
            .WithMany(x => x.Phrases)
            .HasForeignKey(x => x.TranslationId);
    }
}