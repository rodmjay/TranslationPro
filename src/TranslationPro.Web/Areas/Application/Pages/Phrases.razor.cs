using Microsoft.AspNetCore.Components;
using TranslationPro.Base.Common.Models;
using TranslationPro.Base.Languages.Interfaces;
using TranslationPro.Base.Languages.Models;
using TranslationPro.Base.Phrases.Interfaces;
using TranslationPro.Base.Phrases.Models;

namespace TranslationPro.Web.Areas.Application.Pages
{
    public partial class Phrases : AuthenticatedPage
    {
        [Inject]
        private IPhraseService? PhraseService { get; set; }
        [Parameter]
        public Guid ApplicationId { get; set; }
        private PagedList<PhraseDto>? _phrases;

        protected override async Task OnInitializedAsync()
        {
            _phrases = await PhraseService?.GetPhrasesForApplicationAsync<PhraseDto>(ApplicationId, new PagingQuery(), new PhraseFilters())!;
        }
    }
}
