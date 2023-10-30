using System.Runtime.InteropServices;
using Microsoft.AspNetCore.Components;
using TranslationPro.Base.Applications.Interfaces;
using TranslationPro.Base.Applications.Models;

namespace TranslationPro.Web.Areas.Application.Pages
{
    public partial class Applications : AuthenticatedPage
    {
        [Inject]
        public NavigationManager NavigationManager { get; set; }


        [Inject]
        public IApplicationService? ApplicationService { get; set; }

        private List<ApplicationDto> _applications;
        protected override async Task OnInitializedAsync()
        {
            await base.OnInitializedAsync();
            _applications = await ApplicationService!.GetApplicationsForUserAsync<ApplicationDto>(CurrentUser.Id);
        }

        public void NavigateToApplication(Guid application)
        {

        }
    }
}
