#region Header

// /*

// Author: Rod Johnson, Architect, rodmjay@gmail.com
// */

#endregion

using AutoMapper;
using TemplateBase.Users.Entities;
using TemplateBase.Users.Models;

namespace TemplateBase.Users.Projections
{
    public class UserProjections : Profile
    {
        public UserProjections()
        {
            CreateMap<User, UserDto>()
                .IncludeAllDerived();
        }
    }
}