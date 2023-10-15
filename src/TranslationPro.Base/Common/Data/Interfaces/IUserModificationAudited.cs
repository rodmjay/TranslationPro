#region Header

// /*

// Author: Rod Johnson, Architect, rodmjay@gmail.com
// */

#endregion

using TranslationPro.Base.Users.Entities;

namespace TranslationPro.Base.Common.Data.Interfaces
{
    public interface IUserModificationAudited : IModificationAudited
    {
        /// <summary>Reference to the last modifier user of this entity.</summary>
        User LastModifierUser { get; set; }
    }
}