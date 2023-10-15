#region Header

// /*

// Author: Rod Johnson, Architect, rodmjay@gmail.com
// */

#endregion

using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc.ModelBinding;

namespace TranslationPro.Base.Common.Validation
{
    public class ValidationResultModel
    {
        public ValidationResultModel()
        {
            Message = "Internal Server Error";
            Errors = new List<ValidationError>();
        }

        public ValidationResultModel(ModelStateDictionary modelState)
        {
            Message = "Validation Failed";
            Errors = modelState.Keys
                .SelectMany(key => modelState[key].Errors.Select(x => new ValidationError(key, x.ErrorMessage)))
                .ToList();
        }

        public string Message { get; }

        public List<ValidationError> Errors { get; }
    }
}