#region Header

// /*

// Author: Rod Johnson, Architect, rodmjay@gmail.com
// */

#endregion

using TemplateBase.Users.Entities;

namespace TemplateBase.Common.Data.Interfaces
{
    public interface IUserCreationAudited : ICreationAudited, IHasCreationTime
    {
        /// <summary>Reference to the creator user of this entity.</summary>
        User CreatorUser { get; set; }
    }
}