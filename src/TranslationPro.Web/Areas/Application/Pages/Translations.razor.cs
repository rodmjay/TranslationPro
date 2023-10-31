using Microsoft.AspNetCore.Components;
using TranslationPro.Base.Common.Models;
using TranslationPro.Base.Languages.Interfaces;
using TranslationPro.Base.Languages.Models;
using TranslationPro.Base.Phrases.Interfaces;
using TranslationPro.Base.Phrases.Models;

namespace TranslationPro.Web.Areas.Application.Pages
{
    public partial class Translations : AuthenticatedPage
    {
        [Inject]
        private IPhraseService? PhraseService { get; set; }

        [Parameter]
        public int PhraseId { get; set; }

        [Parameter]
        public Guid ApplicationId { get; set; }

        private PhraseDto _phrase = new PhraseDto();

        protected override async Task OnInitializedAsync()
        {
            _phrase = await PhraseService?.GetPhraseAsync<PhraseDto>(ApplicationId, PhraseId)!;
        }
    }
}
