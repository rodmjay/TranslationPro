#region Header Info

// Copyright 2023 Rod Johnson.  All rights reserved

#endregion

using System.Collections.Generic;
using AutoMapper;
using TranslationPro.Base.Phrases.Entities;
using TranslationPro.Base.Translations.Entities;
using TranslationPro.Shared.Models;

namespace TranslationPro.Base.Translations;

public class TranslationProjections : Profile
{
    public TranslationProjections()
    {
        CreateMap<MachineTranslation, MachineTranslationOutput>()
            .ForMember(x => x.Engine, opt => opt.MapFrom(x => x.Engine.Name));

        CreateMap<ApplicationTranslation, ApplicationTranslationOutput>()
            .IncludeAllDerived();
    }
}