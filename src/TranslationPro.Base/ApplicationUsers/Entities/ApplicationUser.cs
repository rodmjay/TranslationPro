using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TranslationPro.Base.Applications.Entities;
using TranslationPro.Base.Common.Data.Bases;
using TranslationPro.Base.Users.Entities;

namespace TranslationPro.Base.ApplicationUsers.Entities
{
    public enum ApplicationRole
    {
        Owner,
        Contributor
    }
    public class ApplicationUser : BaseEntity<ApplicationUser>
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
            builder.HasKey(x => new {x.ApplicationId, x.UserId});
            builder.HasOne(x => x.User)
                .WithMany(x => x.Applications)
                .HasForeignKey(x => x.UserId)
                .OnDelete(DeleteBehavior.Cascade);

            builder.HasOne(x => x.Application)
                .WithMany(x => x.Users)
                .HasForeignKey(x => x.ApplicationId)
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
