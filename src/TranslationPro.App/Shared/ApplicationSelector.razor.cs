using System;
using System.Collections.Generic;
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

        public List<ApplicationDto> Applications { get; set; }

        public Guid? CurrentApplicationId { get; set; }

        public async Task LoadData()
        {
            CurrentApplicationId = LocalStorage.GetItem<Guid?>("ApplicationId");

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

        public void DoStuff(ChangeEventArgs e)
        {
            var applicationId = Guid.Parse(e.Value.ToString());
            LocalStorage.SetItem<Guid>("ApplicationId", applicationId);

            NavigationManager.NavigateTo($"/applications/{applicationId}");
        }
    }
}
