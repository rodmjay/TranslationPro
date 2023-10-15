#region Header

// /*

// Author: Rod Johnson, Architect, rodmjay@gmail.com
// */

#endregion

using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TemplateBase.Common.Data.Bases;
using TemplateBase.Geography.Interfaces;

namespace TemplateBase.Geography.Entities
{
    public class StateProvince : BaseEntity<StateProvince>, IStateProvince
    {
        public int Id { get; set; }
        public Country Country { get; set; }
        public string Iso2 { get; set; }

        public string Name { get; set; }
        public string Abbrev { get; set; }
        public string Code { get; set; }

        public override void Configure(EntityTypeBuilder<StateProvince> builder)
        {
            builder.HasKey(x => x.Id);

            builder.HasOne(x => x.Country)
                .WithMany(x => x.StateProvinces)
                .HasForeignKey(x => x.Iso2);
        }
    }
}