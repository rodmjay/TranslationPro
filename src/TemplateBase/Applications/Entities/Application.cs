using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TemplateBase.Common.Data.Bases;
using TemplateBase.Languages.Entities;

namespace TemplateBase.Applications.Entities
{
    public class Application : BaseEntity<Application>
    {
        public Guid Id { get; set; }
        public List<Language> Languages { get; set; }

        public override void Configure(EntityTypeBuilder<Application> builder)
        {
            throw new NotImplementedException();
        }
    }
}
