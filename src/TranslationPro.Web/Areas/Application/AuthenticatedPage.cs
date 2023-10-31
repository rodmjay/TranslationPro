using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Authorization;
using TranslationPro.Base.Users.Entities;
using TranslationPro.Base.Users.Interfaces;
using TranslationPro.Base.Users.Managers;

namespace TranslationPro.Web.Areas.Application
{
    public class AuthenticatedPage : ComponentBase
    {
        [Inject]
        public UserManager? UserManager { get; set; }

        [Inject]
        public AuthenticationStateProvider? StateProvider { get; set; }

        [CascadingParameter]
        public IUser? CurrentUser { get; set; }

        protected override async Task OnInitializedAsync()
        {
            var authState = await StateProvider!
                .GetAuthenticationStateAsync();
            
            CurrentUser = await UserManager!.GetUserAsync(authState.User);
        }
    }
}
