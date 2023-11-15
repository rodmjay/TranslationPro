using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Components;
using TranslationPro.App.Bases;
using TranslationPro.Shared.Interfaces;
using TranslationPro.Shared.Models;

namespace TranslationPro.App.Pages
{
    public partial class CreateApplication : AuthenticatedBase
    {
        [Inject]
        public ILanguagesController LanguagesController { get; set; }

        public ApplicationCreateOptions Input { get; set; } = new();
         
        private List<LanguageOutput> Languages { get; set; }

        private readonly List<string> selection = new();

        protected override async Task LoadData()
        {
            await base.LoadData();

            Languages = await LanguagesController.GetLanguagesAsync();

            NavigationItems.Add(new NavigationItem()
            {
                Title = "Create Application"
            });
        }

        private void OnChangeSelection(ChangeEventArgs e)
        {
            selection.Clear();
            if (e.Value is not string[] items) return;
            foreach (var item in items)
            {
                selection.Add(item);
            }
        }

        private async Task HandleSubmit()
        {
            Input.Languages = selection.ToArray();

            var result = await ApplicationService.CreateApplicationAsync(Input);

            if (result.Succeeded)
            {
                NavigationManager.NavigateTo($"/applications/{result.Id}");
            }
        }
    }
}
