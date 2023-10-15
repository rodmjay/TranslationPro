#region Header

// /*

// Author: Rod Johnson, Architect, rodmjay@gmail.com
// */

#endregion

using System.Collections.Generic;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TranslationPro.Base.Common.Data.Bases;

namespace TranslationPro.Base.Languages.Entities
{
    public class Language : BaseEntity<Language>
    {
        public string Name { get; set; }
        public string LanguageId { get; set; }
        public string LabelId { get; set; }
        public ICollection<ApplicationLanguage> Applications { get; set; }

        public override void Configure(EntityTypeBuilder<Language> builder)
        {
            builder.HasKey(x => x.LanguageId);

        }
    }
}