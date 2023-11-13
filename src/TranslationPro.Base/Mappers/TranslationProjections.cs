#region Header Info

// Copyright 2023 Rod Johnson.  All rights reserved

#endregion

using AutoMapper;
using TranslationPro.Base.Entities;
using TranslationPro.Shared.Models;

namespace TranslationPro.Base.Mappers;

public class TranslationProjections : Profile
{
    public TranslationProjections()
    {
        CreateMap<MachineTranslation, MachineTranslationOutput>()
            .ForMember(x => x.Engine, opt => opt.MapFrom(x => x.Engine.Name));

    }
}