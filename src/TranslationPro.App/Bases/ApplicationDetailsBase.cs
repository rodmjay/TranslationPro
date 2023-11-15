using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Components;
using TranslationPro.Shared.Interfaces;
using TranslationPro.Shared.Models;

namespace TranslationPro.App.Bases
{
    public class ApplicationDetailsBase : ComponentBase
    {
        [Parameter]
        public Guid ApplicationId { get; set; }

        [CascadingParameter]
        public IApplicationsController ApplicationService { get; set; }

        protected ApplicationOutput Application;

        protected override async Task OnInitializedAsync()
        {
            await LoadData();
        }

        protected virtual async Task LoadData()
        {
            Application = await ApplicationService.GetApplicationAsync(ApplicationId);
        }
    }
}
