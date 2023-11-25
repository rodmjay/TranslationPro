using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices.ComTypes;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Components;
using TranslationPro.App.Bases;
using TranslationPro.Shared.Interfaces;
using TranslationPro.Shared.Models;

namespace TranslationPro.App.Pages
{
    public partial class CreatePhrase : ApplicationDetailsBase
    {
        private readonly List<string> Phrases = new() { "" };
        
        private bool IsLoading = false;

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
        

        private void AddItem()
        {
            Phrases.Add("");
        }

        private void RemoveItem(int index)
        {
            Phrases.RemoveAt(index);
        }

        private void SubmitItems()
        {
            IsLoading = true;
            var cleanItems = Phrases.Where(x=>!string.IsNullOrWhiteSpace(x)).Select(x=>x.Trim()).Distinct().ToList();

            var phraseOptions = new ApplicationPhrasesCreateOptions
            {
                Texts = cleanItems
            };
            var result = ApplicationPhraseProxy.CreatePhrasesAsync(ApplicationId, phraseOptions);
            if (result != null)
            {
                IsLoading = false;
                NavigationManager.NavigateTo($"/applications/{ApplicationId}", forceLoad:true);
            }
        }
    }
}
