#region Header

// /*

// Author: Rod Johnson, Architect, rodmjay@gmail.com
// */

#endregion

using AutoMapper;
using TemplateBase.Common.Models;
using TemplateBase.Geography.Entities;
using TemplateBase.Geography.Models;

namespace TemplateBase.Geography.Projections
{
    public class CountryProjections : Profile
    {
        public CountryProjections()
        {
            CreateMap<Country, CountryDto>()
                .IncludeAllDerived();

            CreateMap<Country, CountryWithStateProvinces>()
                .ForMember(x => x.StateProvinces, opt => opt.MapFrom(x => x.StateProvinces))
                .IncludeAllDerived();

            CreateMap<Country, DropdownItem>()
                .ForMember(x => x.Name, opt => opt.MapFrom(x => x.Name))
                .ForMember(x => x.Value, opt => opt.MapFrom(x => x.Iso2));
        }
    }
}