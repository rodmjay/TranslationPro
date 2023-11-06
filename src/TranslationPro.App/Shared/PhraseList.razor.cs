using System;
using Microsoft.AspNetCore.Components;
using System.Threading.Tasks;
using TranslationPro.App.Pages.Bases;
using TranslationPro.Shared.Common;
using TranslationPro.Shared.Filters;
using TranslationPro.Shared.Interfaces;
using TranslationPro.Shared.Models;

namespace TranslationPro.App.Shared
{
    public partial class PhraseList
    {
        [Parameter]
        public Guid ApplicationId { get; set; }

        [Inject]
        public IPhrasesController PhrasesController { get; set; }

        public PagedList<PhraseOutput> Phrases { get; set; }

        [Inject]
        public NavigationManager NavManager { get; set; }
        
        private PagingQuery _paging = new();

        protected override async Task OnParametersSetAsync()
        {
            await LoadData();
        }

        public async Task LoadData()
        {
            Phrases = await PhrasesController.GetPhrasesAsync(ApplicationId, _paging, new PhraseFilters());

            StateHasChanged();
        }

        public async Task HandlePageNavigation(int page)
        {
            _paging.Page = page;
            await LoadData();
        }
        
    }
}
