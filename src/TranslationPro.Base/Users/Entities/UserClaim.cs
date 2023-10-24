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
using TranslationPro.Base.Common.Data.Enums;
using TranslationPro.Base.Common.Data.Interfaces;

namespace TranslationPro.Base.Users.Entities;

public class UserClaim : IdentityUserClaim<int>, IEntityTypeConfiguration<UserClaim>, IObjectState
{
    public User User { get; set; }

    public void Configure(EntityTypeBuilder<UserClaim> builder)
    {
        builder.HasKey(x => x.Id);

        builder.HasOne(x => x.User)
            .WithMany(x => x.UserClaims)
            .HasForeignKey(x => x.UserId);
    }

    [NotMapped] [IgnoreDataMember] public ObjectState ObjectState { get; set; }
}