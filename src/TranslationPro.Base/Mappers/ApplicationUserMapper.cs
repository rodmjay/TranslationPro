using AutoMapper;
using TranslationPro.Base.Entities;
using TranslationPro.Shared.Models;

namespace TranslationPro.Base.Mappers
{
    public class ApplicationUserMapper : Profile
    {
        public ApplicationUserMapper()
        {
            CreateMap<ApplicationUser, ApplicationUserOutput>()
                .ForMember(x => x.Name, opt => opt.MapFrom(x => x.User.FullName));
        }
    }
}
