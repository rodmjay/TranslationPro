using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TranslationPro.Base.Common.Data.Bases;

namespace TranslationPro.Base.Engines.Entities
{
    public class Engine : BaseEntity<Engine>
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public bool Enabled { get; set; }

        public ICollection<ApplicationEngine> Applications { get; set; }
        public ICollection<EngineLanguage> Languages { get; set; }

        public override void Configure(EntityTypeBuilder<Engine> builder)
        {
            builder.HasKey(x => x.Id);

        }
    }
}
