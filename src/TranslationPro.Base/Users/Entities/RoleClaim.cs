#region Header

// /*

// Author: Rod Johnson, Architect, rodmjay@gmail.com
// */

#endregion

using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TranslationPro.Base.Common.Data.Enums;
using TranslationPro.Base.Common.Data.Interfaces;

namespace TranslationPro.Base.Users.Entities;

public class RoleClaim : IdentityRoleClaim<int>, IObjectState, IEntityTypeConfiguration<RoleClaim>
{
    public Role Role { get; set; }

    public void Configure(EntityTypeBuilder<RoleClaim> builder)
    {
        builder.HasKey(x => x.Id);

        builder.HasOne(x => x.Role)
            .WithMany(x => x.RoleClaims)
            .HasForeignKey(x => x.RoleId);
    }

    [NotMapped] public ObjectState ObjectState { get; set; }
}