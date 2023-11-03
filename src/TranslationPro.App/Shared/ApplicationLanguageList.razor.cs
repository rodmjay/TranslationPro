using Microsoft.AspNetCore.Components;
using System.Collections.Generic;
using System.Threading.Tasks;
using System;
using TranslationPro.Shared.Interfaces;
using TranslationPro.Shared.Models;
using Solutaris.InfoWARE.ProtectedBrowserStorage.Services;

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

        [Inject]
        public IIWLocalStorageService LocalStorage { get; set; }
        public List<LanguageDto> Languages { get; set; }

        [Parameter]
        public EventCallback LanguagesChanged { get; set; }

        public Guid ApplicationId => LocalStorage.GetItem<Guid>("ApplicationId");

        public ApplicationDto Application { get; set; }

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
                new ApplicationLanguageInput()
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
