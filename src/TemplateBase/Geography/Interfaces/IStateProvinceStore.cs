#region Header

// /*

// Author: Rod Johnson, Architect, rodmjay@gmail.com
// */

#endregion

using System.Collections.Generic;
using System.Threading.Tasks;
using TemplateBase.Geography.Models;

namespace TemplateBase.Geography.Interfaces
{
    public interface IStateProvinceStore
    {
        Task<List<T>> GetStateProvincesForCountry<T>(string id) where T : StateProvinceDto;
    }
}