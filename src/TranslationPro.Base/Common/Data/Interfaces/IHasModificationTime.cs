#region Header

// /*

// Author: Rod Johnson, Architect, rodmjay@gmail.com
// */

#endregion

using System;

namespace TranslationPro.Base.Common.Data.Interfaces
{
    public interface IHasModificationTime
    {
        /// <summary>The last modified time for this entity.</summary>
        DateTime? Updated { get; set; }
    }
}