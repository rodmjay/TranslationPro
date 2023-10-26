#region Header Info

// Copyright 2023 Rod Johnson.  All rights reserved

#endregion

using AutoMapper;
using TranslationPro.Base.Languages.Entities;
using TranslationPro.Base.Languages.Models;

namespace TranslationPro.Base.Languages.Projections;

public class LanguageProjections : Profile
{
    public LanguageProjections()
    {
        CreateMap<Language, LanguageDto>();
    }
}