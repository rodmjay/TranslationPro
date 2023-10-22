#region Header

// /*

// Author: Rod Johnson, Architect, rodmjay@gmail.com
// */

#endregion
using System;

using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TranslationPro.Base.Applications.Entities;
using TranslationPro.Base.Common.Data.Bases;

namespace TranslationPro.Base.Languages.Entities
{
    public class ApplicationLanguage : BaseEntity<ApplicationLanguage>
    {
        public Guid ApplicationId { get; set; }
        public Application Application { get; set; }

        public Language Language { get; set; }
        public string LanguageId { get; set; }

        public override void Configure(EntityTypeBuilder<ApplicationLanguage> builder)
        {
            builder.HasKey(x => new { x.ApplicationId, x.LanguageId });

            builder.HasOne(x => x.Language)
                .WithMany(x => x.Applications)
                .HasForeignKey(x => x.LanguageId);

            builder.HasOne(x=>x.Application)
                .WithMany(x => x.Languages)
                .HasForeignKey(x => x.ApplicationId);

        }
    }
}