using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components;
using TranslationPro.Blazor.Components.Application.Bases;
using TranslationPro.Blazor.Services;
using TranslationPro.Shared.Interfaces;
using TranslationPro.Shared.Models;

namespace TranslationPro.Blazor.Pages
{
    public partial class PhraseCreate : ApplicationDetailsBase
    {

        [Inject]
        protected IApplicationPhrasesController PhraseService { get; set; }

        private List<FormResponse> Phrases { get; } = new();

        protected void AddItem()
        {
            Phrases.Add(new FormResponse()
            {
                Value = null
            });
        }

        private bool IsSubmitting = false;

        private void RemoveItem(int index)
        {
            Phrases.RemoveAt(index);
        }

        protected override void OnAfterRender(bool firstRender)
        {
            base.OnAfterRender(firstRender);

            if (firstRender)
            {
                AddItem();
            }
        }

        protected override void BuildBreadcrumbs()
        {
            base.BuildBreadcrumbs();

            NavigationItems.Add(new NavigationItem()
            {
                Title = "Create Phrase"
            });
        }

        private async Task HandleSubmit(MouseEventArgs evnt)
        {
            IsSubmitting = true;
            var cleanItems = Phrases.Select(x => x.Value).ToList();

            var result = await PhraseService.CreatePhrasesAsync(ApplicationId, new ApplicationPhrasesCreateOptions
            {
                Texts = cleanItems
            });

            IsSubmitting = false;

            if (result != null)
            {
                NavigationManager.NavigateTo($"/applications/{ApplicationId}");
            }
        }
    }
}
