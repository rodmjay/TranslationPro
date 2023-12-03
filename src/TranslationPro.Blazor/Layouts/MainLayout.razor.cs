using Blazorise.Localization;
using EventAggregator.Blazor;
using Microsoft.AspNetCore.Components;
using TranslationPro.Blazor.Events;
using TranslationPro.Shared.Interfaces;
using TranslationPro.Shared.Models;

namespace TranslationPro.Blazor.Layouts
{
    public partial class MainLayout : IHandle<SubscriptionCreatedEvent>
    {
        [CascadingParameter]
        protected IEventAggregator EventAggregator { get; set; }

        [Inject]
        protected IUserController UserService { get; set; }
        
        protected UserOutput CurrentUser { get; set; }

        [Inject] protected ITextLocalizerService LocalizationService { get; set; }

        [CascadingParameter] protected Theme Theme { get; set; }
        

        protected override async Task OnInitializedAsync()
        {
            await SelectCulture("en-US");

            await base.OnInitializedAsync();

            EventAggregator.Subscribe(this);

            await LoadData();
        }

        public async Task LoadData()
        {

            CurrentUser = await UserService.GetUser();
        }

        private Task SelectCulture(string name)
        {
            LocalizationService!.ChangeLanguage(name);

            return Task.CompletedTask;
        }

        Task OnThemeEnabledChanged(bool value)
        {
            if (Theme is null)
                return Task.CompletedTask;

            Theme.Enabled = value;

            return InvokeAsync(Theme.ThemeHasChanged);
        }

        Task OnThemeGradientChanged(bool value)
        {
            if (Theme is null)
                return Task.CompletedTask;

            Theme.IsGradient = value;

            return InvokeAsync(Theme.ThemeHasChanged);
        }

        Task OnThemeRoundedChanged(bool value)
        {
            if (Theme is null)
                return Task.CompletedTask;

            Theme.IsRounded = value;

            return InvokeAsync(Theme.ThemeHasChanged);
        }

        Task OnThemeColorChanged(string value)
        {
            if (Theme is null)
                return Task.CompletedTask;

            Theme.ColorOptions ??= new();

            Theme.BackgroundOptions ??= new();

            Theme.TextColorOptions ??= new();

            Theme.ColorOptions.Primary = value;
            Theme.BackgroundOptions.Primary = value;
            Theme.TextColorOptions.Primary = value;

            Theme.InputOptions ??= new();

            Theme.InputOptions.CheckColor = value;
            Theme.InputOptions.SliderColor = value;

            Theme.SpinKitOptions ??= new();

            Theme.SpinKitOptions.Color = value;

            return InvokeAsync(Theme.ThemeHasChanged);
        }


        public async Task HandleAsync(SubscriptionCreatedEvent message)
        {
            await LoadData();
        }
    }
}