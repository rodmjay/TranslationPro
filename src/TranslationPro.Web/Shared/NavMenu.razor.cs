using Google.Apis.Auth.OAuth2;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Authorization;
using TranslationPro.Base.Applications.Interfaces;
using TranslationPro.Base.Applications.Models;
using TranslationPro.Base.Users.Interfaces;
using TranslationPro.Base.Users.Managers;

namespace TranslationPro.Web.Shared
{
 

    public partial class NavMenu
    {
        [Inject]
        public IApplicationService? ApplicationService
        {
            get;
            set;
        }

        [Inject]
        public UserManager? UserManager { get; set; }

        [Inject]
        public AuthenticationStateProvider? StateProvider { get; set; }

        [CascadingParameter]
        public IUser? CurrentUser { get; set; }

        public IList<ApplicationDto>? Applications { get; set; }

        protected async override Task OnInitializedAsync()
        {
            var authState = await StateProvider!
                .GetAuthenticationStateAsync();

            CurrentUser = await UserManager!.GetUserAsync(authState.User);

            if (CurrentUser != null)
            {
                Applications = await ApplicationService!.GetApplicationsForUserAsync<ApplicationDto>(CurrentUser!.Id);
            }
        }
    }
}
