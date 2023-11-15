using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Components;
using TranslationPro.App.Bases;
using TranslationPro.Shared.Common;
using TranslationPro.Shared.Interfaces;
using TranslationPro.Shared.Models;

namespace TranslationPro.App.Pages
{

    public partial  class ManageLanguage : ApplicationDetailsBase
    {
        [Parameter]
        public string LanguageId { get; set; }

        [Inject]
        public IApplicationLanguagesController ApplicationLanguagesProxy { get; set; }

        public PagedList<ApplicationTranslationOutputWithOriginalPhrase> Translations { get; set; }

        private readonly PagingQuery _paging = new();
        protected override async Task OnInitializedAsync()
        {
            await LoadData();
        }

        protected override async Task LoadData()
        {
            await base.LoadData();
            Translations =
                await ApplicationLanguagesProxy.GetTranslationsForLanguage(ApplicationId, LanguageId,
                    _paging);

            StateHasChanged();
        }

        private async Task Callback(int page)
        {
            _paging.Page = page;
            await LoadData();
        }

    }
}
