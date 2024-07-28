using EventAggregator.Blazor;
using Microsoft.AspNetCore.Components;
using TranslationPro.Blazor.Events;
using TranslationPro.Shared.Models;

namespace TranslationPro.Blazor.Components.Application.Bases
{
    public class ApplicationDetailsBase : AuthenticatedBase
    {
        [Parameter]
        public Guid ApplicationId { get; set; }

        [CascadingParameter]
        protected ApplicationOutput Application { get; set; }

        protected override void OnInitialized()
        {
            Console.WriteLine("ApplicationDetailsBase.OnInitialized");

            EventAggregator.Subscribe(this);
        }
        
        protected override void BuildBreadcrumbs()
        {
            if (Application != null)
            {
                base.NavigationItems.Clear();
                this.NavigationItems.Add(new NavigationItem()
                {
                    Title = "Applications",
                    Url = "/applications"
                });
                NavigationItems.Add(new NavigationItem()
                {
                    Title = Application.Name,
                    Url = $"/applications/{Application.Id}"
                });
            }

        }

    }
}
