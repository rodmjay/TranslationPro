using Microsoft.AspNetCore.Components;
using TranslationPro.Blazor.Components.Application.Bases;
using TranslationPro.Blazor.Components.Application.Components;
using TranslationPro.Shared.Interfaces;

namespace TranslationPro.Blazor.Pages
{
    public partial class ApplicationDetails : ApplicationDetailsBase
    {
        [Inject]
        public IApplicationLanguagesController ApplicationLanguagesController { get; set; }

        private PhraseList list;
        
        public async Task Reload()
        {
            await LoadData();
            await list.Reload();
            StateHasChanged();
        }


        public async Task HandleLanguageChange(IReadOnlyList<string> languages)
        {
            await ApplicationLanguagesController.SyncLanguages(ApplicationId, languages.ToArray());
            await Reload();
        }
    }
}
