using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TranslationPro.Base.Common.Data.Bases;
using TranslationPro.Shared.Enums;

namespace TranslationPro.Base.Entities;

public class JobPhrase : BaseEntity<JobPhrase>
{
    public int PhraseId { get; set; }
    public Phrase Phrase { get; set; }
    public int JobId { get; set; }
    public Job Job { get; set; }
    public JobPhraseStatus Status { get; set; }

    public override void Configure(EntityTypeBuilder<JobPhrase> builder)
    {
        builder.ToTable(nameof(JobPhrase), "TranslationPro");
        builder.HasKey(x=>new{x.JobId, x.PhraseId});

        builder.HasOne(x => x.Phrase).WithMany(x => x.Jobs).HasForeignKey(x => x.PhraseId);
        builder.HasOne(x => x.Job).WithMany(x => x.Phrases).HasForeignKey(x => x.JobId);
    }
}