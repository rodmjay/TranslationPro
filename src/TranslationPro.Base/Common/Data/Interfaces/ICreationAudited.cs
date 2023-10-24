#region Header

// /*

// Author: Rod Johnson, Architect, rodmjay@gmail.com
// */

#endregion


namespace TranslationPro.Base.Common.Data.Interfaces;

public interface ICreationAudited : IHasCreationTime
{
    /// <summary>Id of the creator user of this entity.</summary>
    long? CreatorUserId { get; set; }
}