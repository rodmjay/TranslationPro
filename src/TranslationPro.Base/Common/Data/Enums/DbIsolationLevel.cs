#region Header

// /*

// Author: Rod Johnson, Architect, rodmjay@gmail.com
// */

#endregion


namespace TranslationPro.Base.Common.Data.Enums
{
    public enum DbIsolationLevel
    {
        Chaos,
        ReadCommitted,
        ReadUncommitted,
        RepeatableRead,
        Serializable,
        Snapshot,
        Unspecified
    }
}