using Microsoft.AspNetCore.Components;
using TranslationPro.Shared.Interfaces;
using TranslationPro.Shared.Models;

namespace TranslationPro.Blazor.Components.Application
{
    public partial class SubscriptionDetails
    {

        [Inject]
        protected IStripeController StripeService { get; set; }

        [Inject]
        protected NavigationManager NavManager { get; set; }

        [CascadingParameter]
        protected UserOutput CurrentUser { get; set; }

        private Modal deleteSubscription;

        private Stripe.Subscription Subscription { get; set; }

        private Task ShowModal()
        {
            return deleteSubscription.Show();
        }
        private Task HideModal()
        {
            return deleteSubscription.Hide();
        }

        protected override async Task OnInitializedAsync()
        {
            Subscription = await StripeService.GetSubscription();
        }

        public async Task DeleteSubscription()
        {
            NavManager.NavigateTo($"/");
        }
    }
}
