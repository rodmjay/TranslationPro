using Microsoft.AspNetCore.Components;
using TranslationPro.App.Extensions;
using TranslationPro.App.Pages.Bases;
using TranslationPro.Shared.Common;
using TranslationPro.Shared.Filters;
using TranslationPro.Shared.Interfaces;
using TranslationPro.Shared.Models;

namespace TranslationPro.App.Pages
{
    public partial class Phrases : ApplicationDetailsBase
    {
        private PagingQuery PagingQuery = new PagingQuery();

        [Inject]
        public IPhrasesController PhrasesController { get; set; }

        private PagedList<PhraseDto> PhraseList { get; set; }

        [Inject]
        public NavigationManager NavManager { get; set; }

        private int CurrentPage = 1;
        public string? Sort { get; set; }

        protected async override Task OnInitializedAsync()
        {
            await base.OnInitializedAsync();

            NavManager.TryGetQueryString<int>("page", out CurrentPage);

            PhraseList = await PhrasesController.GetPhrasesAsync(ApplicationId, new PagingQuery()
            {
                Page = CurrentPage
            }, new PhraseFilters());
        }

        protected override async Task OnParametersSetAsync()
        {
            await base.OnInitializedAsync();
        }
    }
}
