using Microsoft.AspNetCore.Components;
using TranslationPro.Shared.Interfaces;
using TranslationPro.Shared.Models;

namespace TranslationPro.App.Pages.Bases
{
    public class ApplicationDetailsBase : ComponentBase
    {
        [Parameter]
        public Guid ApplicationId { get; set; }

        [Inject]
        public IApplicationsController ApplicationService { get; set; }

        protected ApplicationDto Application;

        protected async override Task OnInitializedAsync()
        {
            Application = await ApplicationService.GetApplicationAsync(ApplicationId);
        }
    }
}
