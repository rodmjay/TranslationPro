#region Header

// /*

// Author: Rod Johnson, Architect, rodmjay@gmail.com
// */

#endregion

using System.Linq;
using System.Threading.Tasks;
using TemplateBase.Common.Models;
using TemplateBase.Common.Services.Interfaces;
using TemplateBase.Geography.Entities;

namespace TemplateBase.Geography.Interfaces
{
    public interface IEnabledCountryService : IService<EnabledCountry>
    {
        IQueryable<EnabledCountry> EnabledCountries { get; }

        Task<Result> EnableCountry(string iso2);
    }
}