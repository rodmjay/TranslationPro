using Microsoft.AspNetCore.Components;
using TranslationPro.Blazor.Components.Application.Bases;
using TranslationPro.Blazor.Components.Application.Components;
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

        private PhraseList list;
        
        public async Task Reload()
        {
            await LoadData();
            await list.Reload();
            StateHasChanged();
        }

        private Task ShowModal()
        {
            return deleteApplication.Show();
        }
        private Task HideModal()
        {
            return deleteApplication.Hide();
        }

        public async Task HandleLanguageChange(IReadOnlyList<string> languages)
        {
            Disabled = true;
            await ApplicationLanguagesController.SyncLanguages(ApplicationId, languages.ToArray());
            Disabled = false;
            await Reload();
        }

        public async Task DeleteApplication()
        {
            await HideModal();
            await ApplicationService.DeleteApplicationAsync(ApplicationId);
            NavigationManager.NavigateTo("/applications");
        }


        private async Task LanguageEnabled(string languageId)
        {
            Disabled = true;
            await ApplicationLanguagesController.AddLanguageToApplicationAsync(ApplicationId,
                new ApplicationLanguageOptions()
                {
                    LanguageId = languageId
                });
            Disabled = false;
            await Reload();
        }

        private async Task LanguageDisabled(string languageId)
        {
            Disabled = true;
            await ApplicationLanguagesController.RemoveLanguageFromApplicationAsync(ApplicationId,languageId);
            Disabled = false;
            await Reload();
        }
    }
}
