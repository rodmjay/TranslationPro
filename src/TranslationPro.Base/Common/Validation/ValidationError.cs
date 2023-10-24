#region Header

// /*

// Author: Rod Johnson, Architect, rodmjay@gmail.com
// */

#endregion

using Newtonsoft.Json;

namespace TranslationPro.Base.Common.Validation;

public class ValidationError
{
    public ValidationError(string field, string message)
    {
        Field = field != string.Empty ? field : null;
        Message = message;
    }

    [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
    public string Field { get; }

    public string Message { get; }
}