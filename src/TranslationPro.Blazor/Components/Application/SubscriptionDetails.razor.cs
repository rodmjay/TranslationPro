using Microsoft.AspNetCore.Components;
using TranslationPro.Shared.Interfaces;
using TranslationPro.Shared.Models;

namespace TranslationPro.Blazor.Components.Application
{
    public partial class SubscriptionDetails
    {

        [Inject]
        protected NavigationManager NavManager { get; set; }

        [CascadingParameter]
        protected UserOutput CurrentUser { get; set; }

        private Modal deleteSubscription;

        [CascadingParameter]
        private SubscriptionOutput Subscription { get; set; }

        private Task ShowModal()
        {
            return deleteSubscription.Show();
        }
        private Task HideModal()
        {
            return deleteSubscription.Hide();
        }
        
        public async Task DeleteSubscription()
        {
            NavManager.NavigateTo($"/");
        }
    }
}
