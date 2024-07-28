using EventAggregator.Blazor;
using Microsoft.AspNetCore.Components;
using TranslationPro.Blazor.Components.Application.Bases;
using TranslationPro.Blazor.Events;
using TranslationPro.Shared.Interfaces;
using TranslationPro.Shared.Models;

namespace TranslationPro.Blazor.Layouts
{
    public partial class ApplicationLayout : IHandle<ApplicationUpdatedEvent>, IHandle<LanguagesChangedEvent>
    {
        [CascadingParameter]
        private RouteData RouteData { get; set; }
        
        private Guid ApplicationId { get; set; }

        [Inject]
        public IApplicationsController ApplicationService { get; set; }
        protected ApplicationOutput Application { get; set; }

        [CascadingParameter]
        protected IEventAggregator EventAggregator { get; set; }
        
        [CascadingParameter]
        protected UserOutput CurrentUser { get; set; }
        
        [CascadingParameter]
        protected List<NavigationItem> NavigationItems { get; set; }
        
        protected override async Task OnInitializedAsync()
        {
            Console.WriteLine("ApplicationLayout.OnInitializedAsync");
            
            EventAggregator.Subscribe(this);

            await LoadData();
        }

        public async Task LoadData()
        {
            Console.WriteLine("ApplicationLayout.LoadData");

            this.ApplicationId = (Guid)RouteData.RouteValues["ApplicationId"];

            Application = await ApplicationService.GetApplicationAsync(ApplicationId);
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