using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using TranslationPro.Base.Applications.Entities;
using TranslationPro.Base.Common.Data.Bases;
using TranslationPro.Base.Phrases.Interfaces;
using TranslationPro.Base.Translations.Entities;

namespace TranslationPro.Base.Phrases.Entities
{
    public class Phrase : BaseEntity<Phrase>, IPhrase
    {
        public Phrase()
        {
            Translations = new List<Translation>();
        }
        public int Id { get; set; }
        public Guid ApplicationId { get; set; }
        public Application Application { get; set; }
        public string Text { get; set; }
        public ICollection<Translation> Translations { get; set; }

        public override void Configure(EntityTypeBuilder<Phrase> builder)
        {
            builder.HasKey(t => new { t.ApplicationId, t.Id });

            builder.HasMany(x => x.Translations)
                .WithOne(x => x.Phrase)
                .HasForeignKey(x => x.PhraseId);

            builder.HasOne(x => x.Application)
                .WithMany(x => x.Phrases)
                .HasForeignKey(x => x.ApplicationId);
        }
    }
}
