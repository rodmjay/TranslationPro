#region Header

// /*

// Author: Rod Johnson, Architect, rodmjay@gmail.com
// */

#endregion

using System.ComponentModel.DataAnnotations;
using TranslationPro.Base.Common.Data.Interfaces;
using TranslationPro.Base.Common.Services.Interfaces;

namespace TranslationPro.Base.Common.Validation.Interfaces;

public interface IValidator<T> where T : class, IObjectState
{
    ValidationResult Validate(IService<T> service, T account, string value);
}