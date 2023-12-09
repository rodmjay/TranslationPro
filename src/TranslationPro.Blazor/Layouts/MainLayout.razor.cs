using Blazorise.Localization;
using Blazorise.Snackbar;
using EventAggregator.Blazor;
using Microsoft.AspNetCore.Components;
using TranslationPro.Blazor.Components.Application.Bases;
using TranslationPro.Blazor.Events;
using TranslationPro.Shared.Interfaces;
using TranslationPro.Shared.Models;

namespace TranslationPro.Blazor.Layouts
{
    public partial class MainLayout : IHandle<SubscriptionCreatedEvent>, 
        IHandle<ApplicationCreatedEvent>,
        IHandle<PhraseCreatedEvent>,
        IHandle<ApplicationDeletedEvent>,
        IHandle<PhraseDeletedEvent>,
        IHandle<LanguagesChangedEvent>,
        IHandle<PhrasesReprocessedEvent>
    {
        [CascadingParameter]
        protected IEventAggregator EventAggregator { get; set; }

        protected List<NavigationItem> NavigationItems { get; set; } = new();

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

        private async Task PushMessage(string message, SnackbarColor color = SnackbarColor.Success)
        {
            await snackbarStack.PushAsync(message, color, options =>
            {
                options.IntervalBeforeClose = intervalBeforeMsgClose;
            });
        }

        public async Task HandleAsync(SubscriptionCreatedEvent message)
        {
            await PushMessage("Subscription Created Successfully");
            await LoadData();
        }

        public async Task HandleAsync(ApplicationCreatedEvent message)
        {
            await PushMessage("Application Created Successfully");
            await LoadData();
        }

        SnackbarStack snackbarStack;
        double intervalBeforeMsgClose = 2000;
        public async Task HandleAsync(PhraseCreatedEvent message)
        {
            await PushMessage("Phrase Created Successfully");
        }

        public async Task HandleAsync(ApplicationDeletedEvent message)
        {
            await PushMessage("Application Deleted Successfully");
            await LoadData();
        }

        public async Task HandleAsync(PhraseDeletedEvent message)
        {
            await PushMessage("Phrase Deleted Successfully");
        }

        public async Task HandleAsync(LanguagesChangedEvent message)
        {
            await PushMessage("Languages Modified Successfully");
        }

        public async Task HandleAsync(PhrasesReprocessedEvent message)
        {
            await PushMessage("Phrases Processed Successfully", SnackbarColor.Info);
            await LoadData();
        }
    }
}