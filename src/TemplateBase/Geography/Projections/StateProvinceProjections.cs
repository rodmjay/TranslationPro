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
    public class StateProvinceProjections : Profile
    {
        public StateProvinceProjections()
        {
            CreateMap<StateProvince, StateProvinceDto>()
                .IncludeAllDerived();

            CreateMap<StateProvince, DropdownItem>()
                .ForMember(x => x.Name, opt => opt.MapFrom(x => x.Name))
                .ForMember(x => x.Value, opt => opt.MapFrom(x => x.Id));
        }
    }
}