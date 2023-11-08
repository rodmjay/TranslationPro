using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Components;
using Solutaris.InfoWARE.ProtectedBrowserStorage.Services;
using TranslationPro.Shared.Interfaces;
using TranslationPro.Shared.Models;

namespace TranslationPro.App.Shared
{
    public partial class ApplicationSelector
    {
        [Inject]
        public NavigationManager NavigationManager { get;set; }
        [Inject]
        public IIWLocalStorageService LocalStorage { get; set; }

        [Inject]
        public IApplicationsController ApplicationsProxy { get; set; }

        public List<ApplicationOutput> Applications { get; set; }

        public Guid? CurrentApplicationId { get; set; }

        public async Task LoadData()
        {
            Applications = await ApplicationsProxy.GetApplicationsAsync();
        }

        protected override async Task OnParametersSetAsync()
        {
            await LoadData();
        }
        

        protected override async Task OnInitializedAsync()
        {
            await LoadData();
        }

        public void HandleApplicationChange(ChangeEventArgs e)
        {
            NavigationManager.NavigateTo($"/applications/{e.Value}");
        }
    }
}
