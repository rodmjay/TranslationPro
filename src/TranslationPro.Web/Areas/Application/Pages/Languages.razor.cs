using Microsoft.AspNetCore.Components;
using TranslationPro.Base.Languages.Interfaces;
using TranslationPro.Base.Languages.Models;

namespace TranslationPro.Web.Areas.Application.Pages
{
    public partial class Languages
    {
        [Inject]
        private ILanguageService? LanguageService { get; set; }
        
        private List<LanguageDto>? _languages;

        protected override async Task OnInitializedAsync()
        {
            _languages = await LanguageService?.GetLanguagesAsync<LanguageDto>()!;
        }
    }
}
