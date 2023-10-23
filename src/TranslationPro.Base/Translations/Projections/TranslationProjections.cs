﻿using AutoMapper;
using TranslationPro.Base.Phrases.Entities;
using TranslationPro.Base.Phrases.Models;
using TranslationPro.Base.Translations.Entities;
using TranslationPro.Base.Translations.Models;

namespace TranslationPro.Base.Translations.Projections
{
    public class TranslationProjections : Profile
    {
        public TranslationProjections()
        {
            CreateMap<Phrase, PhraseDto>();

            CreateMap<Translation, TranslationDto>()
                .ForMember(x => x.LanguageName, opt => opt.MapFrom(x => x.Language.Name));
        }
    }
}
