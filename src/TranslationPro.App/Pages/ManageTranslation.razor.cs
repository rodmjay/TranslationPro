using System.Collections.Generic;
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

        [Parameter]
        public string LanguageId { get; set; }
        
        public TranslationSaveOptions Input { get; set; } = new();

        [Inject]
        public IApplicationTranslationsController ApplicationTranslationController { get; set; }

        private ApplicationTranslationOutput ApplicationTranslation { get; set; }

        [Inject]
        private TranslationsProxy TranslationService { get; set; }

        private List<MachineTranslationOutput> MachineTranslations { get; set; }

        protected override async Task LoadData()
        {
            await base.LoadData();
            ApplicationTranslation = ApplicationPhrase.Translations.FirstOrDefault(x => x.LanguageId == LanguageId);

            var phrases  = await TranslationService.Translate(new PhraseBulkCreateOptions()
            {
                LanguageIds = new[] {LanguageId},
                Texts = new[] {ApplicationPhrase.Text},
            });

            MachineTranslations = phrases.SelectMany(x => x.MachineTranslations).ToList();
        }
        

        private async Task Callback(string text)
        {
            var result = await ApplicationTranslationController.ReplaceTranslation(ApplicationId, PhraseId,
                new TranslationReplacementOptions()
                {
                    Text = text,
                    LanguageId = LanguageId
                });

            await LoadData();
        }
    }
}
