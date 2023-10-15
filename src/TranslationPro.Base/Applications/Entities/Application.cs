using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using TranslationPro.Base.Common.Data.Bases;
using TranslationPro.Base.Languages.Entities;

namespace TranslationPro.Base.Applications.Entities
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
