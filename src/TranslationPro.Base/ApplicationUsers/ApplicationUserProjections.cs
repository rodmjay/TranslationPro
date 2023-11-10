using AutoMapper;
using TranslationPro.Base.ApplicationUsers.Entities;
using TranslationPro.Shared.Models;

namespace TranslationPro.Base.ApplicationUsers
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
