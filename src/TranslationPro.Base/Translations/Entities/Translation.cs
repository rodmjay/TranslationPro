using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using TranslationPro.Base.Applications.Entities;
using TranslationPro.Base.Common.Data.Bases;
using TranslationPro.Base.Languages.Entities;
using TranslationPro.Base.Translations.Interfaces;

namespace TranslationPro.Base.Translations.Entities
{
    public class Translation : BaseEntity<Translation>, ITranslation
    {
        public int Id { get; set; }
        public Guid ApplicationId { get; set; }
        public Application Application { get; set; }
        public string OriginalText { get; set; }
        public DateTime? TranslationDate { get; set; }
        public ICollection<LanguageTranslation> LanguageTranslations { get; set; }

        public override void Configure(EntityTypeBuilder<Translation> builder)
        {
            builder.HasKey(t => t.Id);

            builder.HasMany(x => x.LanguageTranslations)
                .WithOne(x => x.Translation)
                .HasForeignKey(x => x.TranslationId);

            builder.HasOne(x => x.Application)
                .WithMany(x => x.Translations)
                .HasForeignKey(x => x.ApplicationId);
        }
    }
}
