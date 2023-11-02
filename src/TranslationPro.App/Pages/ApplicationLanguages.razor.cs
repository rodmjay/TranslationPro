using Microsoft.AspNetCore.Components;
using TranslationPro.App.Pages.Bases;
using TranslationPro.Shared.Interfaces;
using TranslationPro.Shared.Models;

namespace TranslationPro.App.Pages
{
    public partial class ApplicationLanguages : ApplicationDetailsBase
    {
        [Inject]
        public ILanguagesController LanguagesController { get; set; }
         
        public List<LanguageDto> Languages { get; set; }

        protected override async Task OnInitializedAsync()
        {
            await base.OnInitializedAsync();

            Languages = await LanguagesController.GetLanguagesAsync();
        }
    }
}
