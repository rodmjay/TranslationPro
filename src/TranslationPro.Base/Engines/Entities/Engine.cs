using System.Collections.Generic;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TranslationPro.Base.Common.Data.Bases;
using TranslationPro.Base.Translations.Entities;
using TranslationPro.Shared.Enums;

namespace TranslationPro.Base.Engines.Entities
{
    public class Engine : BaseEntity<Engine>
    {
        public TranslationEngine Id { get; set; }
        public string Name { get; set; }
        public bool Enabled { get; set; }

        public ICollection<ApplicationEngine> Applications { get; set; }
        public ICollection<EngineLanguage> Languages { get; set; }
        public ICollection<MachineTranslation> MachineTranslations { get; set; }

        public override void Configure(EntityTypeBuilder<Engine> builder)
        {
            builder.HasKey(x => x.Id);

        }
    }
}
