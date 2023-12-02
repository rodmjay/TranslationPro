using Microsoft.AspNetCore.Components;
using TranslationPro.Blazor.Components.Application.Bases;
using TranslationPro.Blazor.Components.Application.Components;
using TranslationPro.Blazor.Events;
using TranslationPro.Shared.Interfaces;
using TranslationPro.Shared.Models;

namespace TranslationPro.Blazor.Pages
{
    public partial class ApplicationDetails : ApplicationDetailsBase
    {
        private Modal deleteApplication;
        public bool Disabled { get; set; }

        string selectedTab = "phrases";

        private Task OnSelectedTabChanged(string name)
        {
            selectedTab = name;

            return Task.CompletedTask;
        }

        [Inject]
        public IApplicationLanguagesController ApplicationLanguagesController { get; set; }
        

        protected override async Task OnParametersSetAsync()
        {
            await LoadData();
        }

        
        private Task ShowModal()
        {
            return deleteApplication.Show();
        }
        private Task HideModal()
        {
            return deleteApplication.Hide();
        }
        

        public async Task DeleteApplication()
        {
            await HideModal();
            var result = await ApplicationService.DeleteApplicationAsync(ApplicationId);
            if (result.Succeeded)
            {
                await EventAggregator.PublishAsync(new ApplicationDeletedEvent());
                NavigationManager.NavigateTo("/applications");
            }
        }


    }
}
