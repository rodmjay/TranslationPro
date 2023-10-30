using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Authorization;
using TranslationPro.Base.ApplicationUsers.Interfaces;
using TranslationPro.Base.ApplicationUsers.Models;

namespace TranslationPro.Web.Areas.Application.Pages
{
    public partial class Users : AuthenticatedPage
    {
        [Inject]
        public IApplicationUserService? ApplicationUserService { get; set; }

        [Parameter]
        public Guid ApplicationId { get; set; }

        private List<ApplicationUserDto>? _users;

        protected override async Task OnInitializedAsync()
        {
            
            _users = await ApplicationUserService?.GetUsersForApplication<ApplicationUserDto>(ApplicationId)!;
        }
    }
}
