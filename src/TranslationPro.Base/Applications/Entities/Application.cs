using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using TranslationPro.Base.Common.Data.Bases;
using TranslationPro.Base.Languages.Entities;
using TranslationPro.Base.Translations.Entities;
using TranslationPro.Base.Users.Entities;

namespace TranslationPro.Base.Applications.Entities
{
    public class Application : BaseEntity<Application>
    {
        public Guid Id { get; set; }
        public List<ApplicationLanguage> Languages { get; set; }
        public List<Translation> Translations { get; set; }
        public User User { get; set; }
        public int UserId { get; set; }
        public string ApiKey { get; set; }
        public override void Configure(EntityTypeBuilder<Application> builder)
        {
            builder.HasKey(x => x.Id);

            builder.HasMany(x => x.Languages)
                .WithOne(x => x.Application)
                .HasForeignKey(x => x.LanguageId);

            builder.HasOne(x => x.User)
                .WithMany(x => x.Applications)
                .HasForeignKey(x => x.UserId)
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
