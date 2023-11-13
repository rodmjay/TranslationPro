using AutoMapper;
using TranslationPro.Base.Entities;
using TranslationPro.Shared.Models;

namespace TranslationPro.Base.Mappers
{
    public class ApplicationUserProjections : Profile
    {
        public ApplicationUserProjections()
        {
            CreateMap<ApplicationUser, ApplicationUserOutput>()
                .ForMember(x => x.Name, opt => opt.MapFrom(x => x.User.FullName));
        }
    }
}
