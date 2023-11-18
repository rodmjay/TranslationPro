using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TranslationPro.Base.Common.Data.Bases;
using TranslationPro.Shared.Enums;

namespace TranslationPro.Base.Entities;

public class JobLanguage : BaseEntity<JobLanguage>
{
    public string LanguageId { get; set; }
    public Language Language { get; set; }
    public int JobId { get; set; }
    public Job Job { get; set; }
    public JobStatus Status { get; set; }
    public override void Configure(EntityTypeBuilder<JobLanguage> builder)
    {
        builder.ToTable(nameof(JobLanguage), "TranslationPro");
        builder.HasKey(x => new{x.JobId, x.LanguageId});

        builder.HasOne(x => x.Job)
            .WithMany(x => x.Languages)
            .HasForeignKey(x => x.JobId);

        builder.HasOne(x => x.Language).WithMany(x => x.Jobs)
            .HasForeignKey(x => x.LanguageId);
    }
}