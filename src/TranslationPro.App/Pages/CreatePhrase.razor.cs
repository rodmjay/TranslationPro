using System.Threading.Tasks;
using Microsoft.AspNetCore.Components;
using TranslationPro.App.Pages.Bases;
using TranslationPro.Shared.Interfaces;
using TranslationPro.Shared.Models;

namespace TranslationPro.App.Pages
{
    public partial class CreatePhrase : ApplicationDetailsBase
    {
        [Inject]
        public NavigationManager NavigationManager { get; set; }

        public PhraseInput Input { get; set; } = new PhraseInput();

        [Inject]
        public IPhrasesController PhraseProxy { get; set; }

        private async Task HandleSubmit()
        {
            var result = await PhraseProxy.CreatePhraseAsync(ApplicationId, Input);

            if (result.Succeeded)
            {
                NavigationManager.NavigateTo($"/applications/{ApplicationId}/phrases/{result.Id}");
            }
        }
    }
}
