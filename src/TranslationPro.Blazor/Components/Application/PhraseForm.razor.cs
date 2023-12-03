using EventAggregator.Blazor;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Web;
using TranslationPro.Blazor.Events;
using TranslationPro.Blazor.Services;
using TranslationPro.Shared.Interfaces;
using TranslationPro.Shared.Models;

namespace TranslationPro.Blazor.Components.Application
{
    public partial class PhraseForm
    {
        [CascadingParameter]
        public IEventAggregator EventAggregator { get; set; }

        [CascadingParameter]
        public ApplicationOutput Application { get; set; }

        [Inject]
        public NavigationManager NavigationManager { get; set; }

        [Inject]
        protected IApplicationPhrasesController PhraseService { get; set; }

        private List<FormResponse> Phrases { get; } = new()
        {
            new FormResponse()
            {
                Value = ""
            }
        };

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
        

        private async Task HandleSubmit(MouseEventArgs evnt)
        {
            IsSubmitting = true;
            var cleanItems = Phrases.Select(x => x.Value).ToList();

            var result = await PhraseService.CreatePhrasesAsync(Application.Id, new ApplicationPhrasesCreateOptions
            {
                Texts = cleanItems
            });

            IsSubmitting = false;

            if (result != null)
            {
                await EventAggregator.PublishAsync(new PhraseCreatedEvent());

                NavigationManager.NavigateTo($"/applications/{Application.Id}");
            }
        }
    }
}
