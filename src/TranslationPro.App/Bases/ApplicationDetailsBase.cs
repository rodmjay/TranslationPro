using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Components;
using Solutaris.InfoWARE.ProtectedBrowserStorage.Services;
using TranslationPro.Shared.Interfaces;
using TranslationPro.Shared.Models;

namespace TranslationPro.App.Bases
{
    public class ApplicationDetailsBase : ComponentBase
    {
        [Parameter]
        public Guid ApplicationId { get; set; }

        [Inject]
        public IApplicationsController ApplicationService { get; set; }

        protected ApplicationOutput Application;

        protected override async Task OnInitializedAsync()
        {
            await LoadData();
        }

        protected override async Task OnParametersSetAsync()
        {
            await OnInitializedAsync();
        }

        protected virtual async Task LoadData()
        {
            Application = await ApplicationService.GetApplicationAsync(ApplicationId);
        }
    }
}
