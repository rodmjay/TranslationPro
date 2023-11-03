using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Components;
using TranslationPro.Shared.Interfaces;
using TranslationPro.Shared.Models;

namespace TranslationPro.App.Pages
{
    public partial class Index
    {
        [Inject]
        public ILanguagesController LanguagesController { get; set; }


        public List<LanguageDto> Languages { get; set; }

        protected override async Task OnInitializedAsync()
        {
            Languages = await LanguagesController.GetLanguagesAsync();
        }
    }
}
