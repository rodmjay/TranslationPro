using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TranslationPro.Base.Common.Data.Bases;
using TranslationPro.Base.Stripe.Interfaces;
using TranslationPro.Shared.Enums;

namespace TranslationPro.Base.Entities
{
    public class Job : BaseEntity<Job>, ICreated
    {
        public Job()
        {
            Languages = new List<JobLanguage>();
            Phrases = new List<JobPhrase>();
        }
        public int Id { get; set; }

        public Guid ApplicationId { get; set; }
        public Application Application { get; set; }
        public JobStatus Status { get; set; }
        public ICollection<JobLanguage> Languages { get; set; }
        public ICollection<JobPhrase> Phrases { get; set; }

        public override void Configure(EntityTypeBuilder<Job> builder)
        {
            builder.ToTable(nameof(Job), "TranslationPro");
            builder.HasKey(x=>x.Id);

            builder.Property(x => x.Id).UseIdentityColumn(1);

            builder.HasOne(x => x.Application)
                .WithMany(x => x.Jobs)
                .HasForeignKey(x => x.ApplicationId);
        }

        public DateTimeOffset Created { get; set; }
    }
}
