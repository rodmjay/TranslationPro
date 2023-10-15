#region Header

// /*

// Author: Rod Johnson, Architect, rodmjay@gmail.com
// */

#endregion

using System.Collections.Generic;

namespace TranslationPro.Base.Common.Validation.Interfaces
{
    public interface IValidationContainer
    {
        IDictionary<string, IList<string>> ValidationErrors { get; }
        bool IsValid { get; }
    }

    public interface IValidationContainer<out T> : IValidationContainer
    {
        T Entity { get; }
    }
}