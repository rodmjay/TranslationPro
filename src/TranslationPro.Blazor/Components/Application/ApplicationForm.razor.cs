using EventAggregator.Blazor;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components;
using TranslationPro.Blazor.Events;
using TranslationPro.Shared.Interfaces;
using TranslationPro.Shared.Models;

namespace TranslationPro.Blazor.Components.Application
{
    public partial class ApplicationForm
    {
        Validations? validationsBasicExampleRef;

        [Inject]
        public NavigationManager NavManager { get; set; }

        [Inject]
        public IEventAggregator EventAggregator { get; set; }

        [Inject]
        public ILanguagesController LanguagesController { get; set; }

        [CascadingParameter]
        public IApplicationsController ApplicationService { get; set; }

        public ApplicationCreateOptions Input { get; set; } = new()
        {
            Languages = new List<string>()
        };

        private List<LanguageOutput> Languages { get; set; }

        protected override async Task OnInitializedAsync()
        {

            Languages = await LanguagesController.GetLanguagesAsync();

        }

        private async Task HandleSubmit(MouseEventArgs evnt)
        {
            if (await validationsBasicExampleRef!.ValidateAll())
            {
                await validationsBasicExampleRef.ClearAll();

                var result = await ApplicationService.CreateApplicationAsync(Input);

                if (result.Succeeded)
                {
                    await EventAggregator.PublishAsync(new ApplicationCreatedEvent());

                    NavManager.NavigateTo($"/applications/{result.Id}");
                }
            }
        }

        private void LanguagesChanged(IReadOnlyList<string> languages)
        {
            Input.Languages = languages.ToArray();
        }
    }
}
