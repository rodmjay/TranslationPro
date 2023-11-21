using System.Threading.Tasks;
using Microsoft.AspNetCore.Components;
using TranslationPro.App.Bases;
using TranslationPro.Shared.Interfaces;
using TranslationPro.Shared.Models;

namespace TranslationPro.App.Pages
{
    public partial class CreatePhrase : ApplicationDetailsBase
    {
        
        public PhraseOptions Input { get; set; } = new PhraseOptions();

        [Inject]
        public IApplicationPhrasesController ApplicationPhraseProxy { get; set; }

        protected override async Task LoadData()
        {
            await base.LoadData();
            NavigationItems.Add(new NavigationItem()
            {
                Title = "Create Phrase",
                Url = $"/applications/{ApplicationId}/phrases/create"
            });
        }

        private async Task HandleSubmit()
        {
            var result = await ApplicationPhraseProxy.CreatePhrasesAsync(ApplicationId, Input);

            if (result != null)
            {
                NavigationManager.NavigateTo($"/applications/{ApplicationId}/phrases/{result[0].Id}");
            }
        }
    }
}
