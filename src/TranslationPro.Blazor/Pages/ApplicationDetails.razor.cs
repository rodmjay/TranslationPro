using Microsoft.AspNetCore.Components;
using TranslationPro.Blazor.Components.Application.Bases;
using TranslationPro.Blazor.Components.Application.Components;
using TranslationPro.Shared.Interfaces;

namespace TranslationPro.Blazor.Pages
{
    public partial class ApplicationDetails : ApplicationDetailsBase
    {
        private Modal deleteApplication;

        public bool Disabled { get; set; }

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
    }
}
