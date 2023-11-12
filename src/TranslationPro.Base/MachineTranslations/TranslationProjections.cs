#region Header Info

// Copyright 2023 Rod Johnson.  All rights reserved

#endregion

using AutoMapper;
using TranslationPro.Base.MachineTranslations.Entities;
using TranslationPro.Base.Phrases.Entities;
using TranslationPro.Shared.Models;

namespace TranslationPro.Base.MachineTranslations;

public class TranslationProjections : Profile
{
    public TranslationProjections()
    {
        CreateMap<MachineTranslation, MachineTranslationOutput>()
            .ForMember(x => x.Engine, opt => opt.MapFrom(x => x.Engine.Name));

    }
}