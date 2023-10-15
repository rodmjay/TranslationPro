#region Header

// /*

// Author: Rod Johnson, Architect, rodmjay@gmail.com
// */

#endregion

using System;
using System.Linq.Expressions;
using System.Threading.Tasks;
using TemplateBase.Common.Models;
using TemplateBase.Geography.Entities;
using TemplateBase.Geography.Models;

namespace TemplateBase.Geography.Interfaces
{
    public interface ICountryStore
    {
        Task<T> GetCountry<T>(string iso2) where T : CountryDto;

        Task<PagedList<T>> GetCountries<T>(Expression<Func<Country, bool>> predicate, PagingQuery paging)
            where T : CountryDto;
    }
}