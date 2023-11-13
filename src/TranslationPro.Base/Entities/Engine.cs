using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TranslationPro.Base.Common.Data.Bases;
using TranslationPro.Base.Interfaces;
using TranslationPro.Shared.Enums;

namespace TranslationPro.Base.Entities
{
    [ExcludeFromCodeCoverage]
    public class Engine : BaseEntity<Engine>, IEngine
    {
        public TranslationEngine Id { get; set; }
        public string Name { get; set; }
        public bool Enabled { get; set; }

        public ICollection<EngineLanguage> Languages { get; set; }
        public ICollection<MachineTranslation> MachineTranslations { get; set; }

        public override void Configure(EntityTypeBuilder<Engine> builder)
        {
            builder.ToTable(nameof(Engine), "TranslationPro");

            builder.HasKey(x => x.Id);

        }
    }
}
