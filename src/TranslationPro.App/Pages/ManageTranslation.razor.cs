using System;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Components;
using TranslationPro.App.Bases;
using TranslationPro.Shared.Interfaces;
using TranslationPro.Shared.Models;
using TranslationPro.Shared.Proxies;

namespace TranslationPro.App.Pages
{
    public partial class ManageTranslation : PhraseDetailsBase
    {
        [Inject]
        public NavigationManager NavigationManager { get; set; }

        [Parameter]
        public string LanguageId { get; set; }
        
        public TranslationOptions Input { get; set; } = new();

        [Inject]
        public ITranslationsController TranslationController { get; set; }

        private ApplicationTranslationOutput ApplicationTranslation { get; set; }

        protected override async Task LoadData()
        {
            await base.LoadData();
            ApplicationTranslation = ApplicationPhrase.Translations.FirstOrDefault(x => x.LanguageId == LanguageId);
        }
        

        private async Task Callback(string text)
        {
            var result = await TranslationController.ReplaceTranslation(ApplicationId, PhraseId,
                new TranslationReplacementOptions()
                {
                    Text = text,
                    LanguageId = LanguageId
                });

            await LoadData();
        }
    }
}
