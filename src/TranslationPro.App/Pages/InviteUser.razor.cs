using Microsoft.AspNetCore.Components;
using TranslationPro.App.Pages.Bases;
using TranslationPro.Shared.Interfaces;
using TranslationPro.Shared.Models;

namespace TranslationPro.App.Pages
{
    public partial class InviteUser : ApplicationDetailsBase
    {
        [Inject]
        public NavigationManager NavigationManager { get; set; }

        public CreateApplicationUser Input { get; set; } = new CreateApplicationUser();

        [Inject]
        public IApplicationUsersController ApplicationsUsersController { get; set; }

        protected override async Task OnInitializedAsync()
        {
            await base.OnInitializedAsync();
        }


        private async Task HandleSubmit()
        {
            var result = await ApplicationsUsersController.InviteUserAsync(ApplicationId, Input);

            if (result.Succeeded)
            {
                NavigationManager.NavigateTo($"/applications/{ApplicationId}/users");
            }
        }
    }
}
