#region Header

// /*

// Author: Rod Johnson, Architect, rodmjay@gmail.com
// */

#endregion

using System.ComponentModel.DataAnnotations.Schema;
using System.Runtime.Serialization;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TemplateBase.Common.Data.Enums;
using TemplateBase.Common.Data.Interfaces;

namespace TemplateBase.Users.Entities
{
    public class UserLogin : IdentityUserLogin<int>, IEntityTypeConfiguration<UserLogin>, IObjectState
    {
        public User User { get; set; }

        public void Configure(EntityTypeBuilder<UserLogin> builder)
        {
            builder.HasKey(x => new
            {
                x.UserId,
                x.ProviderKey,
                x.LoginProvider
            });

            builder.HasOne(x => x.User)
                .WithMany(x => x.UserLogins)
                .HasForeignKey(x => x.UserId);
        }

        [NotMapped] [IgnoreDataMember] public ObjectState ObjectState { get; set; }
    }
}