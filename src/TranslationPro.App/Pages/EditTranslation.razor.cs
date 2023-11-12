using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Components;
using TranslationPro.App.Bases;
using TranslationPro.Shared.Interfaces;
using TranslationPro.Shared.Models;

namespace TranslationPro.App.Pages
{
    public partial class EditTranslation : PhraseDetailsBase
    {
        [Inject]
        public NavigationManager NavigationManager { get; set; }
        [Parameter]
        public string LanguageId { get; set; }

        public MachineTranslationOutput MachineTranslation { get; set; }

        public TranslationOptions Input { get; set; } = new();

        [Inject]
        public ITranslationsController TranslationController { get; set; }

        protected override async Task LoadData()
        {
            await base.LoadData();

            //MachineTranslation = Phrase.T.FirstOrDefault(x => x.LanguageId == LanguageId);

            //if (MachineTranslation != null) Input.Text = MachineTranslation.Text;
            //Input.LanguageId = LanguageId;
        }


        private async Task HandleSubmit()
        {
            var result = await TranslationController.SaveTranslation(ApplicationId, PhraseId, Input);

            if (result.Succeeded)
            {
                NavigationManager.NavigateTo($"/applications/{ApplicationId}/phrases/{PhraseId}");
            }
        }
    }
}
