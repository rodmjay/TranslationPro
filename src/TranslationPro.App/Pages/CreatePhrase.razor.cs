using System.Threading.Tasks;
using Microsoft.AspNetCore.Components;
using TranslationPro.App.Bases;
using TranslationPro.Shared.Interfaces;
using TranslationPro.Shared.Models;

namespace TranslationPro.App.Pages
{
    public partial class CreatePhrase : ApplicationDetailsBase
    {
        [Inject]
        public NavigationManager NavigationManager { get; set; }

        public PhraseOptions Input { get; set; } = new PhraseOptions();

        [Inject]
        public IPhrasesController PhraseProxy { get; set; }

        private async Task HandleSubmit()
        {
            var result = await PhraseProxy.CreatePhraseAsync(ApplicationId, Input);

            if (result.Succeeded)
            {
                NavigationManager.NavigateTo($"/applications/{ApplicationId}/phrases/{result.PhraseId}");
            }
        }
    }
}
