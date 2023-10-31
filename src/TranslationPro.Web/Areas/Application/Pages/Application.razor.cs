using System.Runtime.InteropServices;
using Microsoft.AspNetCore.Components;
using TranslationPro.Base.Applications.Interfaces;
using TranslationPro.Base.Applications.Models;

namespace TranslationPro.Web.Areas.Application.Pages
{
    public partial class Application : AuthenticatedPage
    {
        [Inject]
        public NavigationManager NavigationManager { get; set; }

        [Parameter]
        public Guid ApplicationId { get; set; }
        [Inject]
        public IApplicationService? ApplicationService { get; set; }

        private ApplicationDto _application;
        protected override async Task OnInitializedAsync()
        {
            await base.OnInitializedAsync();
            _application = await ApplicationService!.GetApplication<ApplicationDto>(ApplicationId);
        }

        public void NavigateToApplication(Guid application)
        {

        }
    }
}
