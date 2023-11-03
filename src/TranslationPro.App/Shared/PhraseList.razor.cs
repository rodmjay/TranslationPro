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

        private PagedList<PhraseDto> Phrases { get; set; }

        [Inject]
        public NavigationManager NavManager { get; set; }
        

        protected override async Task OnParametersSetAsync()
        {

            Phrases = await PhrasesController.GetPhrasesAsync(ApplicationId, new PagingQuery()
            {
                Size = 100
            }, new PhraseFilters());
        }
    }
}
