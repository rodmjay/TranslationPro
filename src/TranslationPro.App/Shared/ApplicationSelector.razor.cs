using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Components;
using TranslationPro.App.Extensions;
using TranslationPro.Shared.Interfaces;
using TranslationPro.Shared.Models;

namespace TranslationPro.App.Shared
{
    public partial class ApplicationSelector : ComponentBase
    {
        [Inject]
        public NavigationManager NavigationManager { get;set; }
        
        [Inject]
        private IApplicationsController ApplicationsProxy { get; set; }

        private ICollection<ApplicationOutput> Applications { get; set; }

        [CascadingParameter]
        private RouteData RouteData { get; set; }
        
        private Guid? ApplicationId { get; set; }

        public async Task LoadData()
        {
            Applications = await ApplicationsProxy.GetApplicationsAsync();
        }

        protected override async Task OnInitializedAsync()
        {
            ApplicationId = RouteData.GetApplicationId();

            await LoadData();
        }

        public void HandleApplicationChange(ChangeEventArgs e)
        {
            NavigationManager.NavigateTo($"/applications/{e.Value}");
        }
    }
}
