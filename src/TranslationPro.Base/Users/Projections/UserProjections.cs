#region Header Info

// Copyright 2023 Rod Johnson.  All rights reserved

#endregion

using AutoMapper;
using TranslationPro.Base.Users.Entities;
using TranslationPro.Base.Users.Models;

namespace TranslationPro.Base.Users.Projections;

public class UserProjections : Profile
{
    public UserProjections()
    {
        CreateMap<User, UserOutput>()
            //.ForMember(x => x.Customer, opt => opt.)
            .IncludeAllDerived();
    }
}