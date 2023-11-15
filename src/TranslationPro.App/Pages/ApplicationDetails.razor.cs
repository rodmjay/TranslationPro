using Microsoft.AspNetCore.Components;
using System.Threading.Tasks;
using TranslationPro.App.Bases;
using TranslationPro.App.Shared;
using TranslationPro.Shared.Common;
using TranslationPro.Shared.Filters;
using TranslationPro.Shared.Interfaces;
using TranslationPro.Shared.Models;

namespace TranslationPro.App.Pages
{
    public partial class ApplicationDetails : ApplicationDetailsBase
    {

        [Inject]
        public IPhrasesController PhrasesController { get; set; }

        public PagedList<ApplicationPhraseOutput> Phrases { get; set; }


        private readonly PagingQuery _paging = new();

        protected override async Task LoadData()
        {
            await base.LoadData();

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
