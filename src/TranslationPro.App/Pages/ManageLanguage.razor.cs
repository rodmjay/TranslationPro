using System.Threading.Tasks;
using Microsoft.AspNetCore.Components;
using TranslationPro.App.Bases;
using TranslationPro.Shared.Common;
using TranslationPro.Shared.Interfaces;
using TranslationPro.Shared.Models;
using TranslationPro.Shared.Proxies;

namespace TranslationPro.App.Pages
{

    public partial  class ManageLanguage : ApplicationDetailsBase
    {
        [Parameter]
        public string LanguageId { get; set; }

        [Inject]
        public IApplicationLanguagesController ApplicationLanguagesProxy { get; set; }

        public PagedList<ApplicationTranslationOutputWithOriginalPhrase> Translations { get; set; }


        protected override async Task OnParametersSetAsync()
        {
            await base.OnParametersSetAsync();

            Translations =
                await ApplicationLanguagesProxy.GetTranslationsForLanguage(ApplicationId, LanguageId,
                    new PagingQuery());
        }
        
    }
}
