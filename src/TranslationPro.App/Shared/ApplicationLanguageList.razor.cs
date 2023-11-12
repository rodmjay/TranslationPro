using Microsoft.AspNetCore.Components;
using System.Collections.Generic;
using System.Threading.Tasks;
using System;
using TranslationPro.Shared.Interfaces;
using TranslationPro.Shared.Models;
using Solutaris.InfoWARE.ProtectedBrowserStorage.Services;
using TranslationPro.App.Extensions;

namespace TranslationPro.App.Shared
{
    public partial class ApplicationLanguageList
    {
        [Inject]
        public IApplicationsController ApplicationsController { get; set; }

        [Inject]
        public ILanguagesController LanguagesController { get; set; }

        [Inject]
        public IApplicationLanguagesController ApplicationLanguagesController { get; set; }
        [Inject]
        public NavigationManager Navigation { get; set; }
        
        public ICollection<LanguageOutput> Languages { get; set; }

        [CascadingParameter]
        private RouteData RouteData { get; set; }

        [Parameter]
        public EventCallback LanguagesChanged { get; set; }

        public Guid ApplicationId => RouteData.GetApplicationId();

        public ApplicationOutput Application { get; set; }

        protected override async Task OnInitializedAsync()
        {
            await LoadData();
        }

        public async Task LoadData()
        {
            this.Application = null;
            Languages = await LanguagesController.GetLanguagesAsync();
            Application = await ApplicationsController.GetApplicationAsync(ApplicationId);
        }

        private async Task HandleEnableClick(string langage)
        {
            var result = await ApplicationLanguagesController.AddLanguageToApplicationAsync(ApplicationId,
                new ApplicationLanguageOptions()
                {
                    Language = langage
                });

            await OnInitializedAsync();
            await LanguagesChanged.InvokeAsync();


        }

        private async Task HandleDisableClick(string langage)
        {
            var result = await ApplicationLanguagesController.RemoveLanguageFromApplicationAsync(ApplicationId,
                langage);

           
            await OnInitializedAsync();
            await LanguagesChanged.InvokeAsync();
        }
    }
}
