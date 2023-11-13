using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TranslationPro.Base.Common.Data.Bases;
using TranslationPro.Base.Common.Data.Interfaces;
using TranslationPro.Base.Users.Entities;
using TranslationPro.Shared.Enums;

namespace TranslationPro.Base.Entities
{
    public class ApplicationUser : BaseEntity<ApplicationUser>, ISoftDelete
    {
        public int UserId { get; set; }
        public Guid ApplicationId { get; set; }

        public User User { get; set; }
        public Application Application { get; set; }
        public ApplicationRole Role { get; set; }
        public DateTime? InvitationDate { get; set; }
        public DateTime? InvitationReceivedDate { get; set; }

        public override void Configure(EntityTypeBuilder<ApplicationUser> builder)
        {
            builder.ToTable(nameof(ApplicationUser), "TranslationPro");

            builder.HasKey(x => new {x.ApplicationId, x.UserId});
            builder.HasOne(x => x.User)
                .WithMany(x => x.Applications)
                .HasForeignKey(x => x.UserId)
                .OnDelete(DeleteBehavior.Cascade);

            builder.HasOne(x => x.Application)
                .WithMany(x => x.Users)
                .HasForeignKey(x => x.ApplicationId)
                .OnDelete(DeleteBehavior.Cascade);

            builder.HasQueryFilter(x => !x.IsDeleted);
        }

        public bool IsDeleted { get; set; }
    }
}
