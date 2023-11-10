using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Components;
using Microsoft.Extensions.Options;
using Newtonsoft.Json.Linq;
using TranslationPro.Shared.Interfaces;
using TranslationPro.Shared.Models;

namespace TranslationPro.App.Pages
{
    
    public partial class CreateApplication
    {
        [Inject]
        public NavigationManager NavigationManager { get; set; }

        [Inject]
        public IApplicationsController ApplicationsController { get; set; }

        [Inject]
        public ILanguagesController LanguagesController { get; set; }

        public ApplicationCreateOptions Input { get; set; } = new ApplicationCreateOptions();
         
        public ICollection<LanguageOutput> Languages { get; set; }
        private ICollection<string> selection = new();
        protected override async Task OnInitializedAsync()
        {
            Languages = await LanguagesController.GetLanguagesAsync();

        }


        private async void OnChangeSelection(ChangeEventArgs e)
        {
            selection.Clear();
            var items = (e.Value as string[]);
            if (items != null)
                foreach (var item in items)
                {
                    selection.Add(item);
                }
        }

        private async Task HandleSubmit()
        {
            // Input.Languages = selection.ToArray();

            var result = await ApplicationsController.CreateApplicationAsync(Input);

            if (result.Succeeded)
            {
                NavigationManager.NavigateTo($"/applications/{result.Id}");
            }
        }
    }
}
