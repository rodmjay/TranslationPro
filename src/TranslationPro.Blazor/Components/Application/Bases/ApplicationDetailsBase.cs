using EventAggregator.Blazor;
using Microsoft.AspNetCore.Components;
using TranslationPro.Blazor.Events;
using TranslationPro.Shared.Models;

namespace TranslationPro.Blazor.Components.Application.Bases
{
    public class ApplicationDetailsBase : AuthenticatedBase, IHandle<ApplicationUpdatedEvent>, IHandle<LanguagesChangedEvent>
    {
        [Parameter]
        public Guid ApplicationId { get; set; }

        protected ApplicationOutput Application { get; set; }

        protected override void OnInitialized()
        {
            EventAggregator.Subscribe(this);
        }
        
        protected override async Task LoadData()
        {
            await base.LoadData();
            Application = await ApplicationService.GetApplicationAsync(ApplicationId);
        }

        protected override void BuildBreadcrumbs()
        {
            base.BuildBreadcrumbs();

            if (Application != null)
            {
                NavigationItems.Add(new NavigationItem()
                {
                    Title = Application.Name,
                    Url = $"/applications/{Application.Id}"
                });
            }

        }

        public async Task HandleAsync(ApplicationUpdatedEvent message)
        {
            await LoadData();
        }

        public async Task HandleAsync(LanguagesChangedEvent message)
        {
            await LoadData();
        }
    }
}
