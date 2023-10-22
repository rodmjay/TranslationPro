using AutoMapper;
using TranslationPro.Base.Applications.Entities;
using TranslationPro.Base.Applications.Models;

namespace TranslationPro.Base.Applications.Projections
{
    public class ApplicationProjections : Profile
    {
        public ApplicationProjections()
        {
            CreateMap<Application, ApplicationDto>();
        }
    }
}
