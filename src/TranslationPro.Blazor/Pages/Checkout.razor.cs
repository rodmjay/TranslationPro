using Microsoft.AspNetCore.Components;
using Microsoft.JSInterop;
using TranslationPro.Shared.Interfaces;

namespace TranslationPro.Blazor.Pages
{
    public partial class Checkout
    {

        [Inject]
        public NavigationManager Navigation { get; set; }

        [Inject]
        public IJSRuntime JavaScriptRuntime { get; set; }

        [Inject]
        public IConfiguration Configuration { get; set; }

        [Inject]
        protected ISubscriptionController SubscriptionService { get; set; }

        protected override async Task OnInitializedAsync()
        {
            var subscription = await SubscriptionService.CreateCheckoutSession();

            var stripePublicKey = Configuration["Stripe:PublicKey"];

            await JavaScriptRuntime.InvokeVoidAsync("translationProStripe.initialize", stripePublicKey, subscription);
        }

    }
}
