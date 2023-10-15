#region Header

// /*

// Author: Rod Johnson, Architect, rodmjay@gmail.com
// */

#endregion

using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TemplateBase.Common.Data.Bases;

namespace TemplateBase.Geography.Entities
{
    public class EnabledCountry : BaseEntity<EnabledCountry>
    {
        public string Iso2 { get; set; }
        public Country Country { get; set; }

        public override void Configure(EntityTypeBuilder<EnabledCountry> builder)
        {
            builder.HasKey(x => x.Iso2);

            builder.HasOne(x => x.Country)
                .WithOne(x => x.EnabledCountry)
                .HasForeignKey<EnabledCountry>(x => x.Iso2);
        }
    }
}