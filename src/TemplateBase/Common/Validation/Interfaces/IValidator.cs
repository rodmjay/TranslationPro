#region Header

// /*

// Author: Rod Johnson, Architect, rodmjay@gmail.com
// */

#endregion

using System.ComponentModel.DataAnnotations;
using TemplateBase.Common.Data.Interfaces;
using TemplateBase.Common.Services.Interfaces;

namespace TemplateBase.Common.Validation.Interfaces
{
    public interface IValidator<T> where T : class, IObjectState
    {
        ValidationResult Validate(IService<T> service, T account, string value);
    }
}