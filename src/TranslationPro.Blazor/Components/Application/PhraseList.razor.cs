using EventAggregator.Blazor;
using Microsoft.AspNetCore.Components;
using TranslationPro.Blazor.Events;
using TranslationPro.Shared.Common;
using TranslationPro.Shared.Filters;
using TranslationPro.Shared.Interfaces;
using TranslationPro.Shared.Models;

namespace TranslationPro.Blazor.Components.Application
{
    public partial class PhraseList : IHandle<LanguagesChangedEvent>, 
        IHandle<PhraseCreatedEvent>, 
        IHandle<PhraseDeletedEvent>
    {
        [CascadingParameter]
        public IEventAggregator EventAggregator { get; set; }

        [CascadingParameter]
        public ApplicationOutput Application { get; set; }

        [Inject]
        public IApplicationPhrasesController PhraseService { get; set; }

        [Inject]
        protected NavigationManager NavManager { get; set; }

        protected PagingQuery PagingQuery { get; set; } = new();

        protected PagedList<ApplicationPhraseOutput> PagedList { get; set; }

        protected override void OnInitialized()
        {
            EventAggregator.Subscribe(this);
        }

        public async Task LoadData()
        {
            PagedList = await PhraseService.GetPhrasesAsync(Application.Id, PagingQuery, new PhraseFilters());
        }
        
        protected override async Task OnParametersSetAsync()
        {
            await LoadData();
        }

        private async Task OnReadData(DataGridReadDataEventArgs<ApplicationPhraseOutput> e)
        {
            if (!e.CancellationToken.IsCancellationRequested)
            {

            }
        }

        private void HandleRowSelected(DataGridRowMouseEventArgs<ApplicationPhraseOutput> evnt)
        {
            NavManager.NavigateTo($"/applications/{Application.Id}/phrases/{evnt.Item.Id}");
        }

        private async Task HandlePageChanged(DataGridPageChangedEventArgs args)
        {
            var reload = false;

            if (PagedList.CurrentPage != args.Page)
            {
                reload = true;
                PagingQuery.Page = args.Page;
            }

            if (PagedList.PageSize != args.PageSize)
            {
                reload = true;
                PagingQuery.Size = args.PageSize;
            }

            if (reload)
            {
                await LoadData();
            }

        }

        public async Task HandleAsync(LanguagesChangedEvent message)
        {
            await LoadData();
        }

        public async Task HandleAsync(PhraseCreatedEvent message)
        {
            await LoadData();
        }

        public async Task HandleAsync(PhraseDeletedEvent message)
        {
            await LoadData();
        }
    }
}
