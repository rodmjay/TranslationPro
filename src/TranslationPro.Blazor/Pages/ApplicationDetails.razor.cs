using EventAggregator.Blazor;
using Microsoft.AspNetCore.Components;
using TranslationPro.Blazor.Components.Application.Bases;
using TranslationPro.Blazor.Events;
using TranslationPro.Shared.Common;
using TranslationPro.Shared.Interfaces;

namespace TranslationPro.Blazor.Pages
{
    public partial class ApplicationDetails : ApplicationDetailsBase, IHandle<PhraseCreatedEvent>, IHandle<PhrasesReprocessedEvent>
    {
        [Inject]
        public IApplicationPhrasesController ApplicationPhraseService { get; set; }

        private Modal deleteApplication;
        public bool Disabled { get; set; }

        string selectedTab = "phrases";

        private Task OnSelectedTabChanged(string name)
        {
            selectedTab = name;
            return Task.CompletedTask;
        }

        [Inject]
        public IApplicationLanguagesController ApplicationLanguagesController { get; set; }

        private Task ShowModal()
        {
            return deleteApplication.Show();
        }
        private Task HideModal()
        {
            return deleteApplication.Hide();
        }

        protected override async Task LoadData()
        {
            await base.LoadData();

            if (this.Application.PendingTranslations > 0)
            {
                var result = await ApplicationPhraseService.ProcessPending(ApplicationId);
                if (result.Succeeded)
                {
                    await EventAggregator.PublishAsync(new PhrasesReprocessedEvent());
                }
            }
        }

        public async Task DeleteApplication()
        {
            await HideModal();
            var result = await ApplicationService.DeleteApplicationAsync(ApplicationId);
            if (result.Succeeded)
            {
                await EventAggregator.PublishAsync(new ApplicationDeletedEvent());
                NavigationManager.NavigateTo("/applications");
            }
        }


        public async Task HandleAsync(PhraseCreatedEvent message)
        {
            await LoadData();
        }

        public async Task HandleAsync(PhrasesReprocessedEvent message)
        {
            await LoadData();
        }
    }
}
