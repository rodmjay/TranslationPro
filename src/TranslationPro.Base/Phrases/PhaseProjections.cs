#region Header Info

// Copyright 2023 Rod Johnson.  All rights reserved

#endregion

using System.Linq;
using AutoMapper;
using TranslationPro.Base.Phrases.Entities;
using TranslationPro.Shared.Models;

namespace TranslationPro.Base.Phrases;

public class PhaseProjections : Profile
{
    public PhaseProjections()
    {
        CreateMap<ApplicationPhrase, PhraseOutput>()
            .ForMember(x => x.TranslationCount,
                opt => opt.MapFrom(x => x.MachineTranslations.Count))
            .ForMember(x => x.PendingTranslationCount,
                opt => opt.MapFrom(x => x.MachineTranslations.Count(t => t.Text == null)));
    }
}