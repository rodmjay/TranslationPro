using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.WebUtilities;
using TranslationPro.Blazor.Components.Application.Bases;
using TranslationPro.Blazor.Events;
using TranslationPro.Shared.Interfaces;

namespace TranslationPro.Blazor.Pages
{
    public partial class SubscriptionComplete : AuthenticatedBase
    {

        public bool IsCompleted { get; set; } = false;

        [Inject]
        protected IStripeController StripeService { get; set; }

        protected override async Task OnInitializedAsync()
        {
            var uri = NavManager.ToAbsoluteUri(NavManager.Uri);

            if (QueryHelpers.ParseQuery(uri.Query).TryGetValue("session_id", out var sessionId))
            {
                var result = await StripeService.CompleteSession(sessionId);
                if (result.Succeeded)
                {
                    await EventAggregator.PublishAsync(new SubscriptionCreatedEvent());
                    IsCompleted = true;
                }
            }
        }

        private void Callback()
        {
            NavManager.NavigateTo("/create-application");
        }
    }
}
