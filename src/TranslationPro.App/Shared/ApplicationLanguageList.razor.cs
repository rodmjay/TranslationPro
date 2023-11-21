using Microsoft.AspNetCore.Components;
using System.Collections.Generic;
using System.Threading.Tasks;
using System;
using TranslationPro.Shared.Interfaces;
using TranslationPro.Shared.Models;
using TranslationPro.App.Extensions;

namespace TranslationPro.App.Shared
{
    public partial class ApplicationLanguageList : ComponentBase
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

        private bool Disabled { get; set; }

        protected override async Task OnInitializedAsync()
        {
            await LoadData();
        }

        public async Task LoadData()
        {
            this.Application = null;
            this.Disabled = true;
            Languages = await LanguagesController.GetLanguagesAsync().ConfigureAwait(true);
            Application = await ApplicationsController.GetApplicationAsync(ApplicationId).ConfigureAwait(true);

            this.Disabled = false;
        }

        private async Task HandleEnableClick(string langage)
        {
            this.Disabled = true;
            var result = await ApplicationLanguagesController.AddLanguageToApplicationAsync(ApplicationId,
                new ApplicationLanguageOptions()
                {
                    LanguageId = langage
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
