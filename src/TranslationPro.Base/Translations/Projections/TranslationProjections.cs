using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using TranslationPro.Base.Translations.Entities;
using TranslationPro.Base.Translations.Models;

namespace TranslationPro.Base.Translations.Projections
{
    public class TranslationProjections : Profile
    {
        public TranslationProjections()
        {
            CreateMap<Translation, TranslationDto>();
        }
    }
}
