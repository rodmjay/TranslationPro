using AutoMapper;
using TranslationPro.Base.ApplicationUsers.Entities;
using TranslationPro.Shared.ApplicationUsers;

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
