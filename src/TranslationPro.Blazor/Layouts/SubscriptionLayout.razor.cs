using EventAggregator.Blazor;
using Microsoft.AspNetCore.Components;
using TranslationPro.Blazor.Components.Application.Bases;
using TranslationPro.Shared.Interfaces;
using TranslationPro.Shared.Models;

namespace TranslationPro.Blazor.Layouts
{
    public partial class SubscriptionLayout
    {
        [Inject]
        protected IStripeController StripeService { get; set; }

        [CascadingParameter]
        protected IEventAggregator EventAggregator { get; set; }
        
        [CascadingParameter]
        protected UserOutput CurrentUser { get; set; }

        protected SubscriptionOutput Subscription { get; set; }

        [CascadingParameter]
        protected List<NavigationItem> NavigationItems { get; set; }

        protected override async Task OnInitializedAsync()
        {
            await base.OnInitializedAsync();

            EventAggregator.Subscribe(this);

            await LoadData();
        }

        public async Task LoadData()
        {
            Subscription = await StripeService.GetSubscription();
        }
    }
}