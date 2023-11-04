using System.Threading.Tasks;
using Microsoft.AspNetCore.Components;
using TranslationPro.App.Pages.Bases;
using TranslationPro.Shared.Interfaces;
using TranslationPro.Shared.Models;

namespace TranslationPro.App.Pages
{

    public partial class PhraseDetails : PhraseDetailsBase
    {
        [Inject]
        public IPhrasesController PhrasesController { get; set; }

        [Parameter]
        public int PhraseId { get; set; }
        public PhraseDto Phrase { get; set; }

        protected override async Task OnInitializedAsync()
        {
            await LoadData();
        }

        protected override async Task LoadData()
        {
            await base.LoadData();
            Phrase = await PhrasesController.GetPhraseAsync(ApplicationId, PhraseId);
        }
    }
}
