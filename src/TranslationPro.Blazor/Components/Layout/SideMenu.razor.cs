using EventAggregator.Blazor;
using Microsoft.AspNetCore.Components;
using TranslationPro.Blazor.Events;
using TranslationPro.Shared.Interfaces;
using TranslationPro.Shared.Models;

namespace TranslationPro.Blazor.Components.Layout
{
    public partial class SideMenu : IHandle<ApplicationCreatedEvent>, IHandle<ApplicationDeletedEvent>
    {
        [CascadingParameter]
        public IEventAggregator EventAggregator { get; set; }

        [Inject]
        protected IApplicationsController ApplicationService { get; set; }

        protected List<ApplicationOutput> Applications { get; set; }

        [Inject]
        protected NavigationManager NavigationManager { get; set; }
        
        protected override async Task OnInitializedAsync()
        {
            await base.OnInitializedAsync();
            
            EventAggregator.Subscribe(this);

            await LoadData();
        }

        protected async Task LoadData()
        {
            Applications = await ApplicationService.GetApplicationsAsync();
        }

        private void Navigate(Guid applicationId)
        {
            NavigationManager.NavigateTo($"/applications/{applicationId}", forceLoad: true);
        }

        public async Task HandleAsync(ApplicationCreatedEvent message)
        {
            await LoadData();
        }

        public async Task HandleAsync(ApplicationDeletedEvent message)
        {
            await LoadData();
        }
    }
}
