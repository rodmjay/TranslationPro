#region Header

// /*

// Author: Rod Johnson, Architect, rodmjay@gmail.com
// */

#endregion

using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TemplateBase.Common.Data.Bases;

namespace TemplateBase.Timezones.Entities
{
    public class Timezone : BaseEntity<Timezone>
    {
        public string Code { get; set; }
        public string Value { get; set; }
        public string Name { get; set; }

        public override void Configure(EntityTypeBuilder<Timezone> builder)
        {
            builder.HasKey(x => new {x.Name, x.Code});
        }
    }
}