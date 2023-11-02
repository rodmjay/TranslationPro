using Microsoft.AspNetCore.Components.Authorization;
using Microsoft.AspNetCore.Components;
using TranslationPro.App.Services;
using TranslationPro.Shared.Applications;

namespace TranslationPro.App.Pages
{
    public partial class ApplicationList
    {
        [CascadingParameter]
        Task<AuthenticationState> authenticationStateTask { get; set; }

        public IEnumerable<ApplicationDto> Applications { get; set; }

        [Inject]
        public IApplicationServiceProxy ApplicationService { get; set; }

        protected override async Task OnInitializedAsync()
        {
            Applications = (await ApplicationService.GetApplications()).ToList();
        }
    }
}
