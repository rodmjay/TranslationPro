#region Header

// /*

// Author: Rod Johnson, Architect, rodmjay@gmail.com
// */

#endregion

using System.Collections.Generic;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TemplateBase.Common.Data.Bases;

namespace TemplateBase.Languages.Entities
{
    public class Language : BaseEntity<Language>
    {
        public string Name { get; set; }
        public string NativeName { get; set; }
        public string Code2 { get; set; }
        public string Code3 { get; set; }
        public virtual ICollection<LanguageCountry> Countries { get; set; }

        public override void Configure(EntityTypeBuilder<Language> builder)
        {
            builder.HasKey(x => x.Code3);

            builder.HasMany(x => x.Countries)
                .WithOne(x => x.Language)
                .HasForeignKey(x => x.Code3);
        }
    }
}