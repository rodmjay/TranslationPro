#region Header

// /*

// Author: Rod Johnson, Architect, rodmjay@gmail.com
// */

#endregion

using TemplateBase.Common.Models;

namespace TemplateBase.Geography.Models
{
    public class GeographyErrorDescriber
    {
        public virtual Error EnableCountryError()
        {
            return new()
            {
                Code = nameof(EnableCountryError),
                Description = "Unable to enable country"
            };
        }

        public virtual Error CountryAlreadyEnabled()
        {
            return new()
            {
                Code = nameof(CountryAlreadyEnabled),
                Description = "country already enabled"
            };
        }
    }
}