using Microsoft.AspNetCore.Components.Authorization;
using Microsoft.AspNetCore.Components;

namespace TranslationPro.Blazor.Pages
{
    public partial class Index
    {
        [Inject]
        protected AuthenticationStateProvider AuthenticationStateProvider { get; set; }

        [Inject]
        protected NavigationManager NavigationManager { get; set; }

        protected override async Task OnInitializedAsync()
        {
            var authState = await AuthenticationStateProvider.GetAuthenticationStateAsync();

            if (authState.User.Identity.IsAuthenticated)
            {
                NavigationManager.NavigateTo("/applications");
            }
        }
    }
}
