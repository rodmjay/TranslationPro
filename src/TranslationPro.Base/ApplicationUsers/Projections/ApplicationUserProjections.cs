using AutoMapper;
using TranslationPro.Base.ApplicationUsers.Entities;
using TranslationPro.Base.ApplicationUsers.Models;

namespace TranslationPro.Base.ApplicationUsers.Projections
{
    public class ApplicationUserProjections : Profile
    {
        public ApplicationUserProjections()
        {
            CreateMap<ApplicationUser, ApplicationUserDto>()
                .ForMember(x => x.Name, opt => opt.MapFrom(x => x.User.FullName));
        }
    }
}
