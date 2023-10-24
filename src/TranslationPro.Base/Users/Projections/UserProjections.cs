#region Header

// /*

// Author: Rod Johnson, Architect, rodmjay@gmail.com
// */

#endregion

using AutoMapper;
using TranslationPro.Base.Users.Entities;
using TranslationPro.Base.Users.Models;

namespace TranslationPro.Base.Users.Projections;

public class UserProjections : Profile
{
    public UserProjections()
    {
        CreateMap<User, UserDto>()
            .IncludeAllDerived();
    }
}