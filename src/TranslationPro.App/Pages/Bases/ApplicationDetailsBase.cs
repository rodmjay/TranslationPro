using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Components;
using Solutaris.InfoWARE.ProtectedBrowserStorage.Services;
using TranslationPro.Shared.Interfaces;
using TranslationPro.Shared.Models;

namespace TranslationPro.App.Pages.Bases
{
    public class ApplicationDetailsBase : ComponentBase
    {
        [Inject]
        public IIWLocalStorageService LocalStorage { get; set; }
        [Parameter]
        public Guid ApplicationId { get; set; }

        [Inject]
        public IApplicationsController ApplicationService { get; set; }

        protected ApplicationDto Application;

        protected async override Task OnInitializedAsync()
        {
            await LoadData();
        }

        protected override async Task OnParametersSetAsync()
        {
            await OnInitializedAsync();
        }

        protected async Task LoadData()
        {
            if (ApplicationId != Guid.Empty)
            {
                await LocalStorage.SetItemAsync("ApplicationId", ApplicationId);
            }

            Application = await ApplicationService.GetApplicationAsync(ApplicationId);
        }
    }
}
