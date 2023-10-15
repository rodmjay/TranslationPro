#region Header

// /*

// Author: Rod Johnson, Architect, rodmjay@gmail.com
// */

#endregion


namespace TranslationPro.Base.Common.Data.Interfaces
{
    public interface IMayHaveTenant
    {
        /// <summary>TenantId of this entity.</summary>
        int? TenantId { get; set; }
    }
}