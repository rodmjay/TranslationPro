#region Header

// /*

// Author: Rod Johnson, Architect, rodmjay@gmail.com
// */

#endregion

using TemplateBase.Users.Entities;

namespace TemplateBase.Common.Data.Interfaces
{
    public interface IUserModificationAudited : IModificationAudited
    {
        /// <summary>Reference to the last modifier user of this entity.</summary>
        User LastModifierUser { get; set; }
    }
}