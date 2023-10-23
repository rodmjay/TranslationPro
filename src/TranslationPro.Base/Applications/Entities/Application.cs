using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using TranslationPro.Base.Common.Data.Bases;
using TranslationPro.Base.Languages.Entities;
using TranslationPro.Base.Users.Entities;
using TranslationPro.Base.Applications.Interfaces;
using TranslationPro.Base.Phrases.Entities;
using TranslationPro.Base.Translations.Entities;

namespace TranslationPro.Base.Applications.Entities
{
    public class Application : BaseEntity<Application>, IApplication
    {
        public Application()
        {
            this.Languages = new List<ApplicationLanguage>();
            this.Phrases = new List<Phrase>();
            this.Translations = new List<Translation>();
        }
        public Guid Id { get; set; }
        public string Name { get; set; }
        public ICollection<ApplicationLanguage> Languages { get; set; }
        public ICollection<Translation> Translations { get; set; }
        public List<Phrase> Phrases { get; set; }
        public User User { get; set; }
        public int UserId { get; set; }
        public override void Configure(EntityTypeBuilder<Application> builder)
        {
            builder.HasKey(x => x.Id);
            
            builder.HasOne(x => x.User)
                .WithMany(x => x.Applications)
                .HasForeignKey(x => x.UserId)
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
