#region Header

// /*

// Author: Rod Johnson, Architect, rodmjay@gmail.com
// */

#endregion


namespace TranslationPro.Base.Common.Data.Interfaces
{
    public interface IUserAudited :
        IAudited,
        IUserCreationAudited,
        IUserModificationAudited
    {
    }
}