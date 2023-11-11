#region Header Info

// Copyright 2023 Rod Johnson.  All rights reserved

#endregion

using System;
using System.Linq;
using AutoMapper;
using TranslationPro.Base.Phrases.Entities;
using TranslationPro.Shared.Models;

namespace TranslationPro.Base.Phrases;

public class PhaseProjections : Profile
{
    public PhaseProjections()
    {


        CreateMap<ApplicationPhrase, PhraseOutput>().IncludeAllDerived();

        CreateMap<ApplicationPhrase, PhraseWithTranslation>()
            .ForMember(x => x.MachineTranslations, opt => opt
                .MapFrom(x => x.Phrase.MachineTranslations.Where(mt => mt.Text != null)))
            .ForMember(x => x.HumanTranslations, opt => opt
                .MapFrom(x => x.HumanTranslations.Where(ht=>ht.Text != null)));
    }
}