using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using TemplateBase.Common.Data.Bases;

namespace TemplateBase.Translations.Entities
{
    public class Translation : BaseEntity<Translation>
    {
        public int Id { get; set; }
        public string TranslatedLangulage { get; set; }
        public string OriginalLanguage { get; set; }
        public string OriginalText { get; set; }
        public string TranslatedText { get; set; }
        public DateTime? TranslationDate { get; set; }

        public override void Configure(EntityTypeBuilder<Translation> builder)
        {
            throw new NotImplementedException();
        }
    }
}
